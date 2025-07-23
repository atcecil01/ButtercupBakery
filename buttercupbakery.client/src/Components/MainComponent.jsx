import React from 'react'
import Header from './HeaderComponent'
import Footer from './FooterComponent'
import Home from './HomeComponent'
import About from './AboutComponent'

import {Routes, Route, Navigate} from 'react-router-dom'


function Main () {
    return(
        <React.Fragment>
            <Header />
            <Routes>
                <Route path='/' element={<Navigate to='/home' />} />
                <Route path='/home' element={<Home />} />
                <Route path='/about' element={<About />} />
                <Route path='/add-recipe' element={<div>Add Recipe</div>} />
                <Route path='/recipes' element={<div>Recipes</div>} />
                <Route path='*' element={<Navigate to='/home' />} />
            </Routes>
            <Footer />
        </React.Fragment>
    )
}

export default Main; 