using AutoMapper;
using OrderReceive.Messages;
using OrderReceive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderReceive.Profiles
{
    public class OrderCreatedProfile :Profile
    {
        public OrderCreatedProfile()
        {
            CreateMap<OrderCreated, OrderCreatedMessage>().ReverseMap();
            CreateMap<OrderLine, OrderLineMessage>().ReverseMap();
        }
    }
}
