import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import Navbar from './Components/Common/Navbar';
import InQuickerServices from "./Components/Services/InQuickerServices";
import { InQuickerProviders } from "./Components/Services/InQuickerProviders";
import './App.css';

const App = () => (
  <Router>
    <Navbar />
    <Route exact path="/" component={InQuickerServices} />
    <Route path="/quickerproviders" component={InQuickerProviders} />
  </Router>

)
export default App;