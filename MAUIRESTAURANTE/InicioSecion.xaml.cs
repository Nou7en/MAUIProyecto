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

            

            // Verificar que ambos campos estén llenos
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Por favor, completa todos los campos.", "Aceptar");
                return; // Salir del método si no se completaron ambos campos
            }

            UsuarioCredencial usuarioCredencial = new UsuarioCredencial
            {
                NombreUsuario = username,
                Clave = password
            };

            Preferences.Set("Username", username);//Para mandar el preference
            //Preferences.Get("Username", "0");Para traer

            // Aquí deberías llamar a tu servicio API para realizar la autenticación
            Usuario usuarioAutenticado = await _APIService.ValidarUsuario(usuarioCredencial);

            if (usuarioAutenticado != null)
            {
                string Usuario = JsonConvert.SerializeObject(usuarioAutenticado);
                SecureStorage.SetAsync("Usuario", Usuario);
                // Si la autenticación es exitosa, navega a la página principal
                await Navigation.PushModalAsync(new EmpleadosInicio(_APIService, _usuario));

            }
            else
            {
                // Muestra un mensaje de error si la autenticación falla
                await DisplayAlert("Error", "Inicio de sesión fallido. Verifica tus credenciales.", "Aceptar");
            }
        }
        catch (Exception ex)
        {
            // Manejar cualquier excepción que pueda ocurrir durante el proceso de inicio de sesión
            await DisplayAlert("Error", $"Error al iniciar sesión: {ex.Message}", "Aceptar");
        }
    }


}