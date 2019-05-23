import React from 'react';
import './App.css';
import { IntlProvider } from 'react-intl';
import Game from './Game'

function App() {
  return (
    <IntlProvider locale="en">
      <div className="container">
        <div className="App">
          <Game />
        </div>
      </div>
    </IntlProvider>
  );
}

export default App;
