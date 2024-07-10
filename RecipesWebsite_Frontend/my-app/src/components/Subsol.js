import React from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {faInstagram, faTiktok, faYahoo} from '@fortawesome/free-brands-svg-icons';
import '../style/Subsol.css'

const Subsol = () => {
    return (
        <div className="navbar navbar-dark bg-dark shadow-sm">
            <div className="container">
                <div className="navbar-brand d-flex align-items-center">
                    <strong>My Website</strong>
                </div>
                <div className="d-flex align-items-center">
                    <a href="https://www.instagram.com/myinstagram" className="text-light me-3">
                        <FontAwesomeIcon icon={faInstagram} size="lg" />
                    </a>
                    <a href="mailto:contact@mywebsite.com" className="text-light me-3">
                        <FontAwesomeIcon icon={faYahoo} size="lg" />
                    </a>
                    <a href="https://www.tiktok.com/mytiktok" className="text-light">
                        <FontAwesomeIcon icon={faTiktok} size="lg" />
                    </a>
                </div>
            </div>
        </div>
    );
};

export default Subsol;
