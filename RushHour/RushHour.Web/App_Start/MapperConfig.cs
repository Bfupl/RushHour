using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace RushHour.Web.App_Start
{
    public class MapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            cfg.AddProfiles(Assembly.GetExecutingAssembly()));
        }
    }
}