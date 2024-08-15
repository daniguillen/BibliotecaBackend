import  { useState } from 'react';

const AddCountry = () => {
    const [nombre, setNombre] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        
        console.log('Agregando país:', { nombre });
    };

    return (
        <div className="admin-section">
            <h2>Agregar País</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Nombre del País"
                    value={nombre}
                    onChange={(e) => setNombre(e.target.value)}
                />
                <button type="submit">Agregar</button>
            </form>
        </div>
    );
}

export default AddCountry;