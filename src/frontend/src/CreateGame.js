import React from 'react'
import api from "./api"

export default class CreateGame extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      createGame: false,
      players: [],
      gameName: null,
      playerName: "",
      gameType: null
    }
  }
  addPlayer() {
    this.setState({players: [...this.state.players, this.state.playerName], playerName: ""})
  }

  updatePlayerName(value) {
    this.setState({playerName: value});
  }
  
  startGame() {
    api.post("game/add", {createGame: {
      gameType: this.state.gameType,
      gameName: this.state.gameName,
      players: this.state.players
    }})
    .then(res => {

    })
    .catch(error => {
      console.log(error);
    })
  }

  render() {
    return (
      <div>
        <button onClick={() => this.setState({ createGame: true })}>Create game</button>
        {this.state.createGame && (
          <div>
            <input type="text" placeholder="Name" />
            <select>
              <option>201</option>
              <option>301</option>
              <option>501</option>
            </select>
            <ul>
              {this.state.players.map(player => <li>{player}</li>)}
            </ul>
            <input value={this.state.playerName} onChange={(e) => this.updatePlayerName(e.target.value)} type="text" placeholder="Player name" />
            <button onClick={() => this.addPlayer()}>Add player</button>
            <button onClick={() => this.startGame()}>Start game</button>
          </div>

        )}
      </div>
    )
  }
}