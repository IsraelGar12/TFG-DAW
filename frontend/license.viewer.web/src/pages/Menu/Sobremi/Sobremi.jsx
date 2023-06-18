import Navbar from "../../Common/Navbar/Navbar";
import "./Sobremi.css"
import Label from "../../Common/Label/Label";

function Sobremi() {
    var name = localStorage.getItem('name');
    var birthDate = localStorage.getItem('birthDate');
    var phone = localStorage.getItem('phone');
    var address = localStorage.getItem('address');
    var email = localStorage.getItem('email');
    
    return (
            <div className="App">
                <Navbar />
                <div className="Contenedor_2">
                    <p>
                        <Label text="Fecha Nacimiento:" />
                        {birthDate}
                    </p>
                    <p>
                        <Label text="Nombre:" />
                        {name}
                    </p>
                    <p>
                        <Label text="Teléfono:" />
                        {phone}
                    </p>
                    <p>
                        <Label text="Dirección:" />
                        {address}
                    </p>
                    <p>
                        <Label text="Email:" />
                        {email}
                    </p>
            </div>
                <p>Actualmente no se pueden modificar los datos personales pero en un futuro lo implementaremos</p>
        </div>
    );
}

export default Sobremi;