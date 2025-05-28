using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.Models;
using App.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace App.ViewModels
{
    public class PerfilViewModel : INotifyPropertyChanged
    {
        private Usuario _usuario;
        public Usuario Usuario
        {
            get => _usuario;
            set { _usuario = value; OnPropertyChanged(); }
        }

        public ObservableCollection<Publicacion> MisPublicaciones { get; set; } = new();

        public ICommand GuardarCommand { get; }
        public ICommand SeleccionarFotoCommand { get; }
        public ICommand EliminarPublicacionCommand { get; }

        public PerfilViewModel()
        {
            GuardarCommand = new Command(GuardarCambios);
            SeleccionarFotoCommand = new Command(SeleccionarFoto);
            EliminarPublicacionCommand = new Command<Publicacion>(EliminarPublicacion);
            CargarDatos();
        }

        private async void CargarDatos()
        {
            var servicio = new UsuarioService();
            Usuario = await servicio.ObtenerUsuarioAsync();
            var publicaciones = await servicio.ObtenerPublicacionesDelUsuarioAsync();
            MisPublicaciones.Clear();
            foreach (var pub in publicaciones)
                MisPublicaciones.Add(pub);
        }

        private async void GuardarCambios()
        {
            await Application.Current.MainPage.DisplayAlert("Perfil actualizado",
                $"Nombre: {Usuario.Nombre}\nCorreo: {Usuario.Correo}", "OK");
        }

        private async void SeleccionarFoto()
        {
            var resultado = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Selecciona una foto de perfil"
            });

            if (resultado != null)
            {
                Usuario.FotoUrl = resultado.FullPath;
            }
        }

        private void EliminarPublicacion(Publicacion publicacion)
        {
            if (publicacion != null)
            {
                MisPublicaciones.Remove(publicacion);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}

