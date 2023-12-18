using MAUIRESTAURANTE.Models;
using MAUIRESTAURANTE.Services;
using System.Collections.ObjectModel;

namespace MAUIRESTAURANTE;

public partial class DetalleFactura : ContentPage
{
    private readonly APIService _APIService;
    public DetalleFactura(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        int x = Preferences.Get("NumOrden", 0);
        List<PlatoOrden> listaplatos = await _APIService.ObtenerPedido(x);
        var platos = new ObservableCollection<PlatoOrden>(listaplatos);
        detalleOrden.ItemsSource = platos;
    }
}