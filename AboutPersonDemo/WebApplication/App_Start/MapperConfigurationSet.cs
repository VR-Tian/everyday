using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;
using WebApplication.Models.Dto;

namespace WebApplication.App_Start
{
    public static class MapperConfigurationSet
    {
        public static void Register()
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<Order, OrderDto>();
                config.CreateMap<OrderItem, OrderItemDto>();
            });
            //var configuration = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Order, OrderDto>();
            //});
            //configuration.AssertConfigurationIsValid();
        }
    }
}