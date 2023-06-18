import React, {useState, useEffect} from 'react';
import Navbar from "../../Common/Navbar/Navbar";
import "./ProductosCompra.css";
import Label from "../../Common/Label/Label";
import DataTable , {createTheme} from 'react-data-table-component';
import data from "bootstrap/js/src/dom/data";

function ProductosCompra() {
    const [nombreprod, setNombreprod] = useState("");
    const [categoria, setCategoria] = useState("");
    const [fechacreacion, setFechacreacion] = useState("");
    const [localizacion, setLocalizacion] = useState("");
    const [nombrevend, setNombrevend] = useState("");
    const [estado, setEstado] = useState("");
    const [productos, setProductos] = useState([]);
    const [precio, setPrecio] = useState("");
    const [productosFilter, setProductosFilter] = useState([]);
    const clearFields = () => {
        setNombreprod("");
        setCategoria("");
        setFechacreacion("");
        setLocalizacion("");
        setNombrevend("");
        setEstado("");
        setPrecio("");
    };

    const URL = 'https://localhost:7232/productos'
    const showData = async () => {
        const response = await fetch(URL)
        const data= await response.json()
        setProductos(data);
    }

    const SamenombreprodCode = () => {
        const busquedaLowerCase = nombreprod.toLowerCase();
        const filteredProductos = productos.filter((producto) => {
            const nombreLowerCase = producto.nombreprod.toLowerCase();
            return nombreLowerCase.includes(busquedaLowerCase);
        });

        const filteredCategoria = filteredProductos.filter((filteredProducto) => {
            return filteredProducto.categoria === categoria || categoria === "TODO";
        });

        setProductosFilter(filteredCategoria);
    };
console.log(ProductosCompra);
console.log(productos)
    useEffect( ()=>{
        showData()
    }, [])


    const columns = [
        {
            name: 'Nombre',
            selector: row => row.nombreprod,
            sortable: true
        },
        {
            name: 'Categoria',
            selector: row => row.categoria,
            sortable: true
        },
        {
            name: 'Fecha de creacion',
            selector: row => row.fechacreacion,
            sortable: true
        },
        {
            name: 'Localizacion',
            selector: (row) => row.localizacion,
            sortable: true
        },
        {
            name: 'Estado',
            selector: row => row.estado,
            sortable: true
        },
        {
            name: 'Precio',
            selector: row => row.precio,
            sortable: true
        }
    ]
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
                            <option>Informatica</option>
                            <option>Herramientas</option>
                            <option>Estudio</option>
                            <option>Muebles</option>
                            <option>Vehiculos</option>
                            <option>Otros</option>
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

                    <button onClick={SamenombreprodCode}>Get Devices</button>
                    <br/>
                </div>
            </div>
            <br/>
            <div className="App">
                <DataTable
                    columns={columns}
                    data={productosFilter}
                    pagination
                />
            </div>
            <div className="parteabajo">
                <p>Hazte con el Premium para que no aparezcan anuncios y tus publicaciones sean mas visibles</p>
            </div>
        </div>
    );
}

export default ProductosCompra;