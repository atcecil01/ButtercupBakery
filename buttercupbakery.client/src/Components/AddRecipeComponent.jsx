import React, { Fragment } from 'react'
function AddRecipe() {
    fetchCategories();

    return (
        <Fragment>
            <h2 id="pagetitle">Add Recipe</h2>
            <form>
                <div class="row">
                    <div class="col-md-2 text-start">
                        <label>Recipe Name: </label>
                    </div>
                    <div class="col-md-4 text-start">
                        <input type='text' name='recipeName' />
                    </div>
                    <div class="col-md-2 text-start">
                        <label>Description: </label>
                    </div>
                    <div class="col-md-4 text-start">
                        <input type='text' name='description' />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 text-start">
                        <label>Preparation Time: </label>
                    </div>
                    <div class="col-md-4 text-start">
                        <input type='number' name='preparationTime' />
                    </div>
                    <div class="col-md-2 text-start">
                        <label>Category: </label>
                    </div>
                    <div class="col-md-4 text-start">
                        <select name='category' />
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-2 text-start">
                        <label>Ingredients: </label>
                    </div>
                    <div class="col-md-4 text-start">
                        <textarea name='ingredients' />
                    </div>
                    <div class="col-md-2 text-start">
                        <label>Instructions: </label>
                    </div>
                    <div class="col-md-4 text-start">
                        <textarea name='instructions' />
                    </div>
                </div>

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