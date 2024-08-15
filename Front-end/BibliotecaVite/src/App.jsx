import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import './App.css'
import Index from './webs/Index'
import Galeria from './webs/Galeria';
import Footer from './components/Footer';
import { LibroDetalle } from './webs/LibroDetalle';
import Administracion from './Administracion';
import DeleteBook from './components/DeleteBook';
import DeleteUser from './components/DeleteUser';

function App() {

  return (
    <>
     <Router>
        <Routes>
          <Route path="/" element={<Index />} />
          <Route path="/Galeria" element={<Galeria />} />
          <Route path="/Galeria/LibroDetalle/:id" element={<LibroDetalle />} />
          <Route path="/Administracion" element={<Administracion/>} />
          <Route path="/Administracion/EliminarLibro" element={<DeleteBook/>} />
          <Route path="/Administracion/EliminarUsuario" element={<DeleteUser/>} />
          <Route path="/Administracion/EliminarAutor"  />
          <Route path="/Administracion/EliminarLenguaje"  />
          <Route path="/Administracion/EliminarEditorial"  />

        </Routes>
      </Router>
      <Footer/>
    </>
  )
}

export default App
