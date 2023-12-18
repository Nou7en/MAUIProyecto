using MAUIRESTAURANTE.Models;
using MAUIRESTAURANTE.Services;

namespace MAUIRESTAURANTE;

public partial class DatosFactura : ContentPage
{
    private readonly APIService _APIService;

    
    public DatosFactura(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }

    private async void GenerarFactura_Clicked(object sender, EventArgs e)
    {
        String nombre = nombreEntry.Text;
        String cedula = rucCedulaEntry.Text;
        String direcc = direccionEntry.Text;

        int x = Preferences.Get("NumeroMesa", 0);
        var ordenMesa = await _APIService.ObtenerOrdenMesa(x);

        Double total = await _APIService.CalcularTotal(ordenMesa.IdOrden);
       
        Factura fact = new Factura {


            idOrden = ordenMesa.IdOrden,
            nombre= nombre,
            cedula= cedula,
            direccion=direcc,
            total= total,
            fecha = DateTime.Now
        };

       await _APIService.CrearFactura(fact);
       await Navigation.PushModalAsync(new FacturaPage(_APIService, fact));

    }

    private async void OnClickCancelar(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}