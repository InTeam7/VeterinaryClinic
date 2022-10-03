using System;
using AutoMapper;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Mappers
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<Animal, AnimalListDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(animal => animal.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(animal => animal.Name))
                .ForMember(dto => dto.Age,
                    opt => opt.MapFrom(animal => DateTime.Now.Year - animal.BirthDay.Year))
                .ForMember(dto => dto.Gender,
                    opt => opt.MapFrom(animal => animal.Gender))
                .ForMember(dto => dto.Specie,
                    opt => opt.MapFrom(animal => animal.Specie))
                .ForMember(dto => dto.FileName,
                    opt => opt.MapFrom(animal => animal.PhotoFileName));

            CreateMap<Animal,AnimalDto>()
                .ForMember(dto => dto.Id,
                    opt => opt.MapFrom(animal => animal.Id))
                .ForMember(dto => dto.Name,
                    opt => opt.MapFrom(animal => animal.Name))
                .ForMember(dto => dto.Gender,
                    opt => opt.MapFrom(animal => animal.Gender))
                .ForMember(dto => dto.Specie,
                    opt => opt.MapFrom(animal => animal.Specie))
                .ForMember(dto => dto.PhotoFileName,
                    opt => opt.MapFrom(animal => animal.PhotoFileName))
                .ForMember(dto => dto.Age,
                    opt => opt.MapFrom(animal => DateTime.Now.Year - animal.BirthDay.Year))
                .ForMember(dto=>dto.OwnerId,
                    opt=>opt.MapFrom(animal=>animal.OwnerId))
                .ForMember(dto=>dto.OwnerName,
                    opt=>opt.MapFrom(animal=>animal.Owner.Name))
                .ForMember(dto => dto.Vaccines,
                    opt => opt.MapFrom(animal => animal.Vaccines))
                .ForMember(dto => dto.ProviderServices,
                    opt => opt.MapFrom(animal => animal.ProvidedServices));
               
        }
    }
}

