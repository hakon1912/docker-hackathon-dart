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

  render() {
    return (
      <div>
        {this.state.gameInProgress ? (
          <CurrentPlayer />
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