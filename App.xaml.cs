namespace AppContactos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Establece ContactoPage como la pantalla principal dentro de NavigationPage
            MainPage = new NavigationPage(new ContactoPage());
        }
    }
}
