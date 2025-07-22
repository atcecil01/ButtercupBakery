import React, { Fragment } from 'react'

function Header() {
    return(
        <Fragment>
            <div>Buttercup Bakery</div>
            <Link to='/home'>Home</Link>
            <Link to='/about'>About</Link>
            <Link to='/add-recipe'>Add Recipe</Link>
            <Link to='/recipes'>Recipes</Link>
        </Fragment>
    )
}

export default Header;