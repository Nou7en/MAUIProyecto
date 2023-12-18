using MAUIRESTAURANTE.Services;

namespace MAUIRESTAURANTE
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            APIService apiService = new APIService();
            MainPage = new AntesDeEmpezar(apiService);
        }
    }
}
