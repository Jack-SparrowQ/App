using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Usuario : INotifyPropertyChanged
{
    private string nombre;
    private string correo;
    private string fotoUrl;
    private bool esVendedor;

    public string Nombre
    {
        get => nombre;
        set { nombre = value; OnPropertyChanged(); }
    }

    public string Correo
    {
        get => correo;
        set { correo = value; OnPropertyChanged(); }
    }

    public string FotoUrl
    {
        get => fotoUrl;
        set { fotoUrl = value; OnPropertyChanged(); }
    }

    public bool EsVendedor
    {
        get => esVendedor;
        set { esVendedor = value; OnPropertyChanged(); }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    void OnPropertyChanged([CallerMemberName] string propName = "") =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
}



