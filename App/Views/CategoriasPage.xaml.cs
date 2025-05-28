using Microsoft.Maui.Controls;
using System;

namespace App.Views
{
    public partial class CategoriasPage : ContentPage
    {
        public CategoriasPage()
        {
            InitializeComponent();
        }

        private async void OnCategoriaClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string categoria)
            {
                // Navegar a Feed con la categoría como parámetro
                await Shell.Current.GoToAsync($"feed?categoria={categoria}");
            }
        }
    }
}

