using ApiLibro.Conexiones;
using ApiLibro.Interfaces;
using ApiLibro.Models;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Collections.Generic;

namespace ApiLibro.Repository.Libros
{
    public class LibroRepository : ILibrosRepository
    {

        private readonly ConexionBD _conexionBD;
        public LibroRepository(ConexionBD conexionBD)
        {
            _conexionBD = conexionBD;

        }
        public Libro GetLibro(int id)
        {


            Libro libro = new Libro();
            try
            {
                _conexionBD.setearQuery("SELECT * FROM book B INNER JOIN Language L ON b.IdLanguage = L.Id INNER JOIN Genrer G ON g.Id = b.IdGenrer INNER JOIN Cover C ON c.Id = b.IdCover INNER JOIN Author A ON a.Id = b.IdAuthor INNER JOIN Editorial E ON e.Id = b.IdEditorial");
                _conexionBD.ejecutarLectura();

                if (_conexionBD.Lector.Read())
                {
                    Autor autor = new Autor();
                    Editorial editorial = new Editorial();
                    Genero genero = new Genero();
                    Portada portada = new Portada();
                    Lenguaje lenguaje = new Lenguaje();

                    libro.Id = _conexionBD.Lector.GetInt32(0);
                    libro.Titulo = _conexionBD.Lector.GetString(1);
                    libro.Descripcion = _conexionBD.Lector.GetString(2);
                    portada.Id = _conexionBD.Lector.GetInt32(3);
                    portada.Url = _conexionBD.Lector.GetString(16);
                    editorial.Id = _conexionBD.Lector.GetInt32(4);
                    editorial.Nombre = _conexionBD.Lector.GetString(23);
                    genero.Id = _conexionBD.Lector.GetInt32(5);
                    genero.Name = _conexionBD.Lector.GetString(14);
                    autor.Id = _conexionBD.Lector.GetInt32(6);
                    autor.Nombre = _conexionBD.Lector.GetString(18);
                    lenguaje.Id = _conexionBD.Lector.GetInt32(7);
                    lenguaje.Name = _conexionBD.Lector.GetString(12);

                    libro.Anio = _conexionBD.Lector.GetInt32(8);
                    libro.Paginas = _conexionBD.Lector.GetInt32(9);

                    libro.Author = autor;
                    libro.Editorial = editorial;
                    libro.Genero = genero;
                    libro.Portada = portada;
                    libro.Lenguage = lenguaje;


                }
            }
            catch (Exception ex)
            {




                Libro libroEx = new Libro();
                libroEx.Titulo = "Ocurrio un error";
                libroEx.Descripcion = ex.ToString();

                return libroEx;
            }
            finally
            {

                _conexionBD.cerrarConexion();
            }

            return libro;
        }
        public dynamic addLibro(Libro libro)
        {
            bool estado;
            string mensaje;

            try
            {
                _conexionBD.setearQuery("EXEC cargarBook @Title = @titulo, @Description = @descripcion, @Img = @url, @IdEditorial = @IDeditorial, @IdGenrer = @IDgenero, @IdAuthor = @IDautor, @IdLanguage = @IdLenguaje, @Year = @Anio, @NumberPages = @NumberoPaginas;");
                _conexionBD.setearParametro("@titulo", libro.Titulo);
                _conexionBD.setearParametro("@descripcion", libro.Descripcion);
                _conexionBD.setearParametro("@url", libro.Portada.Url);
                _conexionBD.setearParametro("@IDeditorial", libro.Editorial.Id);
                _conexionBD.setearParametro("@IDgenero", libro.Genero.Id);
                _conexionBD.setearParametro("@IDautor", libro.Author.Id);
                _conexionBD.setearParametro("@IdLenguaje", libro.Lenguage.Id);
                _conexionBD.setearParametro("@Anio", libro.Anio);
                _conexionBD.setearParametro("@NumberoPaginas", libro.Paginas);
                _conexionBD.ejecutarLectura();
                estado = true;
                mensaje = "Agregado";
            }
            catch (Exception ex)
            {
                estado = false;
                mensaje = "error:" + ex;
            }
            finally
            {

                _conexionBD.cerrarConexion();
            }


            return new
            {
                succes = estado,
                message = mensaje,
                result = libro

            };

        }
        public List<Libro> GetAllLibros()
        {
            List<Libro> libros = new List<Libro>();

            try
            {
                _conexionBD.setearQuery("SELECT * FROM book B INNER JOIN Language L ON b.IdLanguage = L.Id INNER JOIN Genrer G ON g.Id = b.IdGenrer INNER JOIN Cover C ON c.Id = b.IdCover INNER JOIN Author A ON a.Id = b.IdAuthor INNER JOIN Editorial E ON e.Id = b.IdEditorial");
                _conexionBD.ejecutarLectura();

                while (_conexionBD.Lector.Read())
                {
                    Libro libro = new Libro();
                    Autor autor = new Autor();
                    Editorial editorial = new Editorial();
                    Genero genero = new Genero();
                    Portada portada = new Portada();
                    Lenguaje lenguaje = new Lenguaje();

                    libro.Id = _conexionBD.Lector.GetInt32(0);
                    libro.Titulo = _conexionBD.Lector.GetString(1);
                    libro.Descripcion = _conexionBD.Lector.GetString(2);
                    portada.Id = _conexionBD.Lector.GetInt32(3);
                    portada.Url = _conexionBD.Lector.GetString(16);
                    editorial.Id = _conexionBD.Lector.GetInt32(4);
                    editorial.Nombre = _conexionBD.Lector.GetString(23);
                    genero.Id = _conexionBD.Lector.GetInt32(5);
                    genero.Name = _conexionBD.Lector.GetString(14);
                    autor.Id = _conexionBD.Lector.GetInt32(6);
                    autor.Nombre = _conexionBD.Lector.GetString(18);
                    lenguaje.Id = _conexionBD.Lector.GetInt32(7);
                    lenguaje.Name = _conexionBD.Lector.GetString(12);

                    libro.Anio = _conexionBD.Lector.GetInt32(8);
                    libro.Paginas = _conexionBD.Lector.GetInt32(9);

                    libro.Author = autor;
                    libro.Editorial = editorial;
                    libro.Genero = genero;
                    libro.Portada = portada;
                    libro.Lenguage = lenguaje;

                    libros.Add(libro);
                }
            }
            catch (Exception ex)
            {



                List<Libro> nuevo = new List<Libro>();
                Libro libroEx = new Libro();
                libroEx.Titulo = "Ocurrio un error";
                libroEx.Descripcion = ex.ToString();
                nuevo.Add(libroEx);
                return nuevo;
            }
            finally
            {

                _conexionBD.cerrarConexion();
            }

            return libros;
        }
        public List<Editorial> GetAllEditorial()
        {
            List<Editorial> editorials = new List<Editorial>();

            try
            {
                _conexionBD.setearQuery("select * from editorial");
                _conexionBD.ejecutarLectura();

                while (_conexionBD.Lector.Read())
                {

                    Editorial editorial = new Editorial();
                    editorial.Id = _conexionBD.Lector.GetInt32(0);
                    editorial.Nombre = _conexionBD.Lector.GetString(1);
                    editorial.estado = _conexionBD.Lector.GetBoolean(2);

                    editorials.Add(editorial);
                }
            }
            catch (Exception ex)
            {



                List<Editorial> nuevo = new List<Editorial>();
                Editorial editorialEx = new Editorial();
                editorialEx.Nombre = "Ocurrio un error" + ex.ToString(); ;

                nuevo.Add(editorialEx);
                return nuevo;
            }
            finally
            {

                _conexionBD.cerrarConexion();
            }

            return editorials;
        }
        public List<Autor> GetAllAutores()
        {
            List<Autor> Autores = new List<Autor>();

            try
            {
                _conexionBD.setearQuery("select * from Author A inner join Sex S on s.Id=a.IdSex inner join Country C on c.Id = A.IdCountry");
                _conexionBD.ejecutarLectura();

                while (_conexionBD.Lector.Read())
                {

                    Autor autor = new Autor();
                    autor.Id = _conexionBD.Lector.GetInt32(0);
                    autor.Nombre = _conexionBD.Lector.GetString(1);
                    autor.Sexo.Id = _conexionBD.Lector.GetInt32(2);
                    autor.Pais.Id = _conexionBD.Lector.GetInt32(3);
                    autor.Sexo.Name = _conexionBD.Lector.GetString(6);
                    autor.Pais.Name = _conexionBD.Lector.GetString(8);
                    autor.estado = _conexionBD.Lector.GetBoolean(9);

                    Autores.Add(autor);
                }
            }
            catch (Exception ex)
            {



                List<Autor> nuevo = new List<Autor>();
                Autor autorEx = new Autor();
                autorEx.Nombre = "Ocurrio un error" + ex.ToString(); ;

                nuevo.Add(autorEx);
                return nuevo;
            }
            finally
            {

                _conexionBD.cerrarConexion();
            }

            return Autores;
        }
        public List<Pais> GetAllPaises()
        {
            List<Pais> paises = new List<Pais>();

            try
            {
                _conexionBD.setearQuery("select * from Country");
                _conexionBD.ejecutarLectura();

                while (_conexionBD.Lector.Read())
                {

                    Pais pais = new Pais();
                    pais.Id = _conexionBD.Lector.GetInt32(0);
                    pais.Name = _conexionBD.Lector.GetString(1);


                    paises.Add(pais);
                }
            }
            catch (Exception ex)
            {



                List<Pais> nuevo = new List<Pais>();
                Pais PaisEx = new Pais();
                PaisEx.Name = "Ocurrio un error" + ex.ToString(); ;

                nuevo.Add(PaisEx);
                return nuevo;
            }
            finally
            {

                _conexionBD.cerrarConexion();
            }

            return paises;
        }
        public List<Sexo> GetAllSex()
        {
            List<Sexo> sexo = new List<Sexo>();

            try
            {
                _conexionBD.setearQuery("select * from Sex");
                _conexionBD.ejecutarLectura();

                while (_conexionBD.Lector.Read())
                {

                    Sexo sex = new Sexo();
                    sex.Id = _conexionBD.Lector.GetInt32(0);
                    sex.Name = _conexionBD.Lector.GetString(1);


                    sexo.Add(sex);
                }
            }
            catch (Exception ex)
            {



                List<Sexo> nuevo = new List<Sexo>();
                Sexo SexoEx = new Sexo();
                SexoEx.Name = "Ocurrio un error" + ex.ToString(); ;

                nuevo.Add(SexoEx);
                return nuevo;
            }
            finally
            {

                _conexionBD.cerrarConexion();
            }

            return sexo;
        }
        public List<Lenguaje> GetAllLenguaje()
        {
            List <Lenguaje> Lenguajes = new List<Lenguaje>();

            try
            {
                _conexionBD.setearQuery("select * from Language");
                _conexionBD.ejecutarLectura();

                while (_conexionBD.Lector.Read())
                {

                    Lenguaje lenguaje = new Lenguaje();
                    lenguaje.Id = _conexionBD.Lector.GetInt32(0);
                    lenguaje.Name = _conexionBD.Lector.GetString(1);


                    Lenguajes.Add(lenguaje);
                }
            }
            catch (Exception ex)
            {



                List<Lenguaje> nuevo = new List<Lenguaje>();
                Lenguaje LenguajeEx = new Lenguaje();
                LenguajeEx.Name = "Ocurrio un error" + ex.ToString(); ;

                nuevo.Add(LenguajeEx);
                return nuevo;
            }
            finally
            {

                _conexionBD.cerrarConexion();
            }

            return Lenguajes;
        }
        public dynamic addEditorial(Editorial editorial)
        {
            bool estado;
            string mensaje;

            try
            {
                _conexionBD.setearQuery("insert into editorial (name) values(@name)");
                _conexionBD.setearParametro("@name", editorial.Nombre);
                _conexionBD.ejecutarLectura();
                estado = true;
                mensaje = "Agregado";
            }
            catch (Exception ex)
            {
                estado = false;
                mensaje = "error:" + ex;
            }
            finally
            {
                _conexionBD.cerrarConexion();
            }

            return new
            {
                succes = estado,
                message = mensaje,
                result = editorial

            };

        }
        public dynamic addLenguaje(Lenguaje lenguaje)
        {
            bool estado;
            string mensaje;

            try
            {
                _conexionBD.setearQuery("insert into Language (name) values(@name)");
                _conexionBD.setearParametro("@name", lenguaje.Name);
                _conexionBD.ejecutarLectura();
                estado = true;
                mensaje = "Agregado";
            }
            catch (Exception ex)
            {
                estado = false;
                mensaje = "error:" + ex;
            }
            finally
            {
                _conexionBD.cerrarConexion();
            }

            return new
            {
                succes = estado,
                message = mensaje,
                result = lenguaje

            };

        }
        public dynamic addSex(Sexo sexo)
        {
            bool estado;
            string mensaje;

            try
            {
                _conexionBD.setearQuery("insert into sex (sex) values(@name)");
                _conexionBD.setearParametro("@name", sexo.Name);
                _conexionBD.ejecutarLectura();
                estado = true;
                mensaje = "Agregado";
            }
            catch (Exception ex)
            {
                estado = false;
                mensaje = "error:" + ex;
            }
            finally
            {
                _conexionBD.cerrarConexion();
            }

            return new
            {
                succes = estado,
                message = mensaje,
                result = sexo

            };

        }
        public dynamic addGenero(Genero genero)
        {
            bool estado;
            string mensaje;

            try
            {
                _conexionBD.setearQuery("insert into genrer (name) values(@name)");
                _conexionBD.setearParametro("@name", genero.Name);
                _conexionBD.ejecutarLectura();
                estado = true;
                mensaje = "Agregado";
            }
            catch (Exception ex)
            {
                estado = false;
                mensaje = "error:" + ex;
            }
            finally
            {
                _conexionBD.cerrarConexion();
            }

            return new
            {
                succes = estado,
                message = mensaje,
                result = genero

            };

        }
        public dynamic addPais(Pais pais)
        {
            bool estado;
            string mensaje;

            try
            {
                _conexionBD.setearQuery("insert into Country (name) values(@name)");
                _conexionBD.setearParametro("@name", pais.Name);
                _conexionBD.ejecutarLectura();
                estado = true;
                mensaje = "Agregado";
            }
            catch (Exception ex)
            {
                estado = false;
                mensaje = "error:" + ex;
            }
            finally
            {
                _conexionBD.cerrarConexion();
            }

            return new
            {
                succes = estado,
                message = mensaje,
                result = pais
            };

        }
        public dynamic addAutor(Autor Autor)
        {
            bool estado;
            string mensaje;

            try
            {
                _conexionBD.setearQuery("insert into Author (name, IdSex, IdCountry) values(@name,@idSex,@idCountry)");
                _conexionBD.setearParametro("@name", Autor.Nombre);
                _conexionBD.setearParametro("@idSex", Autor.Sexo.Id);
                _conexionBD.setearParametro("@idCountry", Autor.Pais.Id);
                _conexionBD.ejecutarLectura();
                estado = true;
                mensaje = "Agregado";
            }
            catch (Exception ex)
            {
                estado = false;
                mensaje = "error:" + ex;
            }
            finally
            {
                _conexionBD.cerrarConexion();
            }

            return new
            {
                succes = estado,
                message = mensaje,
                result = Autor
            };

        }

       
    }

}
