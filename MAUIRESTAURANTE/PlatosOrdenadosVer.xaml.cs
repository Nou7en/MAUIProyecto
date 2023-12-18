using MAUIRESTAURANTE.Models;
using MAUIRESTAURANTE.Services;

namespace MAUIRESTAURANTE;

public partial class PlatosOrdenadosVer : ContentPage
{
    private readonly APIService _APIService;

    public PlatosOrdenadosVer(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        int x = Preferences.Get("NumeroMesa", 0);
        var ordenMesa = await _APIService.ObtenerOrdenMesa(x);
        List<PlatoOrden> platosaux= new List<PlatoOrden>(); 

        var PedidoVer = await _APIService.ObtenerPedido(ordenMesa.IdOrden);

        foreach (var p1 in PedidoVer)
        {
            if (p1.Cantidad > 0)
            {
                platosaux.Add(p1);
            }
        }
        platosListView.ItemsSource = platosaux;


    }

    private async void cancelarButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync();
    }
}