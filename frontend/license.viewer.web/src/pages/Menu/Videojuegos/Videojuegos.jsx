import React, { useState, useEffect } from 'react';
import Navbar from "../../Common/Navbar/Navbar";
import "./Videojuegos.css";
import Label from "../../Common/Label/Label";
import DataTable from 'react-data-table-component';

function Videojuegos() {
    const [nombreprod, setNombreprod] = useState("");
    const [categoria, setCategoria] = useState("");
    const [productos, setProductos] = useState([]);
    const [productosFilter, setProductosFilter] = useState([]);

    const clearFields = () => {
        setNombreprod("");
        setCategoria("");
    };

    const URL = 'https://localhost:7232/videojuegos?nombreprod=';

    const showData = async () => {
        try {
            const response = await fetch(URL);
            const data = await response.json();
            console.log(data);
            setProductos(data);
        } catch (error) {
            console.error("Error al obtener los datos:", error);
        }
    };

    const filterProductos = () => {
        const busquedaLowerCase = nombreprod.toLowerCase();

        if (Array.isArray(productos)) {
            const filteredProductos = productos.filter((producto) => {
                const nombreLowerCase = producto.nombreprod.toLowerCase();
                const categoriaLower = categoria.toLowerCase();
                return (
                    nombreLowerCase.includes(busquedaLowerCase) &&
                    (categoriaLower === "todo" || categoriaLower === producto.categoria.toLowerCase())
                );
            });

            setProductosFilter(filteredProductos);
        }
    };


    useEffect(() => {
        showData();
    }, []);

    const columns = [
        {
            name: 'Nombre',
            selector: (row) => row.nombreprod,
            sortable: true
        },
        {
            name: 'Categoria',
            selector: (row) => row.categoria,
            sortable: true
        },
        {
            name: 'Fecha de creacion',
            selector: (row) => row.fechacreacion,
            sortable: true
        },
        {
            name: 'Estado',
            selector: (row) => row.estado,
            sortable: true
        },
        {
            name: 'Localizacion',
            selector: (row) => row.localizacion,
            sortable: true
        },
        {
            name: 'Precio',
            selector: (row) => row.precio,
            sortable: true
        }
    ];

    return (
        <div className="App">
            <Navbar />
            <div className="Contenedor_1">
                <div className="Contenedor_izq">
                    <div>
                        <Label text="Plataforma:" />
                        <select
                            name="Environment"
                            placeholder=""
                            value={categoria}
                            id="categoria"
                            onChange={(e) => setCategoria(e.target.value)}
                        >
                            <option></option>
                            <option>TODO</option>
                            <option>PS4</option>
                            <option>PS5</option>
                            <option>PC</option>
                            <option>Switch</option>
                            <option>Xbox SerieX</option>
                            <option>Xbox One</option>
                        </select>
                    </div>
                    <div>
                        <Label text="Nombre:" />
                        <input
                            value={nombreprod}
                            id="nombreprod"
                            onChange={(e) => setNombreprod(e.target.value)}
                        />
                    </div>
                    TOTAL: {productosFilter.length}
                </div>
                <div className="Contenedor_der">
                    <button onClick={clearFields}>
                        Clear filter
                    </button>
                    <button onClick={filterProductos}>Get Devices</button>
                    <br />
                </div>
            </div>
            <br />
            <div className="App">
                <DataTable
                    columns={columns}
                    data={productosFilter}
                    pagination
                />
            </div>
            <div className="parteabajo">
                <p>Hazte con el Premium para que no aparezcan anuncios y tus publicaciones sean más visibles</p>
            </div>
        </div>
    );
}

export default Videojuegos;
