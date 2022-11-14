import {html, render} from '../node_modules/lit-html/lit-html.js';
import {towns} from './towns.js'

const townsRoot = document.getElementById("towns");
const resultRoot = document.getElementById("result");
const button = document.querySelector("button").addEventListener("click", search);
update()

function searchTemplate(townsName, match){
const ul = html`
<ul>
   ${townsName.map(townsName => createListTemplate(townsName, match))}
</ul>
`
return ul;
}
function createListTemplate(town, match){
   return html`
   <li class="${(match && town.includes(match)) ? "active" : ""}"> ${town}</li>
   `
   //match && town.toLowerCase()
}
function update(text){
   const ul = searchTemplate(towns, text)
   render(ul, townsRoot);
}
function search(e) {
const textNode = document.getElementById("searchText");
const text = textNode.value//.toLowerCase();
update(text);
updateCount();
textNode.value = "";
}
function updateCount(){
   const count = document.querySelectorAll(".active").length;
   const countElement = count ? html` <p>${count} matches found</p>` : "";
   render(countElement, resultRoot)
}
