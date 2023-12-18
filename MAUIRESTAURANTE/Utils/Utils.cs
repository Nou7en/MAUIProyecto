using MAUIRESTAURANTE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIRESTAURANTE.Utils
{
    class Utils
    {
        static public List<PlatoOrden> ListaPlatOrdenados = new List<PlatoOrden>()
        {
            new PlatoOrden()
            {
                IdPlatoOrden = 1,
                IdPlato = 1,
                Cantidad = 1
            },
             new PlatoOrden()
            {
                IdPlatoOrden = 2,
                IdPlato = 2,
                Cantidad = 2
            },
              new PlatoOrden()
            {
                IdPlatoOrden = 3,
                IdPlato = 3,
                Cantidad = 3
            },
               new PlatoOrden()
            {
                IdPlatoOrden = 4,
                IdPlato = 4,
                Cantidad = 4
            }


        };
        static public List<Models.Plato> ListaPlatos = new List<Plato>()
        {
            new Plato()
            {
                IdPlato = 1,
                NombrePlato = "Plato1",
                DescripcionPlato = "Descripcion 1",
                Precio = 1
            },

            new Plato()
            {
                IdPlato = 2,
                NombrePlato = "Plato2",
                DescripcionPlato = "Descripcion 2",
                Precio = 2
            }

        };

        public static event EventHandler ListaPlatosChanged;

        public static void NotifyListaPlatosChanged()
        {
            ListaPlatosChanged?.Invoke(null, EventArgs.Empty);
        }
    }
}

