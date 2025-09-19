import React from 'react'
import Header from './HeaderComponent'
import Footer from './FooterComponent'
import Home from './HomeComponent'
import About from './AboutComponent'

import {Routes, Route, Navigate} from 'react-router-dom'
import RecipeList from './RecipeListComponent'
import AddRecipe from './AddRecipeComponent'


function Main () {
    return(
        <React.Fragment>
            <div className='app-container'>
                <Header />
                <div className='body'>
                <Routes>
                    <Route path='/' element={<Navigate to='/home' />} />
                    <Route path='/home' element={<Home />} />
                    <Route path='/about' element={<About />} />
                    <Route path='/addrecipe' element={<AddRecipe />} />
                    <Route path='/recipelist' element={<RecipeList />} />
                    <Route path='*' element={<Navigate to='/home' />} />
                    </Routes>
                </div>
                <Footer />
            </div>
        </React.Fragment>
    )
}

export default Main; 