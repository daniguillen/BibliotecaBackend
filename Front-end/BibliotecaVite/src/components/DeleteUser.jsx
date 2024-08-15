import { useState } from 'react';

const DeleteUser = () => {
    const [userId, setUserId] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        // Aquí iría la lógica para eliminar el usuario de la base de datos
        console.log('Eliminando usuario con ID:', userId);
    };

    return (
        <div className="admin-section">
            <h2>Eliminar Usuario</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="ID del Usuario"
                    value={userId}
                    onChange={(e) => setUserId(e.target.value)}
                />
                <button type="submit">Eliminar</button>
            </form>
        </div>
    );
}

export default DeleteUser;