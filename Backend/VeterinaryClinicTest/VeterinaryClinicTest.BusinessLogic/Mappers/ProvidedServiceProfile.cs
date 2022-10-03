using System;
using AutoMapper;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Mappers
{
    public class ProvidedServiceProfile : Profile
    {
        public ProvidedServiceProfile()
        {
            CreateMap<ProvidedService, ProvidedServiceListDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(service => service.Id))
                .ForMember(dto => dto.AnimalName,
                    opt => opt.MapFrom(service => service.Animal.Name))
                .ForMember(dto => dto.DoctorName,
                    opt => opt.MapFrom(service => service.Doctor.Name))
                .ForMember(dto => dto.ServiceName,
                    opt => opt.MapFrom(service => service.Service.Title))
                .ForMember(dto => dto.Price,
                    opt => opt.MapFrom(service => service.Service.Price))
                .ForMember(dto => dto.VaccinePrice,
                    opt => opt.MapFrom(service => service.VaccinePrice))
                .ForMember(dto => dto.ServicePrice,
                    opt => opt.MapFrom(service => service.ServicePrice))
                .ForMember(dto => dto.Date,
                    opt => opt.MapFrom(service => service.Date));

            CreateMap<ProvidedService, ProvidedServiceDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(service => service.Id))
                .ForMember(dto => dto.AnimalName,
                    opt => opt.MapFrom(service => service.Animal.Name))
                .ForMember(dto => dto.DoctorName,
                    opt => opt.MapFrom(service => service.Doctor.Name))
                .ForMember(dto => dto.ServiceName,
                    opt => opt.MapFrom(service => service.Service.Title))
                .ForMember(dto => dto.Price,
                    opt => opt.MapFrom(service => service.Service.Price))
                .ForMember(dto => dto.VaccinePrice,
                    opt => opt.MapFrom(service => service.VaccinePrice))
                .ForMember(dto => dto.ServicePrice,
                    opt => opt.MapFrom(service => service.ServicePrice))
                .ForMember(dto => dto.Date,
                    opt => opt.MapFrom(service => service.Date))
                .ForMember(dto => dto.Anamnesis,
                    opt => opt.MapFrom(service => service.Anamnesis))
                .ForMember(dto => dto.VaccineId,
                    opt => opt.MapFrom(service => service.VaccineId))
                .ForMember(dto => dto.DoctorPhoneNumber,
                    opt => opt.MapFrom(service => service.Doctor.PhoneNumber))
                .ForMember(dto => dto.OwnerName,
                    opt => opt.MapFrom(service => service.Animal.Owner.Name))
                .ForMember(dto => dto.OwnerPhoneNumber,
                    opt => opt.MapFrom(service => service.Animal.Owner.PhoneNumber))
                .ForMember(dto => dto.Gender,
                    opt => opt.MapFrom(service => service.Animal.Gender))
                .ForMember(dto => dto.Specie,
                    opt => opt.MapFrom(service => service.Animal.Specie))
                .ForMember(dto => dto.AnimalAge,
                    opt => opt.MapFrom(service => DateTime.Now.Year - service.Animal.BirthDay.Year))


                .ForMember(dto => dto.Diagnosis,
                    opt => opt.MapFrom(service => service.Diagnosis));


        }
    }
}

