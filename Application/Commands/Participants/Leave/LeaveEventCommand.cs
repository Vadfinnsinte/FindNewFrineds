using Application.Common;
using MediatR;

namespace Application.Commands.Participants.Leave
{
    public class LeaveEventCommand
        : IRequest<OperationResult<string>>
    {
        public Guid EventId { get; set; }

        public Guid UserId { get; set; }
    }
}