import React, { Component } from 'react'
import List from '@material-ui/core/List'
import ListItem from '@material-ui/core/ListItem'
import ListItemIcon from '@material-ui/core/ListItemIcon'
import ListItemText from '@material-ui/core/ListItemText'
import IconDashboard from '@material-ui/icons/Dashboard'
import { connect } from 'react-redux'
import { fetchInquickerServices } from '../../Services/servicesActions'

class InQuickerServices extends Component {

    componentDidMount() {
        // GET request using fetch with async/await
        this.props.dispatch(fetchInquickerServices());
    }

    handleClick(event) {
        console.log(event)
    }

    render() {

        const { error, loading, quickerServices } = this.props;
        //console.log(this.props)

        if (error) {
            return <div>Error! {error.message}</div>;
        }

        if (loading) {
            return <div>Loading...</div>;
        }

        const quickerStagingDetails = () => {
            return <h2 className="heading">Services Details</h2>
        }

        return (<>
            <div className="panel" >
                <div className="sidebar" >
                    <h2 className="heading"> Quicker Services </h2>
                    <List disablePadding dense > {
                        quickerServices.map(item =>
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


const mapStateToProps = state => ({
    quickerServices: state.services.items,
    loading: state.services.loading,
    error: state.services.error
});

export default connect(mapStateToProps)(InQuickerServices);
