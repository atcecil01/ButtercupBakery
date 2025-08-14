import React from 'react'
import { Link } from 'react-router-dom'

function Footer() {
    return(
        <React.Fragment>
            <nav className='navbar rounded-bottom'>
                <Link to='/About' className='navlink px-5'>Privacy Policy</Link>
                <Link to='/About' className='navlink px-5'>Terms of Service</Link>
                <Link to='/About' className='navlink px-5'>Contact Us</Link>
                <Link to='/About' className='navlink px-5'>Follow us on Social Media</Link>
            </nav>
        </React.Fragment>
    )
}

export default Footer;