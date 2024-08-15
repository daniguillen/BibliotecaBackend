import  { useState } from 'react';

const DeleteLanguage = () => {
    const [languageId, setLanguageId] = useState('');

    const handleSubmit = (e) => {
        e.preventDefault();
        // Aquí iría la lógica para eliminar el lenguaje de la base de datos
        console.log('Eliminando lenguaje con ID:', languageId);
    };

    return (
        <div className="admin-section">
            <h2>Eliminar Lenguaje</h2>
            <form onSubmit={handleSubmit}>
                <input
                    type="text"
                    placeholder="ID del Lenguaje"
                    value={languageId}
                    onChange={(e) => setLanguageId(e.target.value)}
                />
                <button type="submit">Eliminar</button>
            </form>
        </div>
    );
}

export default DeleteLanguage;