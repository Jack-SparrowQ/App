using App.ViewModels;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http.Headers;

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
        var username = UsernamelEntry.Text?.Trim();
        var password = PasswordEntry.Text?.Trim();

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Error", "Por favor, completa todos los campos", "OK");
            return;
        }

        var client = new HttpClient();
        var json = JsonConvert.SerializeObject(new
        {
            username = username,
            password = password
        });

        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync("http://serveo.net:8081/login", content);
            string responseBody = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                // Aquí se asume que el servidor devuelve un token JWT o similar
                var responseJson = JsonConvert.DeserializeObject<LoginResponse>(responseBody);

                if (!string.IsNullOrEmpty(responseJson?.token))
                {
                    await SecureStorage.SetAsync("auth_token", responseJson.token);
                    Application.Current.MainPage = new AppShell(); // Entrar a la app con menú
                }
                else
                {
                    await DisplayAlert("Error", "Respuesta del servidor no contiene token", "OK");
                }
            }
            else
            {
                await DisplayAlert("Error", "Credenciales inválidas", "OK");
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
        }
    }

    public class LoginResponse
    {
        public string token { get; set; }
        // Puedes agregar más campos si tu backend devuelve más datos
    }
}
