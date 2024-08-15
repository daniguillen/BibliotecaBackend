using ApiLibro.Models;

namespace ApiLibro.Interfaces
{
    public interface ILibrosRepository
    {
        Libro GetLibro(int id);
        dynamic addLibro(Libro libro);
        List<Libro> GetAllLibros();
        List<Editorial> GetAllEditorial();
        List<Autor> GetAllAutores();
        List<Pais> GetAllPaises();
        List<Sexo> GetAllSex();
        List<Lenguaje> GetAllLenguaje();
        dynamic addEditorial(Editorial editorial);
        dynamic addPais(Pais pais);
        dynamic addSex(Sexo sexo);
        dynamic addGenero(Genero genero);
        dynamic addLenguaje(Lenguaje lenguaje);
        dynamic addAutor(Autor autor);


    }
}
