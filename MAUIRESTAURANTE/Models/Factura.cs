using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIRESTAURANTE.Models
{
    public class Factura
    {
        [Key]
        public int idFactura { get; set; }
        public int idOrden { get; set; }
        public double total { get; set; }
        public string nombre { get; set; }
        public string cedula { get; set; }
        public string direccion { get; set; }
        public DateTime fecha { get; set; }

    }
}
