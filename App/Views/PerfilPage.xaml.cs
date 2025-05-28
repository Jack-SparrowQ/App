using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Views
{
    public partial class PerfilPage : ContentPage
    {
        public PerfilPage()
        {
            InitializeComponent();
        }
        private async void OnVolverAlFeedClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//feed");
        }

    }

}
