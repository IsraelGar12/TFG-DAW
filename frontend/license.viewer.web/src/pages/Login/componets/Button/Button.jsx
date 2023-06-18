import React from "react";
import './Button.css';

const Button = ({ text,handleSubmit }) => {
    
    return (
        <div>
            <button onClick={ (e) => handleSubmit(e.target.name, e.target.value)} className='button-style'> {text} </button>
        </div>
    )
};

export default Button;