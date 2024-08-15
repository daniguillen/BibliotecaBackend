import AddBook from './components/AddBook';
import DeleteBook from './components/DeleteBook';
import AddUser from './components/AddUser';
import DeleteUser from './components/DeleteUser';
import AddAuthor from './components/AddAuthor';
import AddCountry from './components/AddCountry';
import AddPublisher from './components/AddPublisher';
import DeletePublisher from './components/DeletePublisher';
import AddLanguage from './components/AddLanguage';
import DeleteLanguage from './components/DeleteLanguage';
import Header from './components/Header';
import Swal from 'sweetalert2';

import './Administracion.css';
import { useState } from 'react'
import { Link } from 'react-router-dom';

const Administracion = () => {
    const [datosLibro, setDatosLibro] = useState({
      nombre: '',
      anio: '',
      autor: '',
      imagen: ''
    });


    const showSwal = () => {
      Swal.fire({
        title: 'Ingrese los detalles del libro',
        html: `
          <label class="mt-3" for="nombreLibro">Nombre del libro:</label><br/>
          <input id="nombreLibro" class="swal2-input" placeholder="Nombre del libro" /><br/>
          <label class="mt-3" for="anioLibro">Año del libro:</label><br/>
          <input type="number" min="1800" max="2024" id="anioLibro" class="swal2-input" placeholder="Año" /><br/>
          <label class="mt-3" for="autorLibro">Autor del libro:</label><br/>
          <input id="autorLibro" class="swal2-input" placeholder="Autor del libro" /><br/>
          <label class="mt-3" for="imagenLibro">URL de la imagen:</label><br/>
          <input id="imagenLibro" class="swal2-input" placeholder="URL de la imagen" /><br/>
        `,
        focusConfirm: false,
        preConfirm: () => {
          const nombre = Swal.getPopup().querySelector('#nombreLibro').value;
          const anio = Swal.getPopup().querySelector('#anioLibro').value;
          const autor = Swal.getPopup().querySelector('#autorLibro').value;
          const imagen = Swal.getPopup().querySelector('#imagenLibro').value;

          if (!nombre || !anio || !autor || !imagen) {
            Swal.showValidationMessage('Por favor ingrese todos los campos');
            return false;
          }
          if (isNaN(anio)  || anio<1800 || anio>2024 ) {
            Swal.showValidationMessage('Ingrese un año valido');
            return false;
          }


          return { nombre, anio, autor, imagen };
        },
        icon: 'info',
        showCancelButton: true,
        confirmButtonText: 'Guardar!',
        cancelButtonText: 'Cancelar',
      }).then((result) => {
        if (result.isConfirmed) {
          const { nombre, anio, autor, imagen } = result.value;
          setDatosLibro({
            nombre,
            anio,
            autor,
            imagen
          });
          Swal.fire('Confirmado!', `Nombre: ${nombre}, Año: ${anio}, Autor: ${autor}, Imagen: ${imagen}`, 'success');

        } else if (result.isDismissed) {
          Swal.fire('Cancelado', 'Has elegido cancelar.', 'error');
        }
      });
    };


    return (
        <>
            <Header 
                primero="/" 
                segundo="Salir" 
                
            />
            <>
            </>


              <h1>Panel de Administración</h1>
          <div className="admin-dashboard">
              <div className="admin-panels">
                  <div className="admin-panel">
                      <h2>Agregar Libro</h2>
            <button onClick={showSwal}>Agregar libro</button>
                   
                  </div>
                  <div className="admin-panel">
                      <h2>Eliminar Libro</h2>
                      <Link to={`EliminarLibro`} ><button>Eliminar Libro</button></Link>
                  </div>
                  <div className="admin-panel">
                      <h2>Agregar Usuario</h2>
                      <AddUser />
                  </div>
                  <div className="admin-panel">
                      <h2>Eliminar Usuario</h2>
                      <DeleteUser />
                  </div>
                  <div className="admin-panel">
                      <h2>Agregar Autor</h2>
                      <AddAuthor />
                  </div>
                  <div className="admin-panel">
                      <h2>Agregar País</h2>
                      <AddCountry />
                  </div>
                  <div className="admin-panel">
                      <h2>Agregar Editorial</h2>
                      <AddPublisher />
                  </div>
                  <div className="admin-panel">
                      <h2>Eliminar Editorial</h2>
                      <DeletePublisher />
                  </div>
                  <div className="admin-panel">
                      <h2>Agregar Lenguaje</h2>
                      <AddLanguage />
                  </div>
                  <div className="admin-panel">
                      <h2>Eliminar Lenguaje</h2>
                      <DeleteLanguage />
                  </div>
              </div>
          </div>
        </>
    );
}

export default Administracion;