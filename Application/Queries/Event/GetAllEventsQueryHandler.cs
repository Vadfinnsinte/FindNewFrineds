using Application.Common;
using Application.Dtos.Event;
using Application.Dtos.Events;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

public class GetAllEventsQueryHandler
    : IRequestHandler<GetAllEventsQuery, OperationResult<List<ReadEventDTO>>>
{
    private readonly IEventRepository _repo;
    private readonly IMapper _mapper;

    public GetAllEventsQueryHandler(IEventRepository repo, IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<OperationResult<List<ReadEventDTO>>> Handle(
        GetAllEventsQuery request,
        CancellationToken cancellationToken)
    {
        var events = await _repo.GetAllAsync();

        var result = _mapper.Map<List<ReadEventDTO>>(events);

        return OperationResult<List<ReadEventDTO>>
            .Success(result);
    }
}