import { getAllUserPosts } from '../api/data.js';
import { html } from '../lib.js';

const myPostsTemp = (items) => html`
<section id="my-posts-page">
    <h1 class="title">My Posts</h1>

    ${items.length == 0 ? html`
    <h1 class="title no-posts-title">You have no posts yet!</h1>` 
        : items.map(item=> html`
        <div class="my-posts">
            <div class="post">
                <h2 class="post-title">${item.title}</h2>
                <img class="post-image" src=${item.imageUrl} alt="Material Image">
                <div class="btn-wrapper">
                    <a href="/details/${item._id}" class="details-btn btn">Details</a>
                </div>
            </div>
        </div>`)}
</section>`

export async function myPostsView(ctx) {
    const userId = ctx.user.id;
    const userItems = await getAllUserPosts(userId);
    ctx.render(myPostsTemp(userItems));
}