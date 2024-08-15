import  { useState } from 'react';

const DeletePublisher = () => {
    const [publisherId, setPublisherId] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        // Aquí iría la lógica para eliminar la editorial de la base de datos
        console.log('Eliminando editorial con ID:', publisherId);
    };

    return (
        <div className="admin-section">
            <h2>Eliminar Editorial</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="ID de la Editorial"
                    value={publisherId}
                    onChange={(e) => setPublisherId(e.target.value)}
                />
                <button type="submit">Eliminar</button>
            </form>
        </div>
    );
}

export default DeletePublisher;