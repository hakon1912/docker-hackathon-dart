import React from 'react'
import API from './api'
import CreateGame from './CreateGame'
import GameList from './GameList'
import CurrentPlayer from './CurrentPlayer'

export default class Game extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      games: [],
      gameInProgress: false,
      currentPlayer: null
    }
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

  startGame(player) {
    this.setState({currentPlayer: player, gameInProgress: true})
  }

  endPlayerRound(score) {
    API.post("round/add", {
      gameId: this.state.currentPlayer.gameId,
      playerId: this.state.currentPlayer.Id,
      score
    })
    .then(res => {
      if (res.data === null) {
        this.setState({gameInProgress: false, currentPlayer: null})
        return;
      }
      this.setState({currentPlayer: res.data});
    })
    .catch(err => {
      console.log(err);
    })
  }

  render() {
    return (
      <div>
        {this.state.gameInProgress ? (
          <CurrentPlayer endPlayerRound/>
        ) : (
            <div>
              <CreateGame startGame={this.startGame}/>
              <GameList games={this.state.games} />
            </div>
          )}

      </div>
    )
  }
}