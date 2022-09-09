using AutoMapper;
using OrderReceive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Profiles
{
    public class OrderLineProfile:Profile
    {
        public OrderLineProfile()
        {
            CreateMap<Models.OrderLineForUpdate, Entities.OrderLines>();
            CreateMap<Entities.OrderLines, Models.OrderLine>().ReverseMap();
            CreateMap<OrderLineForCreation, Entities.OrderLines>().ReverseMap();
        }
    }
}
