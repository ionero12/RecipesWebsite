import Header from './Header.js';
import {useState} from "react";
import axios from "axios";
import '../style/RecipeByIngredients.css'
import {Link} from "react-router-dom";
import Subsol from "./Subsol";

function RecipeByIngredients() {
    const [ingredients, setIngredients] = useState('');
    const [recipes, setRecipes] = useState([]);
    const [error, setError] = useState('');

    const handleSearch = async () => {
        try {
            const response = await axios.get('http://localhost:5000/api/Recipes/RecipeByIngredients', {
                params: {ingredients}
            });
            setRecipes(response.data);
            setError('');
        } catch (err) {
            setError('A apărut o eroare în timpul căutării. Vă rugăm să încercați din nou.');
        }
    };

    return (<div>
            <Header/>
            <main>
                <section className="py-4 text-center container">
                    <div className="row py-lg-5">
                        <div className="col-lg-6 col-md-8 mx-auto">
                            <h1 className="fw-light section-title">Caută rețete după ingrediente</h1>
                            <p className="lead text-muted section-text">
                                Introdu ingredientele separate prin virgulă pentru a găsi rețete care le folosesc.
                            </p>
                            <input
                                type="text"
                                value={ingredients}
                                onChange={(e) => setIngredients(e.target.value)}
                                placeholder="Introdu ingredientele separate prin virgulă"
                                className="ingredient-input"
                            />
                            <button onClick={handleSearch} className="search-button">Caută rețete</button>
                            {error && <p className="error-message">{error}</p>}
                        </div>
                    </div>
                </section>

                <div className="album py-5 bg-light">
                    <div className="container">
                        {recipes.length > 0 ? (<div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
                                {recipes.map(recipe => (<div className="col" key={recipe.idRecipe}>
                                        <Link to={`/recipe/${recipe.idRecipe}`} className="card-link">
                                            <div className="card shadow-sm">
                                                <img className="bd-placeholder-img card-img-top"
                                                     src={`/images/${recipe.recipePhoto}`} alt={recipe.recipeName}
                                                     width="100%" height="300"/>
                                                <div className="card-body">
                                                    <p className="card-text">{recipe.recipeName}</p>
                                                </div>
                                            </div>
                                        </Link>
                                    </div>))}
                            </div>) : (<div className="text-center">
                                <p className="lead text-muted">Nu s-au găsit rețete pentru ingredientele selectate.</p>
                            </div>)}
                    </div>
                </div>
            </main>
        <Subsol/>
        </div>);
}

export default RecipeByIngredients;