using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Threading.Tasks;
using App.Models;

namespace App.Services
{
    public class UsuarioService
    {
        public async Task<Usuario> ObtenerUsuarioAsync()
        {
            await Task.Delay(300);
            return new Usuario
            {
                Nombre = "María Pérez",
                Correo = "maria.perez@ejemplo.com",
                FotoUrl = "perfil.png"
            };
        }

        public async Task<List<Publicacion>> ObtenerPublicacionesDelUsuarioAsync()
        {
            await Task.Delay(500);
            return new List<Publicacion>
            {
                new Publicacion { Id = "u1", Titulo = "Mi bicicleta", Categoria = "Producto", ImagenUrl = "bicicleta.jpg", Precio = 1200, Calificacion = 4.7 },
                new Publicacion { Id = "u2", Titulo = "Clases de inglés", Categoria = "Servicio", ImagenUrl = "clases.jpg", Precio = 250, Calificacion = 4.9 }
            };
        }
    }
}

