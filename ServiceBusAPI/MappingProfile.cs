using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBusAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Player, PlayerDto>();
            CreateMap<PlayerForCreationDto, Player>();
            CreateMap<PlayerForUpdateDto, Player>();

            CreateMap<SessionData, SessionDataDto>();
            CreateMap<SessionDataForCreationDto, SessionData>();
            CreateMap<SessionDataForUpdateDto, SessionData>();

            CreateMap<TopicData, TopicDataDto>();
            CreateMap<TopicDataForCreationDto, TopicData>();
            CreateMap<TopicDataForUpdateDto, TopicData>();

        }
    }
}
