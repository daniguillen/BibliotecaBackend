import PropTypes from 'prop-types';
import { Link } from 'react-router-dom';
import './Header.css';

function Header({ primero, segundo, tercero }) {
if(primero==null && segundo==null && tercero==null){

    return(<ul className="nav header justify-content-center justify-content-left headerPrincipal">
       <h2 className='text-white '>Biblioteca </h2>
    </ul>)
}
    return (
        <ul className="nav header justify-content-left headerPrincipal">
            <li className="nav-item">             
                {
                    primero ? (
                        <Link className="nav-link active" aria-current="page" to="/">
                            Inicio
                        </Link>
                    ) : null
                }        
            </li>
            <li className="nav-item align-content-center">               
                {
                    segundo ? (
                        <Link className="nav-link active" aria-current="page" to={"/"+segundo}>
                            {segundo}
                        </Link>
                    ) : null
                }
            </li>
            <li className="nav-item align-content-center">
                {
                   tercero ? (
                    <Link className="nav-link active" aria-current="page" to={"/"+tercero}>
                        {tercero}
                    </Link>
                ) : null
                }
            </li>
            
        </ul>
    );
}

Header.propTypes = {
    primero: PropTypes.string.isRequired,
    segundo: PropTypes.string.isRequired,
    tercero: PropTypes.string.isRequired,
    cuarto: PropTypes.string.isRequired,
};
export default Header;