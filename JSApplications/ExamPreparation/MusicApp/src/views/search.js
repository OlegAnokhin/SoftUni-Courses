import { getSearchResult } from '../api/searchBonus.js';
import { html, nothing } from '../lib.js';

const searchTemp = (isClicked, onSearch, result, hasUser) => html`
<section id="searchPage">
            <h1>Search by Name</h1>

            <div class="search">
                <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
                <button @click=${onSearch} class="button-list">Search</button>
            </div>
            <h2>Results:</h2> 
            <div class="search-result">           
            ${ isClicked ? createResultTemp(result, hasUser): nothing}
            </div>            
        </section>`;

const createResultTemp = (result, hasUser) => {
return html `
 ${result.length > 0 ? 
    html `${result.map(el => createCard(el, hasUser))}`:
    html`<p class="no-result">No result.</p>`}
    `
}

const createCard = (el, hasUser) => html `
<div class="card-box">
        <img src=${el.imgUrl}>
        <div>
            <div class="text-center">
                <p class="name">${el.name}</p>
                <p class="artist">A${el.artist}</p>
                <p class="genre">Genre: ${el.genre}</p>
                <p class="price">Price: $${el.price}</p>
                <p class="date">Release Date: ${el.releaseDate}</p>
            </div>
            ${hasUser ? html`
            <div class="btn-group">
                <a href="/catalog/${el._id}" id="details">Details</a>
            </div>` : nothing}

        </div>`
export async function searchView(ctx) {
    ctx.render(searchTemp(false, onSearch));
    async function onSearch(event) {
        const searchEl = document.getElementById("search-input");
        const query = searchEl.value;

        if(!query) {
            return alert('Field are required!')
        }
        const result = await getSearchResult(query);
        ctx.render(searchTemp(true, onSearch, result, !!ctx.user))
    }
}