using Application.Dtos.Event;
using Application.Dtos.Message;
using Application.Dtos.User;
using AutoMapper;
using Domain.Models.Events;
using Domain.Models.Messages;
using Domain.Models.Users;
using Microsoft.Extensions.Logging;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        CreateMap<User, ReadUserDTO>();
        CreateMap<RegisterUserDTO, User>();
        CreateMap<UpdateUserDTO, User>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

  
        CreateMap<AddEventDTO, Event>();


        CreateMap<CreateMessageDTO, Message>()
            .ForMember(dest => dest.SenderId, opt => opt.Ignore())
            .ForMember(dest => dest.SentAt, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore());
    }
}