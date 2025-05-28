using App.ViewModels;
using Microsoft.Maui.Controls;

namespace App.Views
{
    [QueryProperty(nameof(PublicacionId), "publicacionId")]
    public partial class DetallePublicacionPage : ContentPage
    {
        public string PublicacionId { get; set; }

        public DetallePublicacionPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is DetallePublicacionViewModel vm && !string.IsNullOrEmpty(PublicacionId))
                await vm.CargarPorId(PublicacionId);
        }
        private async void OnContactarVendedorClicked(object sender, EventArgs e)
        {
            // Número del vendedor con código de país, por ejemplo México +52 1234567890
            var numeroTelefono = "+521234567890";

            // URL para abrir WhatsApp (usar wa.me o api.whatsapp.com)
            var url = $"https://wa.me/{numeroTelefono}";

            try
            {
                if (await Launcher.CanOpenAsync(url))
                {
                    await Launcher.OpenAsync(url);
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo abrir WhatsApp.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"Ocurrió un error: {ex.Message}", "OK");
            }
        }
    }
}

