import React from 'react';
import logo from './logo.svg';
import './App.css';


//In order to call a component and it's functionality as well as render it from inside of another component, 
//we will import it. The component exports itself to make itself available for import across our app.
import ComponentOne from './Components/FunctionalComponentOne';

//This is our root component called App.  
//We will create our own components that we then nest inside of our call from App later on.
//Notice that App is a FUNCTIONAL conponent.  It's a typescript function that returns HTML (with some slight syntax differences)
//that is then rendered in the Browser.

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <h1>React ComponentOne Functional/Class Exercise 1</h1>
        <ComponentOne/>
     
      </header>
    </div>
  );
}

export default App;
