using MAUIRESTAURANTE.Models;
using MAUIRESTAURANTE.Services;

namespace MAUIRESTAURANTE;

public partial class PaginaInicio : ContentPage
{
    private readonly APIService _APIService;
    private Orden _Orden;

    public PaginaInicio(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;

    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }

    private async void OnclickOrden(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NewPage1(_APIService));
    }


}