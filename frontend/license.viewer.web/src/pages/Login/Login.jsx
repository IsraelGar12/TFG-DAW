import { useState } from "react";
import { Route, useNavigate } from "react-router-dom";
import "./Login.css";
import Title from "./componets/Title/Title";
import Label from "../Common/Label/Label";
import axios from "axios";

function App() {
    const navigate = useNavigate();
    const [user_login, setUser_login] = useState("");
    const [isError, setIsError] = useState(false);
    const [password_login, setPassword_login] = useState("");

    const handleUsuario = (e) => {
        setUser_login(e.target.value);
    };

    const handlePassword = (e) => {
        setPassword_login(e.target.value);
    };

    const handleRegister = () => {
        navigate("/registro");
    };

    const handleApi = async () => {
        try {
            const res = await axios.post("https://localhost:7232/login", {
                user: user_login,
                password: password_login,
            });
            console.log(res.status);
            console.log(res.data);
            if (res.status === 200) {
                console.log(res.data.name);
                localStorage.setItem("name", res.data.name);
                localStorage.setItem("token", res.data.token);
                localStorage.setItem("email", res.data.email);
                localStorage.setItem("address", res.data.address);
                localStorage.setItem("phone", res.data.phone);
                localStorage.setItem("birthDate", res.data.birthDate);
                return navigate("/productos");
            }
        } catch (error) {
            console.log(error.response.data);
            setIsError(true);
        }
    };

    return (
        <div className="app">
            <Title text="Wallarock" />
            <div className="login-container">
                <h1>Login Usuario</h1>
                <Label text="Usuario:" />{" "}
                <input value={user_login} onChange={handleUsuario} type="text" />
                <br />
                <Label text="Contraseña:" />{" "}
                <input
                    value={password_login}
                    onChange={handlePassword}
                    type="password"
                />
                <br />
                {isError && (
                    <div className="errorpass">
                        El usuario o la contraseña es incorrecto o no es válido
                    </div>
                )}
                <div className="center-button">
                    <button className="login-button" onClick={handleApi}>
                        Iniciar Sesión
                    </button>
                </div>
            </div>
            <div className="center-button">
                <button className="register-button" onClick={handleRegister}>
                    Registrarse
                </button>
            </div>
        </div>
    );
}


export default App;
