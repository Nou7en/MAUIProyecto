using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIRESTAURANTE.Models
{
    class PlatoViewModel
    {
        public int IdPlato { get; set; }
        public string Nombre { get; set; }
        public double  Precio { get; set; }
        public int Cantidad { get; set; }
    }
}
