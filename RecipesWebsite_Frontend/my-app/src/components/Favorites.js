import React, {useEffect, useState} from "react";
import Header from "./Header";
import {Link} from "react-router-dom";
import Subsol from "./Subsol";

function Favorites() {
    const [favorites, setFavorites] = useState([]);
    const [recipes, setRecipes] = useState([]);

    useEffect(() => {
        const storedFavorites = JSON.parse(localStorage.getItem('favorites')) || {};
        setFavorites(storedFavorites);
        const favoriteIds = Object.keys(storedFavorites).filter(key => storedFavorites[key]);
        fetchFavoriteRecipes(favoriteIds).then(setRecipes);
    }, []);

    const toggleFavorite = (idRecipe) => {
        setFavorites(prevFavorites => {
            const newFavorites = { ...prevFavorites, [idRecipe]: !prevFavorites[idRecipe] };
            localStorage.setItem('favorites', JSON.stringify(newFavorites));
            return newFavorites;
        });
    };

    const fetchFavoriteRecipes = async (favoriteIds) => {
        const fetchedRecipes = await Promise.all(favoriteIds.map(id => fetchRecipeById(id)));
        return fetchedRecipes.filter(recipe => recipe); // Filter out any null or undefined recipes
    };

    const fetchRecipeById = async (idRecipe) => {
        try {
            const response = await fetch(`https://localhost:7094/api/Recipes/${idRecipe}`, {
                method: 'GET', headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (!response.ok) {
                console.error(`HTTP error! status: ${response.status}`);
            }
            return await response.json();
        } catch (error) {
            console.error(`Failed to fetch recipe with id ${idRecipe}:`, error);
        }
    };

    return (<div>
            <Header/>
            <div className="album py-5 bg-light">
                <div className="container">
                    {recipes.length > 0 ? (<div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
                            {recipes.map(recipe => (<div className="col" key={recipe.idRecipe}>
                                    <Link to={`/recipe/${recipe.idRecipe}`} className="card-link">
                                        <div className="card shadow-sm">
                                            <img
                                                className="bd-placeholder-img card-img-top"
                                                src={`/images/${recipe.recipePhoto}`}
                                                alt={recipe.recipeName}
                                                width="100%" height="300"
                                            />
                                            <div className="card-body">
                                                <p className="card-text text-center mb-0">
                                                    {recipe.recipeName}
                                                    <span
                                                        className={`favorite-icon ${favorites[recipe.idRecipe] ? 'favorite' : ''}`}
                                                        onClick={(e) => {
                                                            e.preventDefault();
                                                            toggleFavorite(recipe.idRecipe);
                                                        }}
                                                        style={{marginLeft: '10px', cursor: 'pointer'}}
                                                    >
                                                        {favorites[recipe.idRecipe] ? '❤️' : '🤍'}
                                                    </span>
                                                </p>
                                            </div>
                                        </div>
                                    </Link>
                                </div>))}
                        </div>) : (<div className="text-center">
                            <p className="lead text-muted">No recipes found.</p>
                        </div>)}
                </div>
            </div>
            <Subsol/>
        </div>);
}

export default Favorites;
