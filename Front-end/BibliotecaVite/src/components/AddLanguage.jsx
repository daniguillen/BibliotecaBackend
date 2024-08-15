import  { useState } from 'react';

const AddLanguage = () => {
    const [nombre, setNombre] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
    
        console.log('Agregando lenguaje:', { nombre });
    };

    return (
        <div className="admin-section">
            <h2>Agregar Lenguaje</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Nombre del Lenguaje"
                    value={nombre}
                    onChange={(e) => setNombre(e.target.value)}
                />
                <button type="submit">Agregar</button>
            </form>
        </div>
    );
}

export default AddLanguage;