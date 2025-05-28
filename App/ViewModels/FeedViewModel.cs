using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using App.Models;
using App.Services;
using Microsoft.Maui.Controls;

namespace App.ViewModels
{
    public class FeedViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Publicacion> Publicaciones { get; set; } = new();
        public ObservableCollection<Publicacion> Destacadas { get; set; } = new();
        public ObservableCollection<Anuncio> Anuncios { get; set; } = new();

        private string _busqueda;
        public string Busqueda
        {
            get => _busqueda;
            set
            {
                _busqueda = value;
                OnPropertyChanged();
                FiltrarPublicaciones();
            }
        }

        private string _filtroCategoria = "Todos";
        public string FiltroCategoria
        {
            get => _filtroCategoria;
            set
            {
                _filtroCategoria = value;
                OnPropertyChanged();
                FiltrarPublicaciones();
            }
        }

        private List<Publicacion> _todasLasPublicaciones;

        public Command CambiarFiltro { get; }

        public FeedViewModel()
        {
            CambiarFiltro = new Command<string>(categoria =>
            {
                FiltroCategoria = categoria;
            });

            CargarDatos();
        }

        private async void CargarDatos()
        {
            var servicio = new PublicacionService();
            _todasLasPublicaciones = await servicio.ObtenerPublicacionesAsync();

            Publicaciones.Clear();
            foreach (var pub in _todasLasPublicaciones)
                Publicaciones.Add(pub);

            Destacadas.Clear();
            foreach (var dest in _todasLasPublicaciones.Where(p => p.EsDestacado))
                Destacadas.Add(dest);

            var anuncios = await servicio.ObtenerAnunciosAsync();
            Anuncios.Clear();
            foreach (var a in anuncios)
                Anuncios.Add(a);
        }

        private void FiltrarPublicaciones()
        {
            if (_todasLasPublicaciones == null) return;

            var filtradas = _todasLasPublicaciones
                .Where(p =>
                    (FiltroCategoria == "Todos" || p.Categoria == FiltroCategoria) &&
                    (string.IsNullOrWhiteSpace(Busqueda) || p.Titulo.Contains(Busqueda, StringComparison.OrdinalIgnoreCase)))
                .ToList();

            Publicaciones.Clear();
            foreach (var pub in filtradas)
                Publicaciones.Add(pub);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}


