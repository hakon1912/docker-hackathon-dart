import React from 'react'
import API from './api'

export default class GameList extends React.Component {
  state = {
    games: []
  }

  componentDidMount() {
    API.get("game/all")
    .then(res => {
      const games = res.data;
      this.setState({ games });
    })
    .catch(error => {
      console.log(error)
    })
  }
  render() {
    return (
      <div>
        <h2>Historical games</h2>
        {this.state.games.length > 0 ? (
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
            {this.state.games.map(game => {
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
        ) : (
          <div>No historic games to show</div>
        )}
        
      </div>
  
    )
  }
  
}