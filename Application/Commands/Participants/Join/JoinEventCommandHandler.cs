using Application.Common;
using Domain.Interfaces;
using Domain.Models.Participants;
using MediatR;

namespace Application.Commands.Participants.Join
{
    public class JoinEventCommandHandler
        : IRequestHandler<JoinEventCommand, OperationResult<string>>
    {
        private readonly IParticipantRepository _participantRepo;
        private readonly IEventRepository _eventRepo;

        public JoinEventCommandHandler(
            IParticipantRepository participantRepo,
            IEventRepository eventRepo)
        {
            _participantRepo = participantRepo;
            _eventRepo = eventRepo;
        }

        public async Task<OperationResult<string>> Handle(
            JoinEventCommand request,
            CancellationToken cancellationToken)
        {
            var eventEntity =
                await _eventRepo.GetByIdAsync(request.EventId);

            if (eventEntity == null)
            {
                return OperationResult<string>
                    .Failure("Event not found");
            }

            var alreadyJoined =
                await _participantRepo.ExistsAsync(
                    request.EventId,
                    request.UserId);

            if (alreadyJoined)
            {
                return OperationResult<string>
                    .Failure("Already joined");
            }

            var participant = new Participant
            {
                EventId = request.EventId,
                UserId = request.UserId
            };

            await _participantRepo.AddAsync(participant);

            return OperationResult<string>
                .Success("Joined event");
        }
    }
}