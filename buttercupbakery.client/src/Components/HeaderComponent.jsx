import React, { Fragment } from 'react'
import { NavLink } from 'react-router-dom'

function Header() {
    return(
        <Fragment>
            <h1 id='maintitle' className="scallop-bottom">
                <div className="row">
                    <div className="col-md-2" style={{ height: '.5em', margin: '3px 10px 0px 0px', backgroundColor: 'var(--header-color-1)' }} />
                    <div className="col-md-2" style={{ height: '.5em', margin: '3px 10px 0px 0px', backgroundColor: 'var(--header-color-2)' }} />
                    <div className="col-md-2" style={{ height: '.5em', margin: '3px 10px 0px 0px', backgroundColor: 'var(--header-color-3)' }} />
                    <div className="col-md-5" style={{ height: '.5em', margin: '3px 10px 0px 0px', backgroundColor: 'var(--header-color-4)' }} />
                </div>
                Buttercup Bakery</h1>
            <nav className='navbar'>
                <NavLink to='/Home' className={({ isActive, isPending }) => isActive ? 'navlink-active px-5' : 'navlink px-5'}><div className="square" />Home</NavLink>
                <NavLink to='/About' className={({ isActive, isPending }) => isActive ? 'navlink-active px-5' : 'navlink px-5'}><div className="square" />About</NavLink>
                <NavLink to='/ContactUs' className={({ isActive, isPending }) => isActive ? 'navlink-active px-5' : 'navlink px-5'}><div className="square" />Contact Us</NavLink>
                <NavLink to='/RecipeList' className={({ isActive, isPending }) => isActive ? 'navlink-active px-5' : 'navlink px-5'}><div className="square" />Recipes</NavLink>
            </nav>
            <hr />
        </Fragment>
    )
}

export default Header;