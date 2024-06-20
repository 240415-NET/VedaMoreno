//import React (allows access to all teh React Library mehtods, which may or may not be used)
//Also, import something called useState which is a "hook" (hooks are how functional compoenents 
//can memorize and pass information related to their 'state' 
//State refers to the changes or updates based on oUser interaction

import React, {useState} from 'react';

//Declare our Functional component definition.
//other option of declaring functional component definition: const ComponentOne: React.FC = () => {  }.  
function ComponentOne() {

    const [count, setCount] = useState(0);

    const increment = () => setCount(count + 1);

    const decrement = () => setCount(count - 1);

    //to render, once we create our variables for state, we can bring in whatever arguments from outside our 
    //component we need, create functions to do things based on those inputs, etc. 
    //We will create a return where our HTML will be rendered and written.
    return (
        <div>
            <h3>This is my newly created ComponentOne function-component</h3>
            {/* This is a comment inside of my TSX file's HTML.  This will not render.
            */}
            <br />
            {/*Inside of return component, it expects HTML.  
            We can break out of our HTML and call upon TypeScript by using braces {}*/}
            <p>Count: {count}</p>            
        </div>

    );

}
//whatever syntax for writing out TypeScript function for our component, we must remember to export it at the end
//This makes it visible across our application.
export default ComponentOne;
