import React from 'react'

function GameList(props) {
  return (
    <div>
      <h2>Historical games</h2>
      <table>
        <thead>
          <tr>
            <th>Game</th>
            <th>NumberOfPlayers</th>
            <th>Date</th>
            <th>Winner</th>
          </tr>
        </thead>
        <tbody>
          {props.games.map(game => {
            return (
              <tr>
                <td>{game.id}</td>
                <td>{game.numberOfPlayers}</td>
                <td>{game.date}</td>
                <td>{game.winner}</td>
              </tr>
            )
          })}
        </tbody>
      </table>
    </div>

  )
}

export default GameList;