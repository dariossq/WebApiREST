using System;
using System.Collections.Generic;

namespace StoreWebApi.Models
{
    public  class CiudadDTO
    {
       
        public int CiudadId { get; set; }
        public string CiudadNombre { get; set; }

        //public List<Historia> Historia { get; set; }
        public List<Clima> Clima { get; set; }
    }
}
