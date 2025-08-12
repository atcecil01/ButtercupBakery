import React, { Fragment } from 'react'

import { Link } from 'react-router-dom'

function Header() {
    return(
        <Fragment>
            <div>Buttercup Bakery</div>
            <nav>
                <Link to='/Home'>Home</Link>
                <Link to='/About'>About</Link>
                <Link to='/RecipeList'>Recipes</Link>
            </nav>
        </Fragment>
    )
}

export default Header;