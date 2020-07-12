import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import Navbar from './components/common/Navbar';
import { InQuickerServices } from "./components/Services/InQuickerServices";
import { InQuickerProviders } from "./components/Services/InQuickerProviders";
import './App.css';

const App = () => (
  <Router>
    <Navbar />
    <Route exact path="/" component={InQuickerServices} />
    <Route path="/quickerproviders" component={InQuickerProviders} />
  </Router>

)
export default App;