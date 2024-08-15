import { Link } from 'react-router-dom';
import './Main.css'; 

function Main() {
    return (
        <>
        <main className="container-main align-content-center">
            <div className="row">
                <div className="col-md-8 offset-md-2 text-center">
                    <h1 className="display-4 mb-4">Bienvenido a Nuestra Biblioteca</h1>
                    <p className="lead mb-4">
                        Explora una amplia colección de libros, desarrollados con ASP.NET Core 8 para el backend, y React con Vite para el frontend.
                    </p>
                    <Link to="/Galeria">
                        <button className="btn btn-primary btn-lg btn-custom">Entrar</button>
                    </Link>
                </div>
            </div>
        </main>
        </>
    );
}

export default Main;