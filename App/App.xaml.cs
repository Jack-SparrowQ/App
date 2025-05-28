using App.Views;

namespace App;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // El MainPage será el Shell siempre
        MainPage = new NavigationPage(new Views.LoginPage());
    }
}
