using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApi.Models
{
    public partial class Historia
    {
        //public Historia()
        //{
        //    Ciudad = new HashSet<Ciudad>();
        //}

        public int HistoriaId { get; set; }
        public DateTime HistoriaInfo { get; set; }
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
        //public ICollection<Ciudad> Ciudad { get; set; }


    }
}
