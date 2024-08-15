import { useState, useEffect } from 'react';
import { useParams } from 'react-router-dom';
import Header from '../components/Header';
import './LibroDetalle.css';
import { Link } from 'react-router-dom';
export function LibroDetalle() {
    const { id } = useParams();
    const [book, setBook] = useState(null);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        const fetchBookData = async () => {
            try {
                const response = await fetch(`https://localhost:7035/Books/IdBook?id=${id}`);
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }
                const data = await response.json();
                setBook(data.result);
                setLoading(false);
            } catch (err) {
                setError("Ha ocurrido un error: " + err);
                setLoading(false);
            }
        };

        fetchBookData();
    }, [id]);

    if (loading) return <p>Loading...</p>;
    if (error) return <p>Error: {error}</p>;

    return (
        <>
            <Header 
                primero="/" 
              //  segundo="Administrar" 
                tercero="Contacto" 
            />
            <div className="libro-detalle-container align-content-center">
                {book && (
                    <>
                        <h1 className="libro-detalle-titulo">{book.titulo}</h1>
                        <div className="libro-detalle-info">
                            <img 
                                src={book.portada.url} 
                                alt={book.titulo} 
                                className="libro-detalle-portada"
                            />
                            <div className="libro-detalle-texto">
                                <p><strong>Descripción:</strong> {book.descripcion}</p>
                                <p><strong>Año:</strong> {book.anio}</p>
                                <p><strong>Páginas:</strong> {book.paginas}</p>
                                <p><strong>Autor:</strong> {book.author.nombre}</p>
                                <p><strong>Editorial:</strong> {book.editorial.nombre}</p>
                                <p><strong>Género:</strong> {book.genero.name}</p>
                                <p><strong>Idioma:</strong> {book.lenguage.name}</p>
                            </div>

                        </div>
                        <Link to="/Galeria" className='justify-content-center d-flex mt-5'>
                        <button className="btn btn-primary btn-lg btn-custom">Volver</button>
                    </Link>
                    </>
                )}
            </div>
        </>
    );
}