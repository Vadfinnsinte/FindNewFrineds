using Application.Common;
using Application.Dtos.Events;
using Application.Dtos.Events;
using MediatR;

public class GetAllEventsQuery : IRequest<OperationResult<List<ReadEventDTO>>>
{
}