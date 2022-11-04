import { showDetailsView } from "./details.js";

document.getElementById('recipes-list').addEventListener('click', openRecipe)
document.getElementById('catalog-link').addEventListener('click', showCatalogView)


export async function showCatalogView(){
    [...document.querySelectorAll('section')].forEach(s=>s.style.display = 'none');
    const recipes = await getAllRecipes();
    document.getElementById('catalog-view').style.display = 'block';
    displayRecipes(recipes);
}

async function getAllRecipes(){
    const responce = await fetch('http://localhost:3030/data/recipes?select='+ encodeURIComponent('_id,name'));
    const recipes = await responce.json();
    return recipes;
}

function displayRecipes(recipes){
    const cards = recipes.map(createRecipeCard);
    const fragment = document.createDocumentFragment();
    for(let item of cards){
        fragment.appendChild(item);
    }
    const list = document.getElementById('recipes-list');
    list.replaceChildren(fragment);
}

function createRecipeCard(recipe){
    const element = document.createElement('li');
    element.textContent = recipe.name;
    const link = document.createElement('a');
    link.href = 'javascript:void(0)';
    link.text = '[Details]';
    link.id = recipe._id;
    element.appendChild(link);
    return element;
}
function openRecipe(e){
    if(e.target.tagName == 'A'){
        e.preventDefault();
        const id= e.target.id;
        showDetailsView(id);
    }
}