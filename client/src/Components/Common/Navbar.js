import React from 'react';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import IconButton from '@material-ui/core/IconButton';
import MenuIcon from '@material-ui/icons/Menu';
import { Link } from 'react-router-dom';


export default function Navbar() {
    return (
        <AppBar position="static">
            <Toolbar>
                <IconButton edge="start" color="inherit" aria-label="menu">
                    <MenuIcon />
                </IconButton>
                <Typography variant="h6" >
                    IN-Quicker Data Display
                </Typography>

                <div className='navbar-menu'>
                    <Link className='navbar-item' to='/'>Services</Link>

                    <Link className='navbar-item' to='/quickerproviders'>
                        Providers
                </Link>
                </div>
            </Toolbar>
        </AppBar>
    )
}
