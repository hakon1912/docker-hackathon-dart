import React from 'react'
import { FormattedDate } from 'react-intl';

export default class GameList extends React.Component {

  render() {
    return (
      <div>
        <h2>Historical games</h2>
        {this.props.games.length > 0 ? (
          <table className="table table-striped table-sm">
          <thead>
            <tr>
              <th>Date</th>
              <th>Name</th>
              <th>Game type</th>
            </tr>
          </thead>
          <tbody>
            {this.props.games.map(game => {
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