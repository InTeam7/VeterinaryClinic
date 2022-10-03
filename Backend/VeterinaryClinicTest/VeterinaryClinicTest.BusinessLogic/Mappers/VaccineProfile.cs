using System;
using AutoMapper;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Mappers
{
    public class VaccineProfile : Profile
    {
        public VaccineProfile()
        {
            CreateMap<Vaccine, VaccineDto>()
                .ForMember(dto => dto.Id,
                           opt => opt.MapFrom(vaccine => vaccine.Id))
                .ForMember(dto => dto.Title,
                            opt => opt.MapFrom(vaccine => vaccine.Title))
                .ForMember(dto => dto.Price,
                            opt => opt.MapFrom(vaccine => vaccine.Price))
                .ForMember(dto => dto.ExpirationDate,
                            opt => opt.MapFrom(vaccine => vaccine.ExpirationDate))
                .ForMember(dto => dto.Count,
                            opt => opt.MapFrom(vaccine => vaccine.Count))
                .ForMember(dto => dto.Description,
                            opt => opt.MapFrom(vaccine => vaccine.Description))
                .ForMember(dto => dto.Date,
                            opt => opt.MapFrom(vaccine => vaccine.Date));

            CreateMap<Vaccine, VaccineListDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(vaccine => vaccine.Id))
                .ForMember(dto => dto.Title,
                    opt => opt.MapFrom(vaccine => vaccine.Title))
                .ForMember(dto => dto.Count,
                    opt => opt.MapFrom(vaccine => vaccine.Count))
                .ForMember(dto => dto.Price,
                    opt => opt.MapFrom(vaccine => vaccine.Price));

        }
    }
}

