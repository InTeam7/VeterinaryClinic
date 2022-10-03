using System;
using AutoMapper;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Mappers
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorListDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(doctor => doctor.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(doctor => doctor.Name))
                .ForMember(dto => dto.PhoneNumber,
                    opt => opt.MapFrom(doctor => doctor.PhoneNumber))
                .ForMember(dto => dto.IsDeleted,
                    opt => opt.MapFrom(doctor => doctor.IsDeleted))
                .ForMember(dto => dto.Speciality,
                    opt => opt.MapFrom(doctor => doctor.Speciality));

            CreateMap<Doctor, DoctorDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(doctor => doctor.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(doctor => doctor.Name))
                .ForMember(dto => dto.PhoneNumber,
                    opt => opt.MapFrom(doctor => doctor.PhoneNumber))
                .ForMember(dto => dto.IsDeleted,
                    opt => opt.MapFrom(doctor => doctor.IsDeleted))
                .ForMember(dto => dto.Services,
                    opt => opt.MapFrom(doctor => doctor.Services))
                .ForMember(dto => dto.Speciality,
                    opt => opt.MapFrom(doctor => doctor.Speciality))
                .ForMember(dto => dto.ProvidedServices,
                    opt => opt.MapFrom(doctor => doctor.ProvidedServices));
        }
    }
}

