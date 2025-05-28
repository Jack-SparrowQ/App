using App.ViewModels;

namespace App.Views;

public partial class RegistroPage : ContentPage
{
    public RegistroPage()
    {
        InitializeComponent();
        BindingContext = new RegistroViewModel();  
    }
}
