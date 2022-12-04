import { html } from '../lib.js';
import { getAllData } from '../api/data.js';

const dashboardTemp = (items) => html`
<section id="dashboard">
    <h2>Albums</h2>
    <ul class="card-wrapper">
        ${items == 0 ? html`
        <h2>There are no albums added yet.</h2>` 
        : items.map(item => html`
        <li class="card">
            <img src=${item.imageUrl} alt="travis" />
            <p>
                <strong>Singer/Band: </strong><span class="singer">${item.singer}</span>
            </p>
            <p>
                <strong>Album name: </strong><span class="album">${item.album}</span>
            </p>
            <p><strong>Sales:</strong><span class="sales">${item.sales}</span></p>
            <a class="details-btn" href="/details/${item._id}">Details</a>
        </li>`)}        
    </ul>
</section>`;

export async function dashboardView(ctx) {
    const items = await getAllData();
    ctx.render(dashboardTemp(items));
}