import React, { useState } from "react";
import "./Navbar.css";
import { Route, useNavigate  } from "react-router-dom";


function Navbar() {

    var user = localStorage.getItem('name');
    const navigate = useNavigate();
    const [active, setActive] = useState("nav__menu");
    const [icon, setIcon] = useState("nav__toggler");
    if(localStorage.key("token")==null){
        return navigate('/');
    }else {
    const navToggle = () => {
        if (active === "nav__menu") {
            setActive("nav__menu nav__active");
        } else setActive("nav__menu");

        // Icon Toggler
        if (icon === "nav__toggler") {
            setIcon("nav__toggler toggle");
        } else setIcon("nav__toggler");
    };
    

        //window.onbeforeunload = function () {
        //    localStorage.removeItem("token");
        //    localStorage.removeItem("username");
        //    return '';
        //};
        const handleLogout = () => {
            localStorage.removeItem("name");
            localStorage.removeItem("token");
            return navigate('/');
        }
        return (
            <nav className="nav">
                <nav className="nav_superior">
                    <div>
                    <a href="" className="nav__brand">
                    Wallarock
                    </a>
                    </div>
                    Bienvenido {user}
                    <div className="center-button">
                    <button className="boton-cerrar" onClick={handleLogout}>Cerrar Sesión</button>
                </div>
                </nav>
                <nav className="nav_inferior">
                    <ul className={active}>
                        <li className="nav__item">
                            <a href="productos" className="nav__link">
                                Comprar Productos
                            </a>
                        </li>
                        <li className="nav__item">
                            <a href="servicios" className="nav__link">
                                Servicios y Trabajos
                            </a>
                        </li>
                        <li className="nav__item">
                            <a href="videojuegos" className="nav__link">
                                Compra de Videojuegos
                            </a>
                        </li>
                        <li className="nav__item">
                            <a href="ventaprod" className="nav__link">
                                Venta de Productos o Servicios
                            </a>
                        </li>
                        <li className="nav__item">
                            <a href="nosotros" className="nav__link">
                                Sobre Nosotros
                            </a>
                        </li>
                        <li className="nav__item">
                            <a href="dudas" className="nav__link">
                                Preguntanos cualquier duda
                            </a>
                        </li>
                        <li className="nav__item">
                            <a href="sobremi" className="nav__link">
                                Sobre mi
                            </a>
                        </li>
                    </ul>
                    
                    <div onClick={navToggle} className={icon}>
                        <div className="line1"></div>
                        <div className="line2"></div>
                        <div className="line3"></div>
                    </div>
                </nav>
            </nav>
        );
    }
}
export default Navbar;