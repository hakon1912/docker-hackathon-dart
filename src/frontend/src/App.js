import React from 'react';
import './App.css';
import GameList from './GameList'

function getGameList() {
  return [
    {
      id: 1,
      date: "17.01.2019",
      numberOfPlayers: 4,
      winner: "Stig"
    }
  ]
}
function App() {
  return (
    <div className="App">
      <button>Start new game</button>
      <GameList games={getGameList()}/>
    </div>
  );
}

export default App;
