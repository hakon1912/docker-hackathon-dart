import React from 'react'
import API from './api'
import { FormattedDate } from 'react-intl';

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
          <table className="table table-striped table-sm">
          <thead>
            <tr>
              <th>Date</th>
              <th>Name</th>
              <th>Game type</th>
            </tr>
          </thead>
          <tbody>
            {this.state.games.map(game => {
              return (
                <tr key={game.id}>
                  <td><FormattedDate value={game.date} /></td>
                  <td>{game.name}</td>
                  <td>{game.startingScore}</td>
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