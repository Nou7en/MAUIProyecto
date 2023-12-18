using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIRESTAURANTE.Models
{
    public class Plato
    {
        [Key]
        public int IdPlato { get; set; }
        public string NombrePlato { get; set; }
        public string DescripcionPlato { get; set; }
        public double Precio { get; set; }

    }
}
