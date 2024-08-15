import  { useState } from 'react';

const AddBook = () => {
    const [titulo, setTitulo] = useState('');
    const [descripcion, setDescripcion] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        
        console.log('Agregando libro:', { titulo, descripcion });
    };

    return (
        <div className="admin-section">
            <h2>Agregar Libro</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Título"
                    value={titulo}
                    onChange={(e) => setTitulo(e.target.value)}
                />
                <textarea
                    placeholder="Descripción"
                    value={descripcion}
                    onChange={(e) => setDescripcion(e.target.value)}
                />
                <button type="submit">Agregar</button>
            </form>
        </div>
    );
}

export default AddBook;