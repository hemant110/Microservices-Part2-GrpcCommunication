using AutoMapper;
using OrderReceive.Entities;
using OrderReceive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Profiles
{
    public class OrderHeaderProfile :Profile
    {
        public OrderHeaderProfile()
        {
            CreateMap<OrderForCreation, Entities.OrderHeader>();
            CreateMap<Entities.OrderHeader, Models.OrderHeader>().ReverseMap();

        }
    }
}
