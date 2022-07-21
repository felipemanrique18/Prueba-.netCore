using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end.Entidades
{
    public class PeliculasCInes
    {
        public int PeliculaId { get; set; }
        public int CIneId { get; set; }
        public Pelicula Pelicula { get; set; }
        public Cine Cine { get; set; }
    }
}
