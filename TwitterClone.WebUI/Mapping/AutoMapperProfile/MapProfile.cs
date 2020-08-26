using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Dto.DTOs.AppUserDtos;
using TwitterClone.Dto.DTOs.MessageDtos;
using TwitterClone.Dto.DTOs.NotificationDtos;
using TwitterClone.Dto.DTOs.TweetDtos;
using TwitterClone.Entity.Concrete;

namespace TwitterClone.WebUI.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {

        public MapProfile()
        {

            CreateMap<AppUserRegisterDto, AppUser>();
            CreateMap<AppUser, AppUserRegisterDto>();
            CreateMap<AppUserLoginDto, AppUser>();
            CreateMap<AppUser, AppUserLoginDto>();
            CreateMap<AppUser, AppUserProfileHeaderDto>();
            CreateMap<AppUserProfileHeaderDto, AppUser>();
            CreateMap<AppUser, AppUserProfileUpdateDto>();
            CreateMap<AppUserProfileUpdateDto, AppUser>();
            CreateMap<AppUser, AppUserListDto>();
            CreateMap<AppUserListDto, AppUser>();


            CreateMap<Tweet, TweetAdddto>();
            CreateMap<TweetAdddto, Tweet>();
            CreateMap<Tweet, TweetListDto>();
            CreateMap<TweetListDto, Tweet>();

            CreateMap<Message, OneToOneMessageDto>();
            CreateMap<OneToOneMessageDto, Message>();
            CreateMap<Message, UserMessagesDto>();
            CreateMap<UserMessagesDto, Message>();
            CreateMap<Message, MessageAddDto>();
            CreateMap<MessageAddDto, Message>();

            CreateMap<Notification, NotificationListDto>();
            CreateMap<NotificationListDto, Message>();
            






        }

    }
}
