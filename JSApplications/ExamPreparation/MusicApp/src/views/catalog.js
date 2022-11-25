import { getAllData } from '../api/data.js';
import { html, nothing } from '../lib.js';

const catalogTemp = (items, hasUser) => html`
    <section id="catalogPage">
            <h1>All Albums</h1>              
            ${items.length == 0 ? html`<p>No Albums in Catalog!</p>` 
                    : items.map(item => singleCard(item, hasUser))}                        
    </section>`;
const singleCard = (item, hasUser) => html`
            <div class="card-box">
                <img src=${item.imgUrl}>
                <div>
                    <div class="text-center">
                        <p class="name">${item.name}</p>
                        <p class="artist">${item.artist}</p>
                        <p class="genre">${item.genre}</p>
                        <p class="price">Price: $${item.price}</p>
                        <p class="date">Release Date: ${item.releaseDate}</p>
                    </div>
                    ${hasUser ? html `
                    <div class="btn-group">
                        <a href="/catalog/${item._id}" id="details">Details</a>
                    </div>
                    ` : nothing}                    
                </div>
            </div>`;

export async function catalogView(ctx) {
    const items = await getAllData();
    const hasUser = !!ctx.user;
    ctx.render(catalogTemp(items, hasUser));
}