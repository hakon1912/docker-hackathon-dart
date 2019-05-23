import React from 'react'

export default class CurrentPlayer extends React.Component {
    constructor(props) {
        super(props);
    }

    render() {
        return (
            <div>
                {this.props.player.name} : Round {this.props.player.round}
                <div>{this.props.player.currentScore}</div>
                <input type="text" placeholder="Enter round score"/>
                <button className="btn btn-primary">Save</button>
            </div>
        )
    }
}