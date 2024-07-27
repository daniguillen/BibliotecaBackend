using ApiLibro.Interfaces;
using ApiLibro.Models;
using ApiLibro.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ApiLibro.Controllers
{
    [ApiController]
    [Route("Books")]
    public class LibrosControllers : ControllerBase
    {
        private readonly LibroServices _libroServices;

        public LibrosControllers(LibroServices libroServices)
        {
            _libroServices = libroServices;
        }

        [HttpGet]
        [Route("AllBooks")]
        public dynamic AllBooks()
        {
            List<Libro> LibroList = _libroServices.getAllLibros(); 
            return new
            {
                success = true,
                message = "all books here",
                result = LibroList
            };
        }

        [HttpGet]
        [Route("AllAutores")]
        public dynamic AllAutores()
        {
            List<Autor> LibroList = _libroServices.GetAllAutores();
            return new
            {
                success = true,
                message = "all books here",
                result = LibroList
            };
        }

        [HttpGet]
        [Route("AllPais")]
        public dynamic AllPais()
        {
            List<Pais> LibroList = _libroServices.GetAllPaises();
            return new
            {
                success = true,
                message = "all books here",
                result = LibroList
            };
        }
        [HttpGet]
        [Route("Allsex")]
        public dynamic AllSex()
        {
            List<Sexo> LibroList = _libroServices.GetAllSex();
            return new
            {
                success = true,
                message = "all books here",
                result = LibroList
            };
        }
        [HttpGet]
        [Route("AllLenguaje")]
        public dynamic AllLenguaje()
        {
            List<Lenguaje> LibroList = _libroServices.GetAllLenguaje();
            return new
            {
                success = true,
                message = "all books here",
                result = LibroList
            };
        }

        [HttpGet]
        [Route("IdBook")]
        public dynamic OneBook([FromQuery] int id)
        {
            Libro libro = _libroServices.getBook(id);
            return new
            {
                success = true,
                message = "Book details",
                result = libro
            };
        }
        [HttpPost]
        [Route("addBook")]
        public dynamic AddBook([FromBody] Libro libro)
        {
            List<Libro> libros = new List<Libro>();
            libros = _libroServices.getAllLibros();
            var result = libros.FirstOrDefault(x => x.Titulo.ToLower() == libro.Titulo.ToLower());
            if (result != null)
            {

                return new
                {
                    success = false,
                    message = "YA esta registrado el libro intente con otro",
                    result = libro
                };
            }
            Libro nuevo = _libroServices.AddLibro(libro).result;
            return new
            {
                success = true,
                message = "Agregado",
                result = nuevo
            };
        }

        [HttpPost]
        [Route("addAuthor")]
        public dynamic AddAuthor([FromBody] Autor autor)
        {
            List<Autor> autors = new List<Autor>();
            autors = _libroServices.GetAllAutores();
            var result = autors.FirstOrDefault(x => x.Nombre.ToLower() == autor.Nombre.ToLower());
            if (result != null)
            {

                return new
                {
                    success = false,
                    message = "YA esta registrado el autor intente con otro",
                    result = autor
                };
            }
            Autor nuevo = _libroServices.addAutor(autor).result;
            return new
            {
                success = true,
                message = "Agregado",
                result = nuevo
            };
        }
        [HttpPost]
        [Route("addCountry")]
        public dynamic AddCountry([FromBody] Pais pais)
        {
            List<Pais> paises = new List<Pais>();
            paises = _libroServices.GetAllPaises();
            var result = paises.FirstOrDefault(x => x.Name.ToLower() == pais.Name.ToLower());
            if (result != null)
            {

                return new
                {
                    success = false,
                    message = "YA esta registrado el pais intente con otro",
                    result = pais
                };
            }
            Pais nuevo = _libroServices.addPais(pais).result;
            return new
            {
                success = true,
                message = "Agregado",
                result = nuevo
            };
        }
        [HttpPost]
        [Route("addEditorial")]
        public dynamic AddEditorial([FromBody] Editorial editorial)
        {
            List<Editorial> editorials = new List<Editorial>();
            editorials = _libroServices.getAllEditorials();
            var result = editorials.FirstOrDefault(x => x.Nombre.ToLower() == editorial.Nombre.ToLower());
            if (result != null)
            {

                return new
                {
                    success = false,
                    message = "YA esta registrado el editorial intente con otro",
                    result = editorial
                };
            }
            Editorial nuevo = _libroServices.addEditorial(editorial).result;
            return new
            {
                success = true,
                message = "Agregado",
                result = nuevo
            };
        }
        [HttpPost]
        [Route("addSex")]
        public dynamic AddSex([FromBody] Sexo sexo)
        {
            List<Sexo> sexos    = new List<Sexo>();
            sexos = _libroServices.GetAllSex();
            var result = sexos.FirstOrDefault(x => x.Name.ToLower() == sexo.Name.ToLower());
            if (result != null)
            {

                return new
                {
                    success = false,
                    message = "YA esta registrado el sexo intente con otro",
                    result = sexo
                };
            }

            Sexo nuevo = _libroServices.addSex(sexo).result;
            return new
            {
                success = true,
                message = "Agregado",
                result = nuevo
            };
        }
        [HttpPost]
        [Route("addLanguage")]
        public dynamic Addlanguage([FromBody] Lenguaje lenguaje)
        {
            List<Lenguaje> lenguajes = new List<Lenguaje>();

            lenguajes = _libroServices.GetAllLenguaje();
            

            var result = lenguajes.FirstOrDefault(x => x.Name.ToLower() == lenguaje.Name.ToLower());
            if (result != null) {

                return new
                {
                    success = false,
                    message = "YA esta registrado el lenguaje intente con otro",
                    result = lenguaje
                };
            }

            Lenguaje nuevo = _libroServices.addLenguaje(lenguaje).result;

            return new
            {
                success = true,
                message = "Agregado",
                result = nuevo
            };
        }

    }
}
