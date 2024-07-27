#pragma warning disable CS8618

namespace ApiLibro.Models
{
    public class Libro
    {

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public int Anio { get; set; }
        public int Paginas { get; set; }

        
        public Autor Author { get; set; }

        public Editorial Editorial { get; set; }
        public Genero Genero { get; set; }
        
        public Portada Portada { get; set; }

        public Lenguaje Lenguage { get; set; }
    }
}
