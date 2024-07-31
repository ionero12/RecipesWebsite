import { useEffect, useState } from "react";
import { useParams } from 'react-router-dom';
import '../style/RecipeDetail.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import Header from "./Header";
import Subsol from "./Subsol";

function RecipeDetail() {
    let { idRecipe } = useParams();
    const [recipe, setRecipe] = useState();
    const [ingredients, setIngredients] = useState([]);
    const [steps, setSteps] = useState([]);

    useEffect(() => {
        const fetchRecipe = async (idRecipe) => {
            try {
                const response = await fetch(`https://localhost:7094/api/Recipes/${idRecipe}`, {
                    method: 'GET', headers: {
                        'Content-Type': 'application/json',
                    },
                });

                if (!response.ok) {
                    console.error(`HTTP error! status: ${response.status}`);
                }

                const data = await response.json();
                setRecipe(data);
            } catch (error) {
                console.error('Error fetching recipe', error);
            }
        };

        const fetchIngredients = async (idRecipe) => {
            try {
                const response = await fetch(`https://localhost:7094/api/Ingredients/ByRecipe/${idRecipe}`, {
                    method: 'GET', headers: {
                        'Content-Type': 'application/json',
                    },
                });

                if (!response.ok) {
                    console.error(`HTTP error! status: ${response.status}`);
                }

                const data = await response.json();
                // Transformă prima literă în majusculă pentru fiecare ingredient
                const transformedIngredients = data.map(ingredient => ({
                    ...ingredient,
                    ingredientName: ingredient.ingredientName.charAt(0).toUpperCase() + ingredient.ingredientName.slice(1)
                }));
                setIngredients(transformedIngredients);
            } catch (error) {
                console.error('Error fetching ingredients', error);
            }
        };

        const fetchSteps = async (idRecipe) => {
            try {
                const response = await fetch(`https://localhost:7094/api/Steps/ByRecipe/${idRecipe}`, {
                    method: 'GET', headers: {
                        'Content-Type': 'application/json',
                    },
                });

                if (!response.ok) {
                    console.error(`HTTP error! status: ${response.status}`);
                }

                const data = await response.json();
                setSteps(data);
            } catch (error) {
                console.error('Error fetching steps', error);
            }
        };

        fetchRecipe(idRecipe);
        fetchIngredients(idRecipe);
        fetchSteps(idRecipe);
    }, [idRecipe]);

    return (
        <div>
            <Header />
            <div className="container-fluid">
                <div className="recipe-detail">
                    <div>
                        {recipe ? (
                            <div>
                                <img
                                    src={`/images/${recipe.recipePhoto}`}
                                    alt={recipe.recipeName}
                                    className="custom-img"
                                />
                                <h1 className={"recipe-title"}>{recipe.recipeName}</h1>
                            </div>
                        ) : (
                            <p>Loading...</p>
                        )}
                    </div>

                    <div className="row">
                        <div className="col">
                            <p><strong>Timp preparare:</strong> {recipe?.recipePrepareTime}</p>
                        </div>
                        <div className="col">
                            <p><strong>Timp gatire:</strong> {recipe?.recipeCookTime}</p>
                        </div>
                        <div className="col">
                            <p><strong>Nr portii:</strong> {recipe?.recipePortionsNumber}</p>
                        </div>
                    </div>

                    <div className="ingredients">
                        <h2>Ingrediente:</h2>
                        <div className="ingredient-cards">
                            {ingredients.map((ingredient, index) => (
                                <div key={index} className="ingredient-card">
                                    <div className="card-content">
                                        <h3>{ingredient.ingredientName}</h3>
                                        <p>{ingredient.ingredientQuantity} {ingredient.ingredientUnit}</p>
                                    </div>
                                </div>
                            ))}
                        </div>
                    </div>

                    <div className="steps">
                        <h2>Pasi de pregatire:</h2>
                        <div className="step-cards">
                            {steps.map((step, index) => (
                                <div key={index} className="step-card">
                                    <div className="card-content">
                                        <p>{step.stepNumber}. {step.stepDescription}</p>
                                        {step.stepImage && (
                                            <img
                                                src={`/images/${step.stepImage}`}
                                                alt={`Step ${step.stepNumber}`}
                                                className="step-img"
                                            />
                                        )}
                                    </div>
                                </div>
                            ))}
                        </div>
                    </div>
                </div>
            </div>
            <Subsol/>
        </div>
    );
}

export default RecipeDetail;
