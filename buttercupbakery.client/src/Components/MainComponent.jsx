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
            <Header />
            <Routes>
                <Route path='/' element={<Navigate to='/home' />} />
                <Route path='/home' element={<Home />} />
                <Route path='/about' element={<About />} />
                <Route path='/add-recipe' element={<AddRecipe />} />
                <Route path='/recipelist' element={<RecipeList />} />
                <Route path='*' element={<Navigate to='/home' />} />
            </Routes>
            <Footer />
        </React.Fragment>
    )
}

export default Main; 