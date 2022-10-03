using System;
using AutoMapper;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Mappers
{
    public class ClinicServiceProfile : Profile
    {
        public ClinicServiceProfile()
        {
            CreateMap<ClinicService, ClinicServiceDto>()
                .ForMember(dto => dto.Title,
                    opt => opt.MapFrom(service => service.Title))
                .ForMember(dto => dto.Price,
                    opt => opt.MapFrom(service => service.Price))
                .ForMember(dto => dto.Description,
                    opt => opt.MapFrom(service => service.Description))
                .ForMember(dto => dto.Doctors,
                    opt => opt.MapFrom(service => service.Doctors))
                .ForMember(dto => dto.ProvidedServices,
                    opt => opt.MapFrom(service => service.ProvidedServices))
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(service => service.Id))
                .ForMember(dto => dto.IsDeleted,
                    opt => opt.MapFrom(service => service.IsDeleted));

            CreateMap<ClinicService, ClinicServiceListDto>()
                .ForMember(dto => dto.Title,
                    opt => opt.MapFrom(service => service.Title))
                .ForMember(dto => dto.Price,
                    opt => opt.MapFrom(service => service.Price))
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(service => service.Id))
                .ForMember(dto => dto.IsDeleted,
                    opt => opt.MapFrom(service => service.IsDeleted));


        }
    }
}

