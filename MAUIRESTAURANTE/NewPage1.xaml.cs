using MAUIRESTAURANTE.Models;
using MAUIRESTAURANTE.Services;
using System.Collections.ObjectModel;

namespace MAUIRESTAURANTE;

public partial class NewPage1 : ContentPage
{
    private readonly APIService _APIService;
    private int _idOrdenActual;  // ID de la orden actual
    private Orden orden;
    private List<PlatoOrden> _platosOrden;
    public NewPage1(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }


    private async  void MesasPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        var selectedMesa = mesasPicker.SelectedItem?.ToString();



        if (!string.IsNullOrEmpty(selectedMesa))
        {
            // Extraer el número de la mesa del nombre seleccionado (suponiendo que el nombre es "Mesa X")
            if (int.TryParse(selectedMesa.Replace("Mesa ", ""), out int mesaNumero))
            {

                // Crear un objeto Orden con el número de la mesa
                Orden nuevaOrden = new Orden { IdMesa = mesaNumero , Estado = true};

                // Llamar al método _APIService.CrearOrden para crear la orden en el servidor
                Orden ordenCreada = await _APIService.CrearOrden(nuevaOrden);
                orden= ordenCreada;

                await _APIService.CambiarEstadoMesa(mesaNumero);




                if (ordenCreada != null)
                {
                    _idOrdenActual = ordenCreada.IdOrden;
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo crear la orden", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "No se pudo determinar el número de la mesa", "OK");
            }
        }
    }

    private async void Comenzarorden(object sender, EventArgs e)
    {
        List<Plato> listaplatos = await _APIService.ObtenerListaPlatos();
        _platosOrden = listaplatos.Select(p => new PlatoOrden { IdPlatoOrden = 0, IdOrden = _idOrdenActual, IdPlato = p.IdPlato, Cantidad = 0, NombrePlato = p.NombrePlato, DescripcionPlato = p.DescripcionPlato, Precio = p.Precio }).ToList();
        var platosSeleccionados = _platosOrden.ToList();
        foreach (var platoSeleccionado in platosSeleccionados)
        {
            bool platoCreado = await _APIService.CrearPlatoOrden(platoSeleccionado);

        }

        await Navigation.PushModalAsync(new OrdenPage(_APIService, orden));

    }
}