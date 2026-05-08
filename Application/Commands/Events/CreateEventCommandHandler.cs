using Application.Common;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

public class EditEventCommandHandler
    : IRequestHandler<EditEventCommand, OperationResult<string>>
{
    private readonly IEventRepository _repo;
    private readonly IMapper _mapper;

    public EditEventCommandHandler(
        IEventRepository repo,
        IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<OperationResult<string>> Handle(
        EditEventCommand request,
        CancellationToken cancellationToken)
    {
        var entity = await _repo.GetByIdAsync(request.EventId);

        if (entity == null)
            return OperationResult<string>.Failure("Event not found");

        // auth rule
        if (!request.IsAdmin && entity.CreatedBy != request.UserId)
            return OperationResult<string>.Failure("Not allowed");

       
        _mapper.Map(request.Dto, entity);

        await _repo.UpdateAsync(entity);

        return OperationResult<string>.Success("Event updated");
    }
}