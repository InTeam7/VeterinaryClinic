using System;
using System.Linq;
using AutoMapper;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Mappers
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Client, ClientDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(client => client.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(client => client.Name))
                .ForMember(dto => dto.PhoneNumber,
                    opt => opt.MapFrom(client => client.PhoneNumber))
                .ForMember(dto => dto.Email,
                    opt => opt.MapFrom(client => client.Email))
                .ForMember(dto => dto.Purchases,
                    opt => opt.MapFrom(client => client.Purchases))
                .ForMember(dto => dto.Animals,
                    opt => opt.MapFrom(client => client.Animals));


            CreateMap<Client, ClientListDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(client => client.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(client => client.Name))
                .ForMember(dto => dto.PhoneNumber,
                    opt => opt.MapFrom(client => client.PhoneNumber))
                .ForMember(dto => dto.Email,
                    opt => opt.MapFrom(client => client.Email))
                .ForMember(dto => dto.Animals,
                    opt => opt.MapFrom(client => client.Animals));
             
                
                
        }
    }
}

