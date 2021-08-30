using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApi.Models
{
    public  class HistoriaDTO
    {
        
        public int HistoriaId { get; set; }
        public DateTime HistoriaInfo { get; set; }
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
        
        //public List<Ciudad> Ciudad { get; set; }


    }
}
