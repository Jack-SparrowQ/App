using App.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using Microsoft.Maui.Dispatching;  // Para MainThread

namespace App;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("login", typeof(LoginPage));
        Routing.RegisterRoute("feed", typeof(FeedPage));
        Routing.RegisterRoute("detallepublicacion", typeof(DetallePublicacionPage));
        Routing.RegisterRoute("perfil", typeof(PerfilPage));
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        bool usuarioLogueado = Preferences.Get("usuario_logeado", false);

        if (!usuarioLogueado)
        {
            // Navegar a login si no está logueado
            await Shell.Current.GoToAsync("//login");
        }
        else
        {
            // Si ya está logueado, ir al feed
            await Shell.Current.GoToAsync("//feed");
        }
    }

    private async void OnCategoriaClicked(object sender, EventArgs e)
    {
        if (sender is MenuItem item && item.CommandParameter is string categoria)
        {
            await Shell.Current.GoToAsync($"//feed?categoria={categoria}");
        }
    }

    private async void OnVerAnunciosClicked(object sender, EventArgs e)
    {
        await Shell.Current.DisplayAlert("Anuncios", "Aquí puedes mostrar una vista con anuncios.", "OK");
    }

    private async void OnCerrarSesionClicked(object sender, EventArgs e)
    {
        Preferences.Set("usuario_logeado", false);
        await Shell.Current.GoToAsync("//login");
    }
}



