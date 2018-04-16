using AutoMapper;
using RCA.Data.Models;
using RCA.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCA.Interface.Initializer
{
    public static class Initializer
    {
        public static void MapperConfiguration()
        {
            Mapper.Initialize( cfg => 
            {
                cfg.CreateMap<Cafe, CafeDTO>().ReverseMap();
            });
        }
    }
}
