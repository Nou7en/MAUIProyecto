// OrdenPage.xaml.cs

using MAUIRESTAURANTE.Models;
using MAUIRESTAURANTE.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace MAUIRESTAURANTE
{
    public partial class OrdenPage : ContentPage
    {
        private readonly APIService _APIService;

        private Orden _Orden;
        private List<PlatoOrden> Pedido;


        public OrdenPage(APIService apiservice, Orden orden)
        {
            InitializeComponent();
            _APIService = apiservice;
            _Orden = orden;
 

        }

        protected override async void OnAppearing()
        {
           base.OnAppearing();
           Pedido =  await _APIService.ObtenerPedido(_Orden.IdOrden);
          var platosSeleccionados = Pedido.ToList();
           platosOrdenListView.ItemsSource = platosSeleccionados;

            //platosListView.ItemsSource = _platosOrden;
            //platosOrdenListView.ItemsSource = _platosOrden; // Asigna _platosOrden a un ListView diferente

        }

        private async void ClickedAñadir(object sender, EventArgs e)
        {
            // Obtener el botón que desencadenó el evento
            Button button = (Button)sender;

            // Obtener el contexto (PlatoOrden) del botón
            if (button.BindingContext is PlatoOrden platoOrden)
            {
                // Aquí puedes acceder a la propiedad IdPlatoOrden y realizar las operaciones necesarias
                int idPlatoOrden = platoOrden.IdPlatoOrden;



                await _APIService.SumarCantidad(idPlatoOrden);


            }
        }






        private async void OrdenarButton_Clicked(object sender, EventArgs e)
        {
            try
            {   

                await DisplayAlert("Éxito", "La orden ha sido creada", "OK");
                await Navigation.PushModalAsync(new ViewOrdenUsuarios(_APIService, _Orden));

            }
            catch (Exception ex)
            {
                // Manejo de errores en caso de cualquier problema durante el proceso.
                await DisplayAlert("Error", $"Error al procesar la orden: {ex.Message}", "OK");
            }
        }



        private async void CancelarButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void ClickedQuitar(object sender, EventArgs e)
        {
            // Obtener el botón que desencadenó el evento
            Button button = (Button)sender;

            // Obtener el contexto (PlatoOrden) del botón
            if (button.BindingContext is PlatoOrden platoOrden)
            {
                // Aquí puedes acceder a la propiedad IdPlatoOrden y realizar las operaciones necesarias
                int idPlatoOrden = platoOrden.IdPlatoOrden;

                await _APIService.RestarCantidad(idPlatoOrden);

            }
        }
    }
}
