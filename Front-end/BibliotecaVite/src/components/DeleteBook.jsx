import Header from '../components/Header'

function DeleteBook() {
  return (
    <>
    
    <Header
    segundo="Administracion" 
    tercero="Salir"   
    ></Header>
    <table className="table">
    <thead>
      <tr>
        <th scope="col" className="text-center">ID</th>
        <th scope="col" className="text-center">Nombre</th>
        <th scope="col" className="text-center">Autor</th>
        <th scope="col" className="text-center">Acciones</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <th className="text-center" scope="row">1</th>
        <td className="text-center">Mark</td>
        <td className="text-center">Otto</td>
        <td className="text-center"><button className="btn btn-danger text-center">Eliminar</button> <button className="btn btn-warning">Modificar</button>
        </td>
      </tr>
      
    </tbody>
  </table></>
  );
}

export default DeleteBook;