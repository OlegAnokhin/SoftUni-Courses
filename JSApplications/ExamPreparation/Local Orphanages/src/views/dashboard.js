import { html } from '../lib.js';
import { getAllData } from '../api/data.js';

const dashboardTemp = (items) => html`
<section id="dashboard-page">
        <h1 class="title">All Posts</h1>
    
    <div class="all-posts">
        ${items.length == 0 ? html`
        <h1 class="title no-posts-title">No posts yet!</h1>` 
        : items.map(item=> html`
        <div class="post">
            <h2 class="post-title">${item.title}</h2>
            <img class="post-image" src=${item.imageUrl} alt="Material Image">
            <div class="btn-wrapper">
                <a href="/details/${item._id}" class="details-btn btn">Details</a>
            </div>
        </div>`)}
    </div>
</section>`;

export async function dashboardView(ctx) {
    const items = await getAllData();
    ctx.render(dashboardTemp(items));
}