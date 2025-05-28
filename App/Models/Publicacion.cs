using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Models
{
    public class Publicacion
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Categoria { get; set; } // Comida, Servicio, Producto
        public string Descripcion { get; set; }
        public string ImagenUrl { get; set; }
        public decimal Precio { get; set; }
        public double Calificacion { get; set; }
        public bool EsDestacado { get; set; }
        public string TelefonoVendedor { get; set; }
        public List<string> Reseñas { get; set; } = new();
    }
}

