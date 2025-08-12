import { useEffect, useState } from 'react';
import React, { Fragment } from 'react'
function RecipeList() {
    const [recipes, setRecipes] = useState();

    useEffect(() => {
        fetchRecipes();
    }, []);

    const contents = recipes === undefined
        ? <p><em>Loading... Please refresh once the backend has started.</em></p>
        : <ul>
            {recipes.map(recipe => (
                <li key={recipe.id}>{recipe.name}</li>
            ))}
        </ul>;

    return (
        <Fragment>
            <div>Recipes:</div>
            {contents}
        </Fragment>
    )

    async function fetchRecipes() {
        const response = await fetch('recipelist');
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        const data = await response.json();
        if (!Array.isArray(data)) {
            throw new Error('Expected an array of recipes');
        }
        setRecipes(data);
    }
}

export default RecipeList;
