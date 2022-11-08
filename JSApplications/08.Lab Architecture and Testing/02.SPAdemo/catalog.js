import { get } from "./api.js";

document.getElementById('recipes-list').addEventListener('click', openRecipe)
const section = document.getElementById('catalog-view');
section.remove();
let ctx = null;

export async function showCatalogView(inCtx){
    ctx = inCtx;
    const recipes = await getAllRecipes();
    document.querySelector('main').appendChild(section);
    displayRecipes(recipes);
}

async function getAllRecipes(){
    const recipes = await get('/data/recipes?select='+ encodeURIComponent('_id,name'));
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
        ctx.goto('details-link', id)
    }
}