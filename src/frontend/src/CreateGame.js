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
      gameType: "201"
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
      startingScore: this.state.gameType,
      name: this.state.gameName,
      players: this.state.players
    }})
    .then(res => {
        this.props.startGame(res.data);
    })
    .catch(error => {
      console.log(error);
    })
  }

  render() {
    return (
      <div>
        <button className="btn btn-primary" onClick={() => this.setState({ createGame: true })}>Create game</button>
        {this.state.createGame && (
          <div>
            <input type="text" placeholder="Name" />
            <select value={this.state.gameType} onChange={(e) => this.setState({gameType: e.target.value})}>
              <option value="201">201</option>
              <option value="301">301</option>
              <option value="501">501</option>
            </select>
            <ul>
              {this.state.players.map(player => <li key={player}>{player}</li>)}
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