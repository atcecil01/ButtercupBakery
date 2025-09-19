import React, { Fragment } from 'react'
function AddRecipe() {
    fetchCategories();

    return (
        <Fragment>
            <h2 id="pagetitle">Add Recipe</h2>
            <form>
                <label>Recipe Name: </label>
                <input type='text' name='recipeName' />
                <br />

                <label>Description: </label>
                <input type='text' name='description' />
                <br />

                <label>Preparation Time: </label>
                <input type='number' name='preparationTime' />
                <br />

                <label>Category: </label>
                <select name='category' />
                <br />

                <label>Ingredients: </label>
                <textarea name='ingredients' />
                <br />

                <label>Instructions: </label>
                <textarea name='instructions' />
                <br />

                <button type='submit'>Submit</button>
            </form>
        </Fragment>
    )
}

async function fetchCategories() {
    await fetch('category')
        .then(response => response.json())
        .then(data => {
            const categorySelect = document.querySelector('select[name="category"]');
            categorySelect.options.length = 0;
            data.forEach(category => {
                const option = document.createElement('option');
                option.value = category.id;
                option.textContent = category.name;
                categorySelect.appendChild(option);
            });
        })
        .catch(error => console.error('Error fetching categories:', error));
}

export default AddRecipe;