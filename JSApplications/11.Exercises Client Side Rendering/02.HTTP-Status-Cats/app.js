import { html, render } from '../node_modules/lit-html/lit-html.js';
import {cats} from './catSeeder.js'

const root = document.getElementById("allCats");

const catTemplate = html`
<ul>
    ${cats.map(cat => createCatCard(cat))}
</ul>
`
render(catTemplate, root);

function createCatCard(cat) {
    return html`
                <li>
                <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
                <div class="info">
                    <button @click="${showContent}" class="showBtn">Show status code</button>
                    <div class="status" style="display: none" id=${cat.id}>
                        <h4>Status Code: ${cat.statusCode}</h4>
                        <p>${cat.statusMessage}</p>
                    </div>
                </div>
            </li>
    `
}
function showContent(e) {
   const contentCont = e.target.parentElement.querySelector("div");
   const currState = contentCont.style.display;
   if(currState == "none"){
    contentCont.style.display = "block";
    e.target.textContent = "Hide status code";
   }else {
    contentCont.style.display = "none";
    e.target.textContent = "Show status code"
   }
}