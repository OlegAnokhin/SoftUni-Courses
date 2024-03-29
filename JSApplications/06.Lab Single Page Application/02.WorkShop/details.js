export async function showDetailsView(id){
    [...document.querySelectorAll('section')].forEach(s=>s.style.display = 'none');
    const recipe = await getById(id);
    document.getElementById('details-view').style.display = 'block';
    displayRecipe(recipe);
}
async function getById(id){
    const responce = await fetch('http://localhost:3030/data/recipes/'+ id);
    const recipe = await responce.json();
    return recipe;
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
