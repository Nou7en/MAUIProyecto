using MAUIRESTAURANTE.Services;

namespace MAUIRESTAURANTE;

public partial class AntesDeEmpezar : ContentPage
{
    private readonly APIService _APIService;
    public AntesDeEmpezar(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }


    private async void ComenzarOrdenar_Clicked(object sender, EventArgs e)
    {
         await Navigation.PushModalAsync(new PaginaInicio(_APIService));
    }

    private async void SoyEmpleado_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new InicioSecion(_APIService));

    }
}