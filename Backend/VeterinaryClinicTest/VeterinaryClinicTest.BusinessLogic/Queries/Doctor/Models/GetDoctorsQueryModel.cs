﻿using System;
using System.Collections.Generic;
using MediatR;
using VeterinaryClinicTest.BusinessLogic.Dto;

namespace VeterinaryClinicTest.BusinessLogic.Queries.Doctor.Models
{
    public class GetDoctorsQueryModel : IRequest<IList<DoctorListDto>>
    {
        public GetDoctorsQueryModel()
        {
        }
    }
}

