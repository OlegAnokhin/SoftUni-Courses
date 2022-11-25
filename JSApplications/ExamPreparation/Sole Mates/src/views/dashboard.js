import { getAllData } from '../api/data.js';
import { html, nothing } from '../lib.js';

const dashboardTemp = (items) => html`
        <section id="dashboard">
            <h2>Collectibles</h2>
            <ul class="card-wrapper">
            ${items.length != 0 ? items.map(singleCard) 
                    : nothing}
            </ul>
            ${items.length == 0 ? html`<h2>There are no items added yet.</h2>` 
                    : nothing}        
        </section>`;

const singleCard = (item) => html`
        <li class="card">
            <img src=${item.imageUrl} alt="eminem" />
            <p>
                <strong>Brand: </strong><span class="brand">${item.brand}</span>
            </p>
            <p>
                <strong>Model: </strong><span class="model">${item.model}</span>
            </p>
            <p><strong>Value:</strong><span class="value">${item.value}</span>$</p>
            <a class="details-btn" href="/dashboard/${item._id}">Details</a>
        </li>`;

export async function dashboardView(ctx) {
    const items = await getAllData();
    ctx.render(dashboardTemp(items));
}