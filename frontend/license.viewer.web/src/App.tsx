import { useState } from 'react';
import './App.css';
import Login from "./pages/Login/Login"
import React from "react";
import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Sobremi from "./pages/Menu/Sobremi/Sobremi";
import ProductosCompra from "./pages/Menu/ProductosCompra/ProductosCompra";
import Servicios_y_Trabajos from "./pages/Menu/Servicios_y_Trabajos/Servicios_y_Trabajos";
import Videojuegos from "./pages/Menu/Videojuegos/Videojuegos";
import Nosotros from "./pages/Menu/Nosotros/Nosotros";
import Venta from "./pages/Menu/Venta/Venta";
import Dudas from "./pages/Menu/Dudas/Dudas";
import Registro from "./pages/Registro/Registro";
//import PrivateRoute from "../src/pages/Login/Extra/PrivateRoute";

function App() {
    return (
            <div className="container">
                <Routes>
                    <Route path="/sobremi" element={<Sobremi/>} />
                    <Route path="/registro" element={<Registro/>}/>
                    <Route path="/productos" element={<ProductosCompra/>} />
                    <Route path="/servicios" element={<Servicios_y_Trabajos/>} />
                    <Route path="/nosotros" element={<Nosotros/>} />
                    <Route path="/ventaprod" element={<Venta/>} />
                    <Route path="/videojuegos" element={<Videojuegos/>} />
                    <Route path="/dudas" element={<Dudas/>} />
                    <Route path="/" element={<Login/>} />
                </Routes>
		</div>
    );
}

export default App;