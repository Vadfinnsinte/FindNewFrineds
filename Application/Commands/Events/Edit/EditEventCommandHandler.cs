using Application.Common;
using Domain.Interfaces;
using MediatR;


namespace Application.Commands.Events.Edit
{
    public class EditEventCommandHandler
    : IRequestHandler<EditEventCommand, OperationResult<string>>
    {
        private readonly IEventRepository _repo;

        public EditEventCommandHandler(IEventRepository repo)
        {
            _repo = repo;
        }

        public async Task<OperationResult<string>> Handle(
            EditEventCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _repo.GetByIdAsync(request.EventId);

            if (entity == null)
                return OperationResult<string>.Failure("Event not found");

       
            if (!request.IsAdmin && entity.CreatedBy != request.UserId)
                return OperationResult<string>.Failure("Not allowed");

            entity.Name = request.Dto.Name;
            entity.DateOfEvent = request.Dto.DateOfEvent;

            await _repo.UpdateAsync(entity);

            return OperationResult<string>.Success("Event updated");
        }
    }
}
