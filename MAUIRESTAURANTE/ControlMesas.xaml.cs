using MAUIRESTAURANTE.Services;
using Microsoft.Maui.Controls;

namespace MAUIRESTAURANTE
{
    public partial class ControlMesas : ContentPage
    {

        private readonly APIService _APIService;
        public ControlMesas(APIService apiservice)
        {
            InitializeComponent();
            _APIService = apiservice;
        }

        private async void TerminarMesa_Clicked1(object sender, System.EventArgs e)
        {
            var options = new string[] { "Sin factura", "Factura" };
            var selectedOption = await DisplayActionSheet("Seleccione la opción preferida", "Cancelar", null, options);

            if (selectedOption != null)
            {
                if (selectedOption == "Sin factura")
                {
                    await DisplayAlert("Sin factura", "Opción seleccionada: Sin factura", "OK");
                    // Navegar a la página Comprobante
                    await Navigation.PushModalAsync(new AntesDeEmpezar(_APIService));
                }
                else if (selectedOption == "Factura")
                {
                    await DisplayAlert("Factura", "Opción seleccionada: Factura", "OK");
                    int idMesa = 1;
                    Preferences.Set("NumeroMesa", idMesa);
                    await _APIService.CambiarEstadoMesa(idMesa);
                    await Navigation.PushModalAsync(new DatosFactura(_APIService));


                }
            }
        }

        private async void VisualizarPedido_Clicked1(object sender, EventArgs e)
        {
            int idMesa = 1;
            var mesa1 = await _APIService.ObtenerMesa(idMesa);
            if (mesa1.estado == true)
            {
                await DisplayAlert("Alert!", "Todavia no hay ordenes en esta mesa", "OK");
                await Navigation.PopModalAsync();
            }

            Preferences.Set("NumeroMesa", idMesa);
            await Navigation.PushModalAsync(new PlatosOrdenadosVer(_APIService));

        }


        private async void RegresarButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void TerminarMesa_Clicked2(object sender, EventArgs e)
        {
            var options = new string[] { "Sin factura", "Factura" };
            var selectedOption = await DisplayActionSheet("Seleccione la opción preferida", "Cancelar", null, options);

            if (selectedOption != null)
            {
                if (selectedOption == "Sin factura")
                {
                    await DisplayAlert("Sin factura", "Opción seleccionada: Sin factura", "OK");
                    // Navegar a la página Comprobante
                    await Navigation.PushModalAsync(new AntesDeEmpezar(_APIService));
                }
                else if (selectedOption == "Factura")
                {

                        // Lógica para manejar la opción "Factura"
                        // Puedes abrir una nueva página, mostrar información adicional, etc.
                        await DisplayAlert("Factura", "Opción seleccionada: Factura", "OK");
                        int idMesa = 2;
                        Preferences.Set("NumeroMesa", idMesa);
                        await _APIService.CambiarEstadoMesa(idMesa);
                        await Navigation.PushModalAsync(new DatosFactura(_APIService));

                   
                   

                }
            }

        }

        private async void TerminarMesa_Clicked3(object sender, EventArgs e)
        {
            var options = new string[] { "Sin factura", "Factura" };
            var selectedOption = await DisplayActionSheet("Seleccione la opción preferida", "Cancelar", null, options);

            if (selectedOption != null)
            {
                if (selectedOption == "Sin factura")
                {
                    await DisplayAlert("Sin factura", "Opción seleccionada: Sin factura", "OK");
                    // Navegar a la página Comprobante
                    await Navigation.PushModalAsync(new AntesDeEmpezar(_APIService));
                }
                else if (selectedOption == "Factura")
                {
                    await DisplayAlert("Factura", "Opción seleccionada: Factura", "OK");
                    int idMesa = 3;
                    Preferences.Set("NumeroMesa", idMesa);
                    await _APIService.CambiarEstadoMesa(idMesa);
                    await Navigation.PushModalAsync(new DatosFactura(_APIService));

                }
            }
        }

        private async void TerminarMesa_Clicked4(object sender, EventArgs e)
        {
            var options = new string[] { "Sin factura", "Factura" };
            var selectedOption = await DisplayActionSheet("Seleccione la opción preferida", "Cancelar", null, options);

            if (selectedOption != null)
            {
                if (selectedOption == "Sin factura")
                {
                    await DisplayAlert("Sin factura", "Opción seleccionada: Sin factura", "OK");
                    // Navegar a la página Comprobante
                    await Navigation.PushModalAsync(new AntesDeEmpezar(_APIService));
                }
                else if (selectedOption == "Factura")
                {
                    await DisplayAlert("Factura", "Opción seleccionada: Factura", "OK");
                    int idMesa = 4;
                    Preferences.Set("NumeroMesa", idMesa);
                    await _APIService.CambiarEstadoMesa(idMesa);
                    await Navigation.PushModalAsync(new DatosFactura(_APIService));


                }
            }
        }

        private async void TerminarMesa_Clicked5(object sender, EventArgs e)
        {
            var options = new string[] { "Sin factura", "Factura" };
            var selectedOption = await DisplayActionSheet("Seleccione la opción preferida", "Cancelar", null, options);

            if (selectedOption != null)
            {
                if (selectedOption == "Sin factura")
                {
                    await DisplayAlert("Sin factura", "Opción seleccionada: Sin factura", "OK");
                    // Navegar a la página Comprobante
                    await Navigation.PushModalAsync(new AntesDeEmpezar(_APIService));
                }
                else if (selectedOption == "Factura")
                {
                    await DisplayAlert("Factura", "Opción seleccionada: Factura", "OK");
                    int idMesa = 5;
                    Preferences.Set("NumeroMesa", idMesa);
                    await _APIService.CambiarEstadoMesa(idMesa);
                    await Navigation.PushModalAsync(new DatosFactura(_APIService));


                }
            }
        }

        private async void TerminarMesa_Clicked6(object sender, EventArgs e)
        {
            var options = new string[] { "Sin factura", "Factura" };
            var selectedOption = await DisplayActionSheet("Seleccione la opción preferida", "Cancelar", null, options);

            if (selectedOption != null)
            {
                if (selectedOption == "Sin factura")
                {
                    await DisplayAlert("Sin factura", "Opción seleccionada: Sin factura", "OK");
                    // Navegar a la página Comprobante
                    await Navigation.PushModalAsync(new AntesDeEmpezar(_APIService));
                }
                else if (selectedOption == "Factura")
                {
                    await DisplayAlert("Factura", "Opción seleccionada: Factura", "OK");
                    int idMesa = 6;
                    Preferences.Set("NumeroMesa", idMesa);
                    await _APIService.CambiarEstadoMesa(idMesa);
                    await Navigation.PushModalAsync(new DatosFactura(_APIService));


                }
            }
        }

        private async void VisualizarPedido_Clicked2(object sender, EventArgs e)
        {
            int idMesa = 2;
            var mesa1 = await _APIService.ObtenerMesa(idMesa);
            if (mesa1.estado==true)
            {
                await DisplayAlert("Alert!","Todavia no hay ordenes en esta mesa", "OK");
                await Navigation.PopModalAsync();
            }
            
            Preferences.Set("NumeroMesa", idMesa);
            await Navigation.PushModalAsync(new PlatosOrdenadosVer(_APIService));
        }

        private async void VisualizarPedido_Clicked3(object sender, EventArgs e)
        {
            int idMesa = 3;
            var mesa1 = await _APIService.ObtenerMesa(idMesa);
            if (mesa1.estado == true)
            {
                await DisplayAlert("Alert!", "Todavia no hay ordenes en esta mesa", "OK");
                await Navigation.PopModalAsync();
            }

            Preferences.Set("NumeroMesa", idMesa);
            await Navigation.PushModalAsync(new PlatosOrdenadosVer(_APIService));
        }

        private async void VisualizarPedido_Clicked4(object sender, EventArgs e)
        {
            int idMesa = 4;
            var mesa1 = await _APIService.ObtenerMesa(idMesa);
            if (mesa1.estado == true)
            {
                await DisplayAlert("Alert!", "Todavia no hay ordenes en esta mesa", "OK");
                await Navigation.PopModalAsync();
            }

            Preferences.Set("NumeroMesa", idMesa);
            await Navigation.PushModalAsync(new PlatosOrdenadosVer(_APIService));
        }

        private async void VisualizarPedido_Clicked5(object sender, EventArgs e)
        {
            int idMesa = 5;
            var mesa1 = await _APIService.ObtenerMesa(idMesa);
            if (mesa1.estado == true)
            {
                await DisplayAlert("Alert!", "Todavia no hay ordenes en esta mesa", "OK");
                await Navigation.PopModalAsync();
            }

            Preferences.Set("NumeroMesa", idMesa);
            await Navigation.PushModalAsync(new PlatosOrdenadosVer(_APIService));
        }

        private async void VisualizarPedido_Clicked6(object sender, EventArgs e)
        {
            int idMesa = 6;
            var mesa1 = await _APIService.ObtenerMesa(idMesa);
            if (mesa1.estado == true)
            {
                await DisplayAlert("Alert!", "Todavia no hay ordenes en esta mesa", "OK");
                await Navigation.PopModalAsync();
            }

            Preferences.Set("NumeroMesa", idMesa);
            await Navigation.PushModalAsync(new PlatosOrdenadosVer(_APIService));
        }

        // Otros métodos y eventos
    }
}
