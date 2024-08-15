import { useState } from 'react';

const AddPublisher = () => {
    const [nombre, setNombre] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        
        console.log('Agregando editorial:', { nombre });
    };

    return (
        <div className="admin-section">
            <h2>Agregar Editorial</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Nombre de la Editorial"
                    value={nombre}
                    onChange={(e) => setNombre(e.target.value)}
                />
                <button type="submit">Agregar</button>
            </form>
        </div>
    );
}

export default AddPublisher;