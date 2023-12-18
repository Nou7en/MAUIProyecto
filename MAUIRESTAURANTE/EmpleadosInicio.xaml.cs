using MAUIRESTAURANTE.Models;
using MAUIRESTAURANTE.Services;

namespace MAUIRESTAURANTE;

public partial class EmpleadosInicio : ContentPage
{
    private readonly APIService _APIService;
    private Usuario _usuario;
    public EmpleadosInicio(APIService apiservice, Usuario usuario)
	{
		InitializeComponent();
        _APIService = apiservice;
        _usuario = usuario;
    }

    private async void CrearOrden_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new NewPage1(_APIService));
    }

    private async void Mesas_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ControlMesas(_APIService));
    }

    private async void CerrarSecion_Cliked(object sender, EventArgs e)
    {
        SecureStorage.Remove("Usuario");
        await Navigation.PopModalAsync();
    }
}