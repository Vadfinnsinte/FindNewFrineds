using Application.Common;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands.Participants.Leave
{
    public class LeaveEventCommandHandler
        : IRequestHandler<LeaveEventCommand, OperationResult<string>>
    {
        private readonly IParticipantRepository _participantRepo;

        public LeaveEventCommandHandler(
            IParticipantRepository participantRepo)
        {
            _participantRepo = participantRepo;
        }

        public async Task<OperationResult<string>> Handle(
            LeaveEventCommand request,
            CancellationToken cancellationToken)
        {
            var participant =
                await _participantRepo.GetAsync(
                    request.EventId,
                    request.UserId);

            if (participant == null)
            {
                return OperationResult<string>
                    .Failure("You are not participating");
            }

            await _participantRepo.DeleteAsync(participant);

            return OperationResult<string>
                .Success("Left event");
        }
    }
}