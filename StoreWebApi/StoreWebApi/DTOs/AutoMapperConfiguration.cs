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
                cfg.CreateMap<Ciudad, CiudadDTO>()
                .ForMember(x => x.Clima, o => o.Ignore())
                 .ReverseMap();

                cfg.CreateMap<Clima, ClimaDTO>()
                .ForMember(x => x.Noticia, o => o.Ignore())
                .ReverseMap();

                cfg.CreateMap<Noticia, NoticiaDTO>()
                    .ReverseMap();

                //cfg.CreateMap<Historia, HistoriaDTO>()
                //   .ReverseMap();



            });
        }
    }
}