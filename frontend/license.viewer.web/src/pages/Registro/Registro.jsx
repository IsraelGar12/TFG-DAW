import { useState } from "react";
import { useNavigate } from "react-router-dom";
import Title from "../Login/componets/Title/Title";
import Label from "../Common/Label/Label";
import axios from "axios";

function Registro() {
    const navigate = useNavigate();
    const [registerData, setRegisterData] = useState({
        nameUser: "",
        password: "",
        name: "",
        email: "",
        role: "",
        address: "",
        phone: "",
        birthDate: "",
    });
    const handleLogin = () => {
        navigate("/");
    };
    const handleInputChange = (e) => {
        setRegisterData({
            ...registerData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = async () => {
        try {
            const res = await axios.post(
                "https://localhost:7232/login/register",
                registerData
            );
            console.log(res.status);
            console.log(res.data);
            if (res.status === 200) {
                navigate("/");
            }
        } catch (error) {
            console.log(error.response.data);
        }
    };

    return (
        <div className="app">
            <Title text="Wallarock" />
            <div className="login-container">
                <h1>Registro de Usuario</h1>
                <Label text="Usuario:" />
                <input
                    name="nameUser"
                    value={registerData.nameUser}
                    onChange={handleInputChange}
                    type="text"
                />
                <br />
                <Label text="Contraseña:" />
                <input
                    name="password"
                    value={registerData.password}
                    onChange={handleInputChange}
                    type="password"
                />
                <br />
                <Label text="Nombre:" />
                <input
                    name="name"
                    value={registerData.name}
                    onChange={handleInputChange}
                    type="text"
                />
                <br />
                <Label text="Email:" />
                <input
                    name="email"
                    value={registerData.email}
                    onChange={handleInputChange}
                    type="text"
                />
                <br />
                <Label text="Rol:" />
                <input
                    name="role"
                    value={registerData.role}
                    onChange={handleInputChange}
                    type="text"
                />
                <br />
                <Label text="Dirección:" />
                <input
                    name="address"
                    value={registerData.address}
                    onChange={handleInputChange}
                    type="text"
                />
                <br />
                <Label text="Teléfono:" />
                <input
                    name="phone"
                    value={registerData.phone}
                    onChange={handleInputChange}
                    type="text"
                />
                <br />
                <Label text="Fecha de Nacimiento:" />
                <input
                    name="birthDate"
                    value={registerData.birthDate}
                    onChange={handleInputChange}
                    type="text"
                />
                <br />
                <button onClick={handleSubmit}>Registrarse</button>
                <button onClick={handleLogin}>Volver al Login</button>
            </div>
        </div>
    );
}

export default Registro;
