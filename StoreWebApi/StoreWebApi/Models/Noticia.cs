using System;
using System.Collections.Generic;

namespace StoreWebApi.Models
{
    public partial class Noticia
    {
        public int NoticiaId { get; set; }
        public string NoticiaAutor { get; set; }
        public string NoticiaTitulo { get; set; }
        public string NoticiaDescripcion { get; set; }
        public string NoticiaUrl { get; set; }
        public DateTime NoticiaFecha { get; set; }
        public string NoticiaContenido { get; set; }
        public int? ClimaId { get; set; }

        public Clima Clima { get; set; }
    }
}
