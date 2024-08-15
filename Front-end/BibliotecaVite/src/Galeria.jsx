import { useState, useEffect } from 'react';
import './Galeria.css'; 
import Header from './components/Header';

import { Link } from 'react-router-dom';

export default function Api() {
    const [apiData, setApiData] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);
    const [currentPage, setCurrentPage] = useState(1);
    const [booksPerPage] = useState(8); // Número de libros por página

    useEffect(() => {
        const fetchData = async () => {
            try {
                const response = await fetch("https://localhost:7035/Books/AllBooks");
                
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }

                const data = await response.json();
                setApiData(data.result);
                setLoading(false); 
            } catch (err) {
                setError("Ha ocurrido un error: "+err);
                setLoading(false);
            }
        };

        fetchData(); 
    }, []); 

    if (loading) return <p>Loading...</p>; 
    if (error) return <p>Error: {error.message}</p>; 

    // Calcular los índices de los libros a mostrar en la página actual
    const indexOfLastBook = currentPage * booksPerPage;
    const indexOfFirstBook = indexOfLastBook - booksPerPage;
    const currentBooks = apiData.slice(indexOfFirstBook, indexOfLastBook);
    console.log(currentBooks)
    // Calcular el número total de páginas
    const totalPages = Math.ceil(apiData.length / booksPerPage);

    // Funciones para manejar la paginación
    const handleNextPage = () => {
        if (currentPage < totalPages) {
            setCurrentPage(currentPage + 1);
        }
    };

    const handlePrevPage = () => {
        if (currentPage > 1) {
            setCurrentPage(currentPage - 1);
        }
    };
    console.log(apiData)

    return (
        <>
            <Header 
                primero="/" 
              //  segundo="Administrar" 
              segundo="Contacto" 
              tercero="Administracion"   
            />
        <div className="containerGaleria">
            <h1 className="justify-content-center d-flex GaleriaLibros">Galería de Libros</h1>
            <div className="row">
                {currentBooks.map((book) => (
                    <div key={book.id} className="col-md-3 mb-4">
                        <div className="card" style={{ height: '100%' }}>
                        <Link to={`/Galeria/LibroDetalle/${book.id}`}>
                                <img 
                                    src={book.portada.url} 
                                    className="card-img-top" 
                                    alt={book.titulo} 
                                    style={{ 
                                        height: '200px', 
                                        objectFit: 'cover', // Cambié a cover para llenar el contenedor
                                        width: '100%' 
                                    }} 
                                />
                            </Link>  
                            <div className="card-body">
                                <h5 className="card-title">{book.titulo}</h5>
                                <p className="card-text">{book.descripcion}</p>
                            </div>
                        </div>
                    </div>
                ))}
            </div>
            <div className="d-flex justify-content-center ">
                <button 
                    className="btn btn-primary btn-custom" 
                    onClick={handlePrevPage} 
                    disabled={currentPage === 1}
                >
                    Anterior
                </button>
                <span className='align-items-md-center d-flex m-2'>Página {currentPage} de {totalPages}</span>
                <button 
                    className="btn btn-primary btn-custom" 
                    onClick={handleNextPage} 
                    disabled={currentPage === totalPages}
                >
                    Siguiente
                </button>
            </div>
        </div>

        </>
    );
}