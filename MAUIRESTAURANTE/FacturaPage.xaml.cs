using MAUIRESTAURANTE.Models;
using MAUIRESTAURANTE.Services;
using System.Collections.ObjectModel;

namespace MAUIRESTAURANTE;

public partial class FacturaPage : ContentPage
{
    private Factura _Factura;
    private readonly APIService _APIService;
    public FacturaPage(APIService apiservice, Factura factura)
    {
        InitializeComponent();
        _APIService = apiservice;
        _Factura = factura;
    }



    protected async override  void OnAppearing() {
        base.OnAppearing();
        fecha.Text=_Factura.fecha.ToString();
        nombre.Text=_Factura.nombre.ToString();
        ci.Text=_Factura.cedula.ToString();
        direccion.Text=_Factura.direccion.ToString();

        List<PlatoOrden> platosaux= new List<PlatoOrden>();
        double totalfac =0;

        var platos = await _APIService.ObtenerPedido(_Factura.idOrden);
        
        foreach (var p1 in platos)
        {
            if (p1.Cantidad > 0)
            {
                platosaux.Add(p1);
                double aux = p1.Precio * p1.Cantidad;
                totalfac = totalfac + aux;
                total.Text = totalfac.ToString();
            }
        }
        platosListView.ItemsSource = platosaux;


    }

    private async void Finalizar_Clicked(object sender, EventArgs e)
    {
       int num=  Preferences.Get("NumeroMesa",0);
        await _APIService.CambiarEstadoMesa(num);
        await Navigation.PushModalAsync( new ControlMesas(_APIService));
    }
}