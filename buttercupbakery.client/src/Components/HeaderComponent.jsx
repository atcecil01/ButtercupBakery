import React, { Fragment } from 'react'

import { Link } from 'react-router-dom'

function Header() {
    return(
        <Fragment>
            <div id='maintitle'>Buttercup Bakery</div>
            <nav className='navbar rounded-top'>
                <Link to='/Home' className='navlink px-5'>Home</Link>
                <Link to='/About' className='navlink px-5'>About</Link>
                <Link to='/RecipeList' className='navlink px-5'>Recipes</Link>
            </nav>
        </Fragment>
    )
}

export default Header;