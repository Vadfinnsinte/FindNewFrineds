using Application.Common;
using Application.Dtos.Events;
using AutoMapper;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries.Events
{
    public class GetMyEventsQueryHandler
        : IRequestHandler<
            GetMyEventsQuery,
            OperationResult<List<ReadEventDTO>>>
    {
        private readonly IParticipantRepository _participantRepo;
        private readonly IMapper _mapper;

        public GetMyEventsQueryHandler(
            IParticipantRepository participantRepo,
            IMapper mapper)
        {
            _participantRepo = participantRepo;
            _mapper = mapper;
        }

        public async Task<OperationResult<List<ReadEventDTO>>> Handle(
            GetMyEventsQuery request,
            CancellationToken cancellationToken)
        {
            var events =
                await _participantRepo.GetUserEventsAsync(request.UserId);

            var dto =
                _mapper.Map<List<ReadEventDTO>>(events);

            return OperationResult<List<ReadEventDTO>>
                .Success(dto);
        }
    }
}