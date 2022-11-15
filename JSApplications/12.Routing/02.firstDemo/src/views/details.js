import{html} from "../../node_modules/lit-html/lit-html.js";
import { getById } from "../data/recipes";

const detailsTemplate = (resipe) => html`
<h2>${recipe.name}</h2>
<img src="${'/'+resipe.img}">
<h3>Ingredients</h3>
<ul>
    ${resipe.ingredients.map(i=> html`<li>${i}</li>`)}
</ul>
<h3>Preparation Step</h3>
<ul>
    ${recipe.steps.map(s => html`<li>${s}</li>`)}
</ul>
`
export async function showDetails(ctx) {
    const id = ctx.params.id;
    const recipe = await getById(id);
    ctx.render(detailsTemplate(recipe));
}