using Application.Common;
using MediatR;

namespace Application.Commands.Events.Delete
{
    public class DeleteEventCommand
        : IRequest<OperationResult<string>>
    {
        public Guid EventId { get; set; }

        public Guid UserId { get; set; }

        public bool IsAdmin { get; set; }
    }
}