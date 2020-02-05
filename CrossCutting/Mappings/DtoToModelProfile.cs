using AutoMapper;
using Domain.DTOs.Administrator;
using Domain.DTOs.Bookings;
using Domain.DTOs.Visitor;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<VisitorModel, VisitorDtoGet>().ReverseMap();
            CreateMap<VisitorModel, VisitorDtoPost>().ReverseMap();
            CreateMap<VisitorModel, VisitorDtoPut>().ReverseMap();
            CreateMap<AdministratorModel, AdministratorDtoGet>().ReverseMap();
            CreateMap<AdministratorModel, AdminDtoPost>().ReverseMap();
            CreateMap<AdministratorModel, AdminDtoPut>().ReverseMap();
            CreateMap<BookingModel, BookingDtoGet>().ReverseMap();
            CreateMap<BookingModel, BookingDtoPost>().ReverseMap();
            CreateMap<BookingModel, BookingDtoPut>().ReverseMap();
        }
    }
}
