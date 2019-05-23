import React from 'react'

export default class CurrentPlayer extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            score: ""
        }
    }

    updatePlayerScore(value) {
        this.setState({score: value});
    }

    render() {
        return (
            <div>
                {this.props.player.name} : Round {this.props.player.round}
                <div>{this.props.player.currentScore}</div>
                <input value={this.state.score} onChange={(e) => this.updatePlayerScore(e.target.value)} type="text" placeholder="Enter round score"/>
                <button onClick={this.props.endPlayerRound(this.state.score)} className="btn btn-primary">Save</button>
            </div>
        )
    }
}