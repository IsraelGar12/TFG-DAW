import React from "react";

import './Select.css';

const Select = ( {attribute, handleChange} ) => {
    return(
        <div>
            <select
                name={attribute.name}
                placeholder={attribute.placeholder}
                value={attribute.environment}
                id={attribute.id}
                onChange={ (e)=>handleChange(e.target.value) }
                Option={text}
            />
            
        </div>
    )
};

export default Select;
