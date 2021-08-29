using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StoreWebApi.Models;

namespace StoreWebApi.DTOs
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {

                cfg.CreateMap<Noticia, NoticiaDTO>()
                    .ReverseMap();

                cfg.CreateMap<Clima, ClimaDTO>()
                   .ReverseMap();

            });
        }
    }
}