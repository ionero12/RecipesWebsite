import React from 'react';
import {BrowserRouter as Router, Route, Routes, Navigate} from 'react-router-dom';
import Album from './components/Album';
import RecipeDetail from './components/RecipeDetail';
import RecipeByIngredients from "./components/RecipeByIngredients";
import Favorites from "./components/Favorites";
import Login from "./components/Login";
import Register from "./components/Register";

function App() {
    return (<Router>
        <Routes>
            <Route path="/login" element={<Login />} />
            <Route path="/register" element={<Register />} />
            <Route path="/home" exact element={<Album/>} />
            <Route path="/recipe/:idRecipe" element={<RecipeDetail/>} />
            <Route path="/favorites" element={<Favorites/>} />
            <Route path="/ingredients" element={<RecipeByIngredients/>} />
            <Route path="*" element={<Navigate to="/home"/>}/>
        </Routes>
    </Router>);
}

export default App;
