import React, { Component } from 'react'
import List from '@material-ui/core/List'
import ListItem from '@material-ui/core/ListItem'
import ListItemIcon from '@material-ui/core/ListItemIcon'
import ListItemText from '@material-ui/core/ListItemText'
import IconDashboard from '@material-ui/icons/Dashboard'

export class InQuickerProviders extends Component {
    constructor() {
        super()
        this.state = {
            inquickerstaging: [],
        };
    }

    componentDidMount() {
        // GET request using fetch with async/await
        const url = `https://api.inquickerstaging.com/v3/winter.inquickerstaging.com/providers?include=locations%2Cschedules.location&page%5Bnumber%5D=1&page%5Bsize%5D=10`;
        fetch(url)
            .then((response) => {
                return response.json();
            })
            .then(res => {
                this.setState({ inquickerstaging: res.data })
            });
    }

    handleClick(event) {
        console.log(event)
    }

    render() {
        const quickerStagingDetails = () => {
            return <h2 className="heading">Provider Details</h2>
        }

        return (<>
            <div className="panel" >
                <div className="sidebar" >
                    <h2 className="heading"> Quicker Provider </h2>
                    <List disablePadding dense > {
                        this.state.inquickerstaging.map(item =>
                            <ListItem button onClick={this.handleClick.bind(this)} key={Math.random()} >
                                <ListItemIcon >
                                    <IconDashboard />
                                </ListItemIcon>
                                <ListItemText primary={item.id} />
                            </ListItem>
                        )
                    }
                    </List>
                </div>
                <div className="content-panel" >
                    {quickerStagingDetails()}
                </div>
            </div>
        </>)
    }
}
