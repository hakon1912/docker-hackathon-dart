import React from 'react';
import './App.css';
import { IntlProvider } from 'react-intl';
import GameList from './GameList'

function App() {
  return (
    <IntlProvider locale="en">
      <div className="container">
        <div className="App">
          <button type="button" className="btn btn-primary">Start new game</button>
          <GameList />
        </div>
      </div>
    </IntlProvider>
  );
}

export default App;
