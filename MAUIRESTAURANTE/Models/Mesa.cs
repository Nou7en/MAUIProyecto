using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIRESTAURANTE.Models
{
    public class Mesa
    {
        [Key]
        public int IdMesa { get; set; }
        public bool estado { get; set; }
    }
}

