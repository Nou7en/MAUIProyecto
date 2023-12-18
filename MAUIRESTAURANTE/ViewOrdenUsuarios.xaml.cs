using MAUIRESTAURANTE.Models;
using MAUIRESTAURANTE.Services;

namespace MAUIRESTAURANTE;

public partial class ViewOrdenUsuarios : ContentPage
{
    private readonly APIService _APIService;
    private Orden _Orden;
    public ViewOrdenUsuarios(APIService apiservice, Orden orden)
	{
		InitializeComponent();
        _APIService = apiservice;
        _Orden = orden;

    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        List<PlatoOrden> platosaux = new List<PlatoOrden>();
        var PedidoVer = await _APIService.ObtenerPedido(_Orden.IdOrden);

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
        await Navigation.PushModalAsync(new PaginaInicio(_APIService));
    }
}