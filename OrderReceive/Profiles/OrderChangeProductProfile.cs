using AutoMapper;
using OrderReceive.Entities;
using OrderReceive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Profiles
{
    public class OrderChangeProductProfile : Profile
    {
        public OrderChangeProductProfile()
        {
            CreateMap<OrderChangeProduct, OrderChangeProductForPublication>().ReverseMap();
        }
    }
}
