using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MVC_HandsOn.Models;
using MVC_HandsOn.Dtos;

namespace MVC_HandsOn.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, customer>();
        }
    }
}