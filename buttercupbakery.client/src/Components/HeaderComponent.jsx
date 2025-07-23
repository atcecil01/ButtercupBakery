import React, { Fragment } from 'react'

import { Link } from 'react-router-dom'

function Header() {
    return(
        <Fragment>
            <div>Buttercup Bakery</div>
            <nav>
                <Link to='/home'>Home</Link>
                <Link to='/about'>About</Link>
            </nav>
        </Fragment>
    )
}

export default Header;