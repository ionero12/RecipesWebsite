import React, {useEffect, useState} from 'react';
import {Link} from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.min.css';
import '../style/Album.css';
import Header from './Header.js';
import Subsol from './Subsol';


function Album() {
    const [categories, setCategories] = useState([]);
    const [filteredRecipes, setFilteredRecipes] = useState([]);

    useEffect(() => {
        const fetchRecipes = async () => {
            try {
                const response = await fetch('https://localhost:7117/api/RecipesApi', {
                    method: 'GET', headers: {
                        'Content-Type': 'application/json',
                    },
                });

                if (!response.ok) {
                    console.error(`HTTP error! status: ${response.status}`);
                }

                const data = await response.json();
                setFilteredRecipes(data);
                console.log(data);
            } catch (error) {
                console.error('Error fetching recipes', error);
            }
        };

        const fetchCategories = async () => {
            try {
                const response = await fetch('https://localhost:7117/api/CategoriesApi', {
                    method: 'GET', headers: {
                        'Content-Type': 'application/json',
                    },
                });

                if (!response.ok) {
                    console.error(`HTTP error! status: ${response.status}`);
                }

                const data = await response.json();
                setCategories(data);
                console.log(data);
            } catch (error) {
                console.error('Error fetching categories', error);
            }
        }

        fetchRecipes();
        fetchCategories();
    }, []);

    const fetchFilteredRecipes = async (idCategory) => {
        try {
            const response = await fetch(`https://localhost:7117/api/RecipesApi/RecipesByCategory/${idCategory}`, {
                method: 'GET', headers: {
                    'Content-Type': 'application/json',
                },
            });

            if (!response.ok) {
                console.error(`HTTP error! status: ${response.status}`);
            }

            const data = await response.json();
            setFilteredRecipes(data);
            console.log(data);
        } catch (error) {
            console.error('Error fetching filtered recipes', error);
        }
    }

    return (<div>
            <Header/>
            <main>
                <section className="py-4 text-center container">
                    <div className="row py-lg-5">
                        <div className="col-lg-6 col-md-8 mx-auto">
                            <h1 className="fw-light section-title">Albumul de rețete</h1>
                            <p className="lead text-muted section-text">
                                Bine ați venit în colțul meu culinar! Aici veți găsi o colecție de rețete proprii,
                                fiecare
                                creată cu pasiune și dedicare. Fiecare rețetă este gândită pentru a vă inspira și a vă
                                ghida
                                pas cu pas în bucătărie. Răsfoiți, experimentați și bucurați-vă de arta gătitului!
                            </p>
                            <p className="button-group">
                                {categories.map((category, index) => (
                                    <button
                                        key={category.idCategory}
                                        onClick={() => fetchFilteredRecipes(category.idCategory)}
                                        className={`btn custom-button my-2`}
                                    >
                                        {category.categoryName}
                                    </button>
                                ))}
                            </p>
                        </div>
                    </div>
                </section>

                <div className="album py-5 bg-light">
                    <div className="container">
                        {filteredRecipes.length > 0 ? (
                            <div className="row row-cols-1 row-cols-sm-2 row-cols-md-3 g-3">
                                {filteredRecipes.map(recipe => (
                                    <div className="col" key={recipe.idRecipe}>
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
                                    </div>
                                ))}
                            </div>
                        ) : (
                            <div className="text-center">
                                <p className="lead text-muted">No recipes found for the selected category.</p>
                            </div>
                        )}
                    </div>
                </div>
            </main>
            <Subsol/>
        </div>
    );
}

export default Album;
