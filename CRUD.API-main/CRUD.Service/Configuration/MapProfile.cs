using AutoMapper;
using CRUD.Domain.Dto.Client;
using CRUD.Domain.Models;
using System;

namespace CRUD.Service.Configuration
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Client, ClientRegisterDto>().ReverseMap();
            CreateMap<Client, ClientResponseDto>().ReverseMap();
            CreateMap<Client, ClientUpdateDto>().ReverseMap();
        }
    }
}
