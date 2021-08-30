using System;
using System.Collections.Generic;

namespace StoreWebApi.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Clima = new HashSet<Clima>();
            Historia = new HashSet<Historia>();
        }


        public int CiudadId { get; set; }
        public string CiudadNombre { get; set; }

        public ICollection<Clima> Clima { get; set; }

        public ICollection<Historia> Historia { get; set; }
    }
}
