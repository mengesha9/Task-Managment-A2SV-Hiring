using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.DTOs.Tasks;
using Application.DTOs.Users;
using AutoMapper;
using Domain.Entites;

namespace Application.Profiles
{
    public class MappingProfiles:Profile
    {
        
        public MappingProfiles()
        {
            CreateMap<AppUser,UserReturn>().ReverseMap();
            CreateMap<Domain.Entites.Task,TaskReturnDto>().ReverseMap();
            CreateMap<Domain.Entites.Task, TaskCreateDto>().ReverseMap();

            


        }
    }
}