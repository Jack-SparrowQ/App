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
    public class PublicacionService
    {
        public async Task<List<Publicacion>> ObtenerPublicacionesAsync()
        {
            await Task.Delay(1000); // Simula carga

            return new List<Publicacion>
            {
                new Publicacion
                {
                    Id = "1",
                    Titulo = "Tacos al pastor",
                    Categoria = "Comida",
                    ImagenUrl = "tacos.jpg",
                    Precio = 50,
                    Calificacion = 4.8,
                    EsDestacado = true
                },
                new Publicacion
                {
                    Id = "2",
                    Titulo = "Limpieza de jardín",
                    Categoria = "Servicio",
                    ImagenUrl = "jardin.jpg",
                    Precio = 150,
                    Calificacion = 4.2,
                    EsDestacado = false
                },
                new Publicacion
                {
                    Id = "3",
                    Titulo = "Set de juguetes",
                    Categoria = "Producto",
                    ImagenUrl = "juguetes.jpg",
                    Precio = 300,
                    Calificacion = 5.0,
                    EsDestacado = true
                }
                // Puedes agregar más publicaciones aquí
            };
        }

        public async Task<List<Anuncio>> ObtenerAnunciosAsync()
        {
            await Task.Delay(500); // Simula carga

            return new List<Anuncio>
            {
                new Anuncio
                {
                    Titulo = "Vacunación gratuita",
                    Contenido = "Consulta horarios en la web institucional.",
                    Link = "https://ejemplo.edu/vacunas"
                }
            };
        }

        public async Task<List<Reseña>> ObtenerReseñasPorPublicacionIdAsync(string publicacionId)
        {
            await Task.Delay(500); // Simula carga

            return new List<Reseña>
            {
                new Reseña { Usuario = "Juan", Comentario = "Muy bueno, recomendado.", Calificacion = 4.5 },
                new Reseña { Usuario = "Ana", Comentario = "Excelente calidad.", Calificacion = 5.0 },
                new Reseña { Usuario = "Carlos", Comentario = "Cumplió con lo prometido.", Calificacion = 4.0 }
            };
        }
    }
}

