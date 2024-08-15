import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import '../style/Login.css'; // Import the CSS file

function Login() {
    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const navigate = useNavigate();

    const handleLogin = async (e) => {
        e.preventDefault();
        console.log({ email, password }); // Check the values before sending the request

        try {
            const response = await fetch('https://localhost:7094/api/User/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ email, password }),
            });

            if (!response.ok) {
                console.error('Login failed');
                return;
            }

            const data = await response.json();
            const userId = data.userId;
            localStorage.setItem('userId', userId);

            navigate('/home'); // Redirect to home after successful login
        } catch (error) {
            console.error('Error:', error);
        }
    };

    return (
        <div className="login-container">
            <h2>Login</h2>  {/* Login title above the form */}
            <form onSubmit={handleLogin}>
                <div className="form-group">
                    <label htmlFor="email">Email:</label>
                    <input
                        type="email"
                        id="email"
                        value={email}
                        onChange={(e) => setEmail(e.target.value)}
                        required
                    />
                </div>
                <div className="form-group">
                    <label htmlFor="password">Password:</label>
                    <input
                        type="password"
                        id="password"
                        value={password}
                        onChange={(e) => setPassword(e.target.value)}
                        required
                    />
                </div>
                <button type="submit">Login</button>
            </form>
            <p>  {/* Don't have an account text below the form */}
                Don't have an account? <a href="/register">Register here</a>
            </p>
        </div>
    );
}

export default Login;