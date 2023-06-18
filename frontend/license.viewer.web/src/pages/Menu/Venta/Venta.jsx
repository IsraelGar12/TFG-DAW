import React, { useState } from 'react';
import axios from 'axios';
import { v4 as uuidv4 } from 'uuid'; // Importar la función v4 de la biblioteca uuid
import Navbar from "../../Common/Navbar/Navbar";
import "./Venta.css";
import Label from "../../Common/Label/Label";

const AgregarItem = () => {
    const [tipo, setTipo] = useState("");
    const [nombreprod, setNombreprod] = useState("");
    const [categoria, setCategoria] = useState("");
    const [localizacion, setLocalizacion] = useState("");
    const [nombrevend, setNombrevend] = useState("");
    const [estado, setEstado] = useState("");
    const [precio, setPrecio] = useState("");
    const [fechacreacion, setFechacreacion] = useState("");

    const handleSubmit = async (e) => {
        e.preventDefault();

        const data = {
            idvideo: uuidv4(), // Generar un valor único para idvideo
            nombreprod,
            categoria,
            fechacreacion,
            localizacion,
            nombrevend,
            estado,
            precio
        };

        try {
            if (tipo === "videojuego") {
                await axios.post('https://localhost:7232/videojuegos', data);
                alert('El videojuego se ha agregado correctamente');
            } else if (tipo === "producto") {
                await axios.post('https://localhost:7232/productos', data);
                alert('El producto se ha agregado correctamente');
            }
        } catch (error) {
            console.error('Error al agregar el item:', error.message);
            alert('Ocurrió un error al agregar el item');
        }

        setTipo("");
        setNombreprod("");
        setCategoria("");
        setLocalizacion("");
        setFechacreacion("");
        setNombrevend("");
        setEstado("");
        setPrecio("");
    };

    const commonFields = (
        <div>
            <div>
                <Label text="Nombre:" />
                <input
                    type="text"
                    value={nombreprod}
                    onChange={(e) => setNombreprod(e.target.value)}
                />
            </div>
            <div>
                <Label text="Categoría:" />
                <input
                    type="text"
                    value={categoria}
                    onChange={(e) => setCategoria(e.target.value)}
                />
            </div>
            <div>
                <Label text="Localización:" />
                <input
                    type="text"
                    value={localizacion}
                    onChange={(e) => setLocalizacion(e.target.value)}
                />
            </div>
            <div>
                <Label text="Nombre del Vendedor (ID Usuario):" />
                <input
                    type="text"
                    value={nombrevend}
                    onChange={(e) => setNombrevend(e.target.value)}
                />
            </div>
            <div>
                <Label text="Estado:" />
                <input
                    type="text"
                    value={estado}
                    onChange={(e) => setEstado(e.target.value)}
                />
            </div>
            <div>
                <Label text="Precio:" />
                <input
                    type="text"
                    value={precio}
                    onChange={(e) => setPrecio(e.target.value)}
                />
            </div>
        </div>
    );

    const renderFormFields = () => {
        if (tipo === "videojuego") {
            return (
                <div>
                    {commonFields}
                    <div>
                        <Label text="Fecha de Creación:" />
                        <input
                            type="text"
                            value={fechacreacion}
                            onChange={(e) => setFechacreacion(e.target.value)}
                        />
                    </div>
                </div>
            );
        } else if (tipo === "servicio") {
            return (
                <div>
                    {commonFields}
                    <div>
                        <Label text="Valoración:" />
                        <input
                            type="text"
                            value={estado}
                            onChange={(e) => setEstado(e.target.value)}
                        />
                    </div>
                </div>
            );
        } else if (tipo === "producto") {
            return (
                <div>
                    {commonFields}
                    <div>
                        <Label text="Fecha de Creación:" />
                        <input
                            type="text"
                            value={fechacreacion}
                            onChange={(e) => setFechacreacion(e.target.value)}
                        />
                    </div>
                </div>
            );
        } else {
            return null;
        }
    };

    return (
        <div className="App">
            <Navbar />
            <div className="Contenedor">
                <div className="Formulario">
                    <h1>Agregar Item</h1>
                    <form onSubmit={handleSubmit}>
                        <div>
                            <Label text="Tipo de Item:" />
                            <select value={tipo} onChange={(e) => setTipo(e.target.value)}>
                                <option value="">Seleccionar</option>
                                <option value="videojuego">Videojuego</option>
                                <option value="servicio">Servicio</option>
                                <option value="producto">Producto</option>
                            </select>
                        </div>
                        <div>
                            {renderFormFields()}
                        </div>
                        <div className="center-button">
                            <button className="button" type="submit">Guardar</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default AgregarItem;

