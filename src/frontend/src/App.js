import React from 'react';
import './App.css';
import { IntlProvider } from 'react-intl';
import GameList from './GameList'
import CreateGame from './CreateGame'

function App() {
  return (
    <IntlProvider locale="en">
      <div className="container">
        <div className="App">
          <CreateGame />
          <GameList />
        </div>
      </div>
    </IntlProvider>
  );
}

export default App;
