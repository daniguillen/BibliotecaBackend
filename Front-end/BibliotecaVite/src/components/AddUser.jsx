import { useState } from 'react';

const AddUser = () => {
    const [nombre, setNombre] = useState('');
    const [email, setEmail] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
       
        console.log('Agregando usuario:', { nombre, email });
    };

    return (
        <div className="admin-section">
            <h2>Agregar Usuario</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="Nombre"
                    value={nombre}
                    onChange={(e) => setNombre(e.target.value)}
                />
                <input
                    type="email"
                    placeholder="Email"
                    value={email}
                    onChange={(e) => setEmail(e.target.value)}
                />
                <button type="submit">Agregar</button>
            </form>
        </div>
    );
}

export default AddUser;