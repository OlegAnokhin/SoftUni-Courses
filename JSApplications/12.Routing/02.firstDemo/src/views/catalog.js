import{html} from "../../node_modules/lit-html/lit-html.js";
import{repeat}from '../../node_modules/lit-html/directives/repeat.js';
import { getAll } from "../data/recipes";

const catalogTemplate = (recipes) => html`
<h2>Catalog</h2>
<ul>
    ${repeat(recipes, r => r._id, recipesCardTemplate)}
</ul>
`
const recipesCardTemplate = (recipe) => html`
<li><a href=${'/catalog/' + recipe._id}>${recipe.name}</a></li>
`
export async function showCatalog(ctx) {
    ctx.render(html`<p>Loading &hellip;</p>`)
    const recipes = await getAll();
    ctx.render(catalogTemplate());
}