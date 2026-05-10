using Application.Common;
using MediatR;

namespace Application.Commands.Participants.Join
{
    public class JoinEventCommand
        : IRequest<OperationResult<string>>
    {
        public Guid EventId { get; set; }

        public Guid UserId { get; set; }
    }
}