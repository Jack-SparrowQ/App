using App.ViewModels;
using System.Text;
using System.Net.Http;

namespace App.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
        BindingContext = new LoginViewModel();
    }

    public async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        var client = new HttpClient();
        var json = @"{
                ""username"": """ + UsernamelEntry + @""",
                ""password"": """ + PasswordEntry + @"""
            }";
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = client.PostAsync("http://serveo.net:8081/login", content).Result;
            string responseBody = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                // Manejar el éxito del login
                await DisplayAlert("Éxito", "Login exitoso", "OK");
            }
            else
            {
                // Manejar el error del login
               // await DisplayAlert("Error", "Login fallido", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }
}
