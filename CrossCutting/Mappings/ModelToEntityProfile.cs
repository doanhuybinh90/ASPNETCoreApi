using AutoMapper;
using Domain.Entities;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<Visitor, VisitorModel>().ReverseMap();
            CreateMap<Administrator, AdministratorModel>().ReverseMap();
            CreateMap<Booking, BookingModel>().ReverseMap();
        }
    }
}
