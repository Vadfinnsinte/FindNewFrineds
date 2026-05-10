using Application.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.Events.Delete
{
    public class DeleteEventCommandHandler
        : IRequestHandler<DeleteEventCommand, OperationResult<string>>
    {
        private readonly IEventRepository _repo;

        public DeleteEventCommandHandler(IEventRepository repo)
        {
            _repo = repo;
        }

        public async Task<OperationResult<string>> Handle(
            DeleteEventCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _repo.GetByIdAsync(request.EventId);

            if (entity == null)
            {
                return OperationResult<string>
                    .Failure("Event not found");
            }

            if (!request.IsAdmin &&
                entity.CreatedBy != request.UserId)
            {
                return OperationResult<string>
                    .Failure("Not allowed");
            }

            await _repo.DeleteAsync(entity);

            return OperationResult<string>
                .Success("Event deleted");
        }
    }
}