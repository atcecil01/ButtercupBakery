import { useEffect, useState } from 'react';
import './App.css';
import Main from './Components/MainComponent'
import { BrowserRouter as Router } from 'react-router-dom';

function App() {
    return (
        <Router>
            <div><Main /></div>
        </Router>
    );
}

export default App;