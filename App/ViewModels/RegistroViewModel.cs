using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System.Threading.Tasks;

namespace App.ViewModels
{
    public class RegistroViewModel : INotifyPropertyChanged
    {
        private string correo;
        public string Correo { get => correo; set { correo = value; OnPropertyChanged(); } }

        private string nombre;
        public string Nombre { get => nombre; set { nombre = value; OnPropertyChanged(); } }

        private string edad;
        public string Edad { get => edad; set { edad = value; OnPropertyChanged(); } }

        private string telefono;
        public string Telefono { get => telefono; set { telefono = value; OnPropertyChanged(); } }

        private string password;
        public string Password { get => password; set { password = value; OnPropertyChanged(); } }

        private string confirmarPassword;
        public string ConfirmarPassword { get => confirmarPassword; set { confirmarPassword = value; OnPropertyChanged(); } }

        public ICommand RegistrarCommand { get; }

        public RegistroViewModel()
        {
            RegistrarCommand = new Command(async () => await Registrar());
        }

        private async Task Registrar()
        {
            if (string.IsNullOrWhiteSpace(Correo) ||
                string.IsNullOrWhiteSpace(Nombre) ||
                string.IsNullOrWhiteSpace(Edad) ||
                string.IsNullOrWhiteSpace(Telefono) ||
                string.IsNullOrWhiteSpace(Password) ||
                string.IsNullOrWhiteSpace(ConfirmarPassword))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Por favor completa todos los campos.", "OK");
                return;
            }

            if (Password != ConfirmarPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden.", "OK");
                return;
            }

            // Aquí iría la lógica real de registro: guardar usuario en base de datos o servicio

            // Simulamos registro exitoso:
            await Application.Current.MainPage.DisplayAlert("Éxito", "Registro completado correctamente.", "OK");

            // Guardamos sesión (ejemplo)
            Preferences.Set("usuario_logeado", true);

            // Navegamos al Feed
            await Shell.Current.GoToAsync("//feed");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}


