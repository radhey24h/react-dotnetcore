import React from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import Navbar from './Components/Common/Navbar';
import InQuickerServices from "./Components/Services/InQuickerServices";
import { InQuickerProviders } from "./Components/Services/InQuickerProviders";
import ProductList from "./Components/Products/ProductList";
import './App.css';

const App = () => (
  <Router>
    {/* <ProductList /> */}
    <InQuickerServices />
    <Navbar />
    {/* <Route exact path="/" component={InQuickerServices} /> */}
    <Route path="/quickerproviders" component={InQuickerProviders} />
  </Router>

)
export default App;