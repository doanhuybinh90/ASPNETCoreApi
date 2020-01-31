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
            CreateMap<VisitorModel, InputCreateVisitor>().ReverseMap();
            CreateMap<VisitorModel, InputLoginVisitor>().ReverseMap();
            CreateMap<VisitorModel, InputUpdateVisitor>().ReverseMap();
            CreateMap<AdministratorModel, InputCreateAdmin>().ReverseMap();
            CreateMap<AdministratorModel, InputLoginAdmin>().ReverseMap();
            CreateMap<AdministratorModel, InputUpdateAdmin>().ReverseMap();
            CreateMap<BookingModel, InputCreateBooking>().ReverseMap();
        }
    }
}
