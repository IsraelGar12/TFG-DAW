import React, { useState, useEffect } from 'react';
import Navbar from "../../Common/Navbar/Navbar";
import "./Servicios_y_Trabajos.css";
import Label from "../../Common/Label/Label";
import DataTable from 'react-data-table-component';

function Servicios() {
    const [nombreserv, setNombreserv] = useState("");
    const [categoria, setCategoria] = useState("");
    const [fechacreacion, setFechacreacion] = useState("");
    const [localizacion, setLocalizacion] = useState("");
    const [nombrevend, setNombrevend] = useState("");
    const [valoracion, setValoracion] = useState("");
    const [servicios, setServicios] = useState([]);
    const [serviciosFilter, setServiciosFilter] = useState([]);

    const clearFields = () => {
        setNombreserv("");
        setCategoria("");
        setFechacreacion("");
        setLocalizacion("");
        setNombrevend("");
        setValoracion("");
    };

    const URL = 'https://localhost:7232/servicios';

    const showData = async () => {
        const response = await fetch(URL);
        const data = await response.json();
        setServicios(data);
    };

    const SamenombreservCode = () => {
        const busquedaLowerCase = nombreserv.toLowerCase();
        const filteredServicios = servicios.filter((servicio) => {
            const nombreLowerCase = servicio.nombreserv.toLowerCase();
            return nombreLowerCase.includes(busquedaLowerCase);
        });

        const filteredCategoria = filteredServicios.filter((filteredServicio) => {
            return filteredServicio.categoria === categoria || categoria === "TODO";
        });

        setServiciosFilter(filteredCategoria);
    };

    useEffect(() => {
        showData();
    }, []);

    const columns = [
        {
            name: 'Nombre',
            selector: (row) => row.nombreserv,
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
            name: 'Localizacion',
            selector: (row) => row.localizacion,
            sortable: true
        },
        
        {
            name: 'Valoracion',
            selector: (row) => row.valoracion,
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
                        <Label text="Categoria:" />
                        <select
                            name="Environment"
                            placeholder=""
                            value={categoria}
                            id="categoria"
                            onChange={(e) => setCategoria(e.target.value)}
                        >
                            <option></option>
                            <option>TODO</option>
                            <option>Profesor Particular</option>
                            <option>Informatica</option>
                            <option>Hogar</option>
                            <option>Servicios de envio</option>
                            <option>Cuidado de mascotas</option>
                            <option>Cuidado de niños</option>
                            <option>Otros</option>
                        </select>
                    </div>

                    <div>
                        <Label text="Nombre:" />
                        <input
                            value={nombreserv}
                            id="nombreserv"
                            onChange={(e) => setNombreserv(e.target.value)}
                        />
                    </div>

                    TOTAL: {serviciosFilter.length}
                </div>

                <div className="Contenedor_der">
                    <button onClick={clearFields}>Clear filter</button>
                    <button onClick={SamenombreservCode}>Get Services</button>
                    <br />
                </div>
            </div>

            <br />

            <div className="App">
                <DataTable columns={columns} data={serviciosFilter} pagination />
            </div>

            <div className="parteabajo">
                <p>Hazte con el Premium para que no aparezcan anuncios y tus publicaciones sean más visibles</p>
            </div>
        </div>
    );
}

export default Servicios;
