using AutoMapper;
using Domain.DTOs.Administrator;
using Domain.DTOs.Bookings;
using Domain.DTOs.Visitor;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<VisitorDtoGet, Visitor>().ReverseMap();
            CreateMap<VisitorDtoPost, Visitor>().ReverseMap();
            CreateMap<VisitorDtoPut, Visitor>().ReverseMap();
            CreateMap<InputCreateVisitor, Visitor>().ReverseMap();
            CreateMap<InputLoginVisitor, Visitor>().ReverseMap();
            CreateMap<InputUpdateVisitor, Visitor>().ReverseMap();

            CreateMap<AdministratorDtoGet, Administrator>().ReverseMap();
            CreateMap<AdminDtoPost, Administrator>().ReverseMap();
            CreateMap<AdminDtoPut, Administrator>().ReverseMap();
            CreateMap<InputCreateAdmin, Administrator>().ReverseMap();
            CreateMap<InputLoginAdmin, Administrator>().ReverseMap();
            CreateMap<InputUpdateAdmin, Administrator>().ReverseMap();

            CreateMap<BookingDtoGet, Booking>().ReverseMap();
            CreateMap<BookingDtoPost, Booking>().ReverseMap();
            CreateMap<BookingDtoPut, Booking>().ReverseMap();
            CreateMap<InputCreateBooking, Booking>().ReverseMap();
            CreateMap<InputUpdateBooking, Booking>().ReverseMap();
        }
    }
}
