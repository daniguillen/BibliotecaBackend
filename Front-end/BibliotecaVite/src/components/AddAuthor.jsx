import  { useState } from 'react';

const AddAuthor = () => {
    const [nombre, setNombre] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        
        console.log('Agregando autor:', { nombre });
    };

    return (
        <div className="admin-section">
            <h2>Agregar Autor</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Nombre del Autor"
                    value={nombre}
                    onChange={(e) => setNombre(e.target.value)}
                />
                <button type="submit">Agregar</button>
            </form>
        </div>
    );
}

export default AddAuthor;