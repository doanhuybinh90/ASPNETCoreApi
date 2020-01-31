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
            CreateMap<InputCreateVisitor, Visitor>().ReverseMap();
            CreateMap<InputLoginVisitor, Visitor>().ReverseMap();
            CreateMap<InputUpdateVisitor, Visitor>().ReverseMap();
            CreateMap<InputCreateAdmin, Administrator>().ReverseMap();
            CreateMap<InputLoginAdmin, Administrator>().ReverseMap();
            CreateMap<InputUpdateAdmin, Administrator>().ReverseMap();
            CreateMap<InputCreateBooking, Booking>().ReverseMap();
        }
    }
}
