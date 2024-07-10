import React from 'react';
import { Link } from 'react-router-dom';
import '../style/Header.css'

function Header() {
    return (
        <header>
            <div className="navbar navbar-dark bg-dark shadow-sm">
                <div className="container d-flex justify-content-between align-items-center">
                    <a href="#" className="navbar-brand d-flex align-items-center">
                        <strong><Link to="/home" className="nav-link">Ione Recipes</Link></strong>
                    </a>
                    <div className="nav-links">
                        <Link to="/home" className="nav-link">Acasa</Link>
                        <Link to="/ingredients" className="nav-link">Gaseste Reteta</Link>
                    </div>
                </div>
            </div>
        </header>
    );
}

export default Header;
