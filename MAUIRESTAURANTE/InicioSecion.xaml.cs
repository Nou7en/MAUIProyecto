using MAUIRESTAURANTE.Models;
using MAUIRESTAURANTE.Models.Dto;
using MAUIRESTAURANTE.Services;
using Newtonsoft.Json;

namespace MAUIRESTAURANTE;

public partial class InicioSecion : ContentPage
{
    private readonly APIService _APIService;
    private Usuario _usuario;
    public InicioSecion(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        string storedJson = SecureStorage.GetAsync("Usuario").Result;

        if (storedJson != null)
        {

            _usuario = JsonConvert.DeserializeObject<Usuario>(storedJson);
            if (_usuario != null)
            {
                await Navigation.PushModalAsync(new EmpleadosInicio(_APIService, _usuario));
            }

        }

    }
    private async void IniciarSesion_Clicked(object sender, EventArgs e)
    {
        try
        {
            
            string username = UsuarioEntry.Text;
            string password = ContrasenaEntry.Text;

            

            // Verificar que ambos campos est�n llenos
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Por favor, completa todos los campos.", "Aceptar");
                return; // Salir del m�todo si no se completaron ambos campos
            }

            UsuarioCredencial usuarioCredencial = new UsuarioCredencial
            {
                NombreUsuario = username,
                Clave = password
            };

            Preferences.Set("Username", username);//Para mandar el preference
            //Preferences.Get("Username", "0");Para traer

            // Aqu� deber�as llamar a tu servicio API para realizar la autenticaci�n
            Usuario usuarioAutenticado = await _APIService.ValidarUsuario(usuarioCredencial);

            if (usuarioAutenticado != null)
            {
                string Usuario = JsonConvert.SerializeObject(usuarioAutenticado);
                SecureStorage.SetAsync("Usuario", Usuario);
                // Si la autenticaci�n es exitosa, navega a la p�gina principal
                await Navigation.PushModalAsync(new EmpleadosInicio(_APIService, _usuario));

            }
            else
            {
                // Muestra un mensaje de error si la autenticaci�n falla
                await DisplayAlert("Error", "Inicio de sesi�n fallido. Verifica tus credenciales.", "Aceptar");
            }
        }
        catch (Exception ex)
        {
            // Manejar cualquier excepci�n que pueda ocurrir durante el proceso de inicio de sesi�n
            await DisplayAlert("Error", $"Error al iniciar sesi�n: {ex.Message}", "Aceptar");
        }
    }


}