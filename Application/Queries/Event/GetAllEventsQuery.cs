using Application.Common;
using Application.Dtos.Event;
using Application.Dtos.Events;
using MediatR;

public class GetAllEventsQuery : IRequest<OperationResult<List<ReadEventDTO>>>
{
}