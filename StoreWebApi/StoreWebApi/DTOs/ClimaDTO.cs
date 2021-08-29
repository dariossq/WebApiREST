using System;
using System.Collections.Generic;

namespace StoreWebApi.DTOs
{
    public  class ClimaDTO
    {

        public int ClimaId { get; set; }
        public DateTime ClimaObserTiempo { get; set; }
        public string ClimaDescripcion { get; set; }
        public int ClimaVelViento { get; set; }
        public int ClimaGradoViento { get; set; }
        public string ClimaDirViento { get; set; }
        public int ClimaPresicion { get; set; }
        public int ClimaHumedad { get; set; }
        public int ClimaCubreNube { get; set; }
        public int ClimaMaxmo { get; set; }
        public int ClimaVisibilidad { get; set; }
        public int? CiudadId { get; set; }

        public CiudadDTO Ciudad { get; set; }
        public List<NoticiaDTO> Noticia { get; set; }
    }
}
