using App.ViewModels;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace App.Views
{
    public partial class FeedPage : ContentPage, IQueryAttributable
    {
        public FeedPage()
        {
            InitializeComponent();
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("categoria", out var categoriaObj) && categoriaObj is string categoria)
            {
                if (BindingContext is FeedViewModel vm)
                {
                    if (vm.CambiarFiltro.CanExecute(categoria))
                        vm.CambiarFiltro.Execute(categoria);
                }
            }
        }

        private async void OnSeleccionPublicacion(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Models.Publicacion seleccionada)
            {
                await Shell.Current.GoToAsync($"detallepublicacion?publicacionId={seleccionada.Id}");
                ((CollectionView)sender).SelectedItem = null;
            }
        }

    }
}



