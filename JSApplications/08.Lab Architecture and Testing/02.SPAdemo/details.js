import { get } from "./api.js";

const section = document.getElementById('details-view');
section.remove();

export async function showDetailsView(ctx, id){
    const recipe = await get('/data/recipes/'+ id);
    document.querySelector('main').appendChild(section);
    displayRecipe(recipe);
}
function displayRecipe(recipe){
    document.getElementById('recipe-name').textContent = recipe.name;
    const ingredFragment = document.createDocumentFragment();
    for(let item of recipe.ingredients){
        const element = document.createElement('li');
        element.textContent = item;
        ingredFragment.appendChild(element)
    }
    document.getElementById('recipe-ingredients').replaceChildren(ingredFragment);
    const stepsFragment = document.createDocumentFragment();
    for(let item of recipe.steps){
        const element = document.createElement('li');
        element.textContent = item;
        stepsFragment.appendChild(element)
    }
    document.getElementById('recipe-steps').replaceChildren(stepsFragment);
}
