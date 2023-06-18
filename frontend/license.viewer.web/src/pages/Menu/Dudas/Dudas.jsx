import Navbar from "../../Common/Navbar/Navbar";
import "./Dudas.css"
import Label from "../../Common/Label/Label";
import Title from "../../Login/componets/Title/Title";


function Chargeable_Licenses() {
    return (
        <div className="App">
            <Navbar />
            <Title text='¿Tienes alguna duda?' />
            <div className="Contenedor_3">
                <p>¡Bienvenido a nuestra página de preguntas frecuentes! Estamos aquí para ayudarte a resolver cualquier duda o inquietud que puedas tener. Hemos recopilado una lista de preguntas comunes y sus respuestas correspondientes para brindarte la información que necesitas de manera rápida y sencilla. Si no encuentras la respuesta que buscas, no dudes en contactarnos a través de nuestro correo electrónico de soporte.</p><br/>
                <h3>1. **¿Cómo puedo crear una cuenta en nuestro sitio?**</h3>
                <p>   Para crear una cuenta en nuestro sitio, simplemente haz clic en el botón "Registrarse" o "Crear cuenta" ubicado en la esquina superior derecha de la página. Completa el formulario con la información requerida y sigue las instrucciones para activar tu cuenta.</p><br/>
                <h3>2. **¿Cómo puedo publicar un anuncio?**</h3>
                <p>   Publicar un anuncio es fácil. Inicia sesión en tu cuenta y selecciona la opción "Publicar anuncio" en el menú principal. Completa todos los detalles relevantes sobre tu producto o servicio y sube imágenes si es necesario. Una vez que hayas revisado y confirmado la información, tu anuncio estará activo y visible para otros usuarios.</p><br/>
                <h3>3. **¿Cuánto tiempo dura un anuncio publicado?**</h3>
                <p>   La duración de un anuncio puede variar. Generalmente, ofrecemos opciones de publicación por un período de tiempo específico, como 7, 14 o 30 días. Después de ese período, deberás renovar tu anuncio si aún deseas mantenerlo activo.</p><br/>
                <h3>4. **¿Cómo puedo contactar al vendedor o comprador de un artículo?**</h3>
                <p>   Puedes comunicarte con el vendedor o comprador de un artículo utilizando la función de mensajería interna de nuestro sitio. Cuando estés viendo un anuncio, verás un botón o enlace para enviar un mensaje al usuario correspondiente. Asegúrate de proporcionar la información relevante y estar atento a las respuestas en tu bandeja de entrada.</p><br/>
                <h3>5. **¿Cuáles son los métodos de pago aceptados?**</h3>
                <p>   Los métodos de pago aceptados pueden variar según el vendedor. Al comunicarte con el vendedor, podrás acordar el método de pago más conveniente para ambas partes. Algunos métodos comunes incluyen transferencias bancarias, pagos en efectivo, PayPal u otras plataformas de pago en línea.</p><br/>
                <p>Si no has encontrado la respuesta que estás buscando, no dudes en contactarnos a través de nuestro correo electrónico de soporte: [soporte@nuestrodominio.com](mailto:soporte@nuestrodominio.com). Nuestro equipo de atención al cliente estará encantado de ayudarte y responder a todas tus preguntas.

                    ¡Gracias por confiar en nosotros! Estamos aquí para brindarte una experiencia satisfactoria y resolver tus dudas en todo momento.</p>           
            </div>
        </div>
    );
}
export default Chargeable_Licenses;