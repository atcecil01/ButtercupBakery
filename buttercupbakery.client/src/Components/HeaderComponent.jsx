import React, { Fragment } from 'react'
import { NavLink } from 'react-router-dom'

function Header() {
    return(
        <Fragment>
            <h1 id='maintitle'>Buttercup Bakery</h1>
            <nav className='navbar'>
                <NavLink to='/Home' className={({ isActive, isPending }) => isActive ? 'navlink-active px-5' : 'navlink px-5'}><div class="square" />Home</NavLink>
                <NavLink to='/About' className={({ isActive, isPending }) => isActive ? 'navlink-active px-5' : 'navlink px-5'}><div class="square" />About</NavLink>
                <NavLink to='/ContactUs' className={({ isActive, isPending }) => isActive ? 'navlink-active px-5' : 'navlink px-5'}><div class="square" />Contact Us</NavLink>
                <NavLink to='/RecipeList' className={({ isActive, isPending }) => isActive ? 'navlink-active px-5' : 'navlink px-5'}><div class="square" />Recipes</NavLink>
            </nav>
            <hr />
        </Fragment>
    )
}

export default Header;