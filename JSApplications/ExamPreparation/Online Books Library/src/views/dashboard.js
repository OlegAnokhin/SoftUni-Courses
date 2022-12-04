import { html } from '../lib.js';
import { getAllData } from '../api/data.js';

const dashboardTemp = (items) => html`
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    <ul class="other-books-list">
        ${items.length == 0 ? html`
    <p class="no-books">No books in database!</p>` 
    : items.map(item => html`
        <li class="otherBooks">
            <h3>${item.title}</h3>
            <p>Type: ${item.type}</p>
            <p class="img"><img src=${item.imageUrl}></p>
            <a class="button" href="/details/${item._id}">Details</a>
        </li>`)}
    </ul>
</section>`;

export async function dashboardView(ctx) {
    const items = await getAllData();
    ctx.render(dashboardTemp(items));
}