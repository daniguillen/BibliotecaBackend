using ApiLibro.Interfaces;
using ApiLibro.Models;

namespace ApiLibro.Services
{
    public class LibroServices
    {
        private readonly ILibrosRepository _LibroRepository;
        public LibroServices(ILibrosRepository LibroRepository)
            {
                _LibroRepository = LibroRepository;
            }
        public dynamic AddLibro(Libro libro)
        {
            return _LibroRepository.addLibro(libro);
        }
        public Libro getBook(int id)
        {
            return _LibroRepository.GetLibro(id);
        }
        public List<Libro> getAllLibros()
        {
            return _LibroRepository.GetAllLibros();
        }
        public List<Editorial> getAllEditorials() {
            return _LibroRepository.GetAllEditorial();
        }
        public List<Autor> GetAllAutores()
        {
            return _LibroRepository.GetAllAutores();
        }
        public List<Pais> GetAllPaises()
        {
            return _LibroRepository.GetAllPaises();
        }
        public List<Sexo> GetAllSex()
        {
            return _LibroRepository.GetAllSex();
        }
        public List<Lenguaje> GetAllLenguaje()
        {
            return _LibroRepository.GetAllLenguaje();
        }
        public dynamic addEditorial(Editorial editorial)
        { 
            return _LibroRepository.addEditorial(editorial);
        }
        public dynamic addPais(Pais pais) { 
         return _LibroRepository.addPais(pais);

        }
        public dynamic addSex(Sexo sexo)
        {
            return _LibroRepository.addSex(sexo);

        }
        public dynamic addGenero(Genero genero)
        {
            return _LibroRepository.addGenero(genero);

        }
        public dynamic addLenguaje(Lenguaje lenguaje)
        {
            return _LibroRepository.addLenguaje(lenguaje);

        }
        public dynamic addAutor(Autor autor)
        {
            return _LibroRepository.addAutor(autor);

        }
    }
}
