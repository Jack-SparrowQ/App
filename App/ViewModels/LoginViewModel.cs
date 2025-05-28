using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System.Threading.Tasks;
using System.Diagnostics;


namespace App.ViewModels;

public class LoginViewModel : INotifyPropertyChanged
{
    private string nombre;
    public string Nombre
    {
        get => nombre;
        set { nombre = value; OnPropertyChanged(); }
    }

    private string password;
    public string Password
    {
        get => password;
        set { password = value; OnPropertyChanged(); }
    }

    public ICommand LoginCommand { get; }
    public ICommand RegisterCommand { get; }

    public LoginViewModel()
    {
        LoginCommand = new Command(async () => await Login());
        RegisterCommand = new Command(async () => await Register());
    }

    private async Task Login()
    {
        if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Password))
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Por favor completa todos los campos.", "OK");
            return;
        }

        // Validación simulada
        /*
        if (nombre != "" && password !="")
        {
            Preferences.Set("usuario_logeado", true);

            // Navegar a FeedPage tras login exitoso
            await Shell.Current.GoToAsync("//feed");
        }
        else
        {
            await Application.Current.MainPage.DisplayAlert("Error", "Usuario o contraseña incorrectos.", "OK");
        }
        */
        var client = new HttpClient();
        var json = @"{
                ""username"": """ + Nombre + @""",
                ""password"": """ + Password + @"""
            }";
        var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
        try
        {
            var response = await client.PostAsync("http://serveo.net:8081/login", content);
            string responseBody = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                // Manejar el éxito del login
                Preferences.Set("usuario_logeado", true);
                Application.Current.MainPage = new AppShell();
            }
            else
            {
                // Manejar el error del login
                //await Application.Current.MainPage.DisplayAlert("Error", "Login fallido. Verifica tus credenciales.", "OK");
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }
        

    private async Task Register()
    {
        // Navegar a la página de registro si está registrada en AppShell
        await Shell.Current.GoToAsync("registro");
    }


    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string propName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
}




