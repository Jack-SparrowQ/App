using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using App.Models;
using App.Services;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace App.ViewModels
{
    public class DetallePublicacionViewModel : INotifyPropertyChanged
    {
        private Publicacion _publicacion;
        public Publicacion Publicacion
        {
            get => _publicacion;
            set { _publicacion = value; OnPropertyChanged(); }
        }

        public ObservableCollection<string> Reseñas { get; set; } = new();

        private string _nuevaReseña;
        public string NuevaReseña
        {
            get => _nuevaReseña;
            set { _nuevaReseña = value; OnPropertyChanged(); }
        }

        public ICommand AgregarReseñaCommand { get; }

        public DetallePublicacionViewModel()
        {
            AgregarReseñaCommand = new Command(AgregarReseña);
        }

        public async Task CargarPorId(string id)
        {
            var servicio = new PublicacionService();
            var publicaciones = await servicio.ObtenerPublicacionesAsync();
            Publicacion = publicaciones.FirstOrDefault(p => p.Id == id);

            Reseñas.Clear();
            if (Publicacion?.Reseñas != null)
            {
                foreach (var reseña in Publicacion.Reseñas)
                    Reseñas.Add(reseña);
            }
        }

        private void AgregarReseña()
        {
            if (!string.IsNullOrWhiteSpace(NuevaReseña))
            {
                Reseñas.Add(NuevaReseña);
                Publicacion?.Reseñas?.Add(NuevaReseña); // solo si Resenas fue inicializado
                NuevaReseña = string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}

