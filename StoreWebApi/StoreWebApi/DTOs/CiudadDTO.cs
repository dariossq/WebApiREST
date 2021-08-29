using System;
using System.Collections.Generic;

namespace StoreWebApi.DTOs
{
    public  class CiudadDTO
    {
       
        public int CiudadId { get; set; }
        public string CiudadNombre { get; set; }

        public List<ClimaDTO> Clima { get; set; }
    }
}
