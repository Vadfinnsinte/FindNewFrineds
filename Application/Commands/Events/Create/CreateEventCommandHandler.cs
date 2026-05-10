using Application.Common;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models.Events;
using MediatR;


namespace Application.Commands.Events.Create
{
    public class CreateEventCommandHandler
     : IRequestHandler<CreateEventCommand, OperationResult<string>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(
            IEventRepository eventRepository,
            IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        public async Task<OperationResult<string>> Handle(
            CreateEventCommand request,
            CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<EventEntity>(request.Dto);

            entity.CreatedBy = request.CreatedBy;

            await _eventRepository.AddAsync(entity);

            return OperationResult<string>.Success("Event created");
        }
    }
}