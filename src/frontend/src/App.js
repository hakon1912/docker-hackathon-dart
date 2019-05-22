import React from 'react';
import './App.css';
import GameList from './GameList'

function App() {
  return (
    <div className="App">
      <button>Start new game</button>
      <GameList />
    </div>
  );
}

export default App;
