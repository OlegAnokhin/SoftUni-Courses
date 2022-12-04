import { deleteItem, getItemById } from '../api/data.js';
import { didUserLike, getTotalLikesCount, likeTheater } from '../api/likes.js';
import { html, nothing } from '../lib.js';

const detailsTemp = (item, hasUser, isOwner, likeCount, canLike, onDelete, onClickDonation) => html`
<section id="detailsPage">
    <div id="detailsBox">
        <div class="detailsInfo">
            <h1>Title: ${item.title}</h1>
            <div>
                <img src=${item.imageUrl}/>
            </div>
        </div>
        <div class="details">
            <h3>Theater Description</h3>
            <p>${item.description}</p>
            <h4>Date: ${item.date}</h4>
            <h4>Author: ${item.author}</h4>
            <div class="buttons">
            ${isOwner ? html `
                <a @click=${onDelete} class="btn-delete" href="javascript:void(0)">Delete</a>
                <a class="btn-edit" href="/edit/${item._id}">Edit</a>` : nothing}
            
                ${(() => {
                if (canLike == 0) {
                    if (hasUser && !isOwner) {        
                        return html`<a @click=${onClickDonation} class="btn-like" href="javascript:void(0)">Like</a>`
                    }
                }
            })()}                    
            </div>
            <p class="likes">Likes: ${likeCount}</p>
        </div>
    </div>
</section>`

export async function detailsView(ctx) {
    const postId = ctx.params.id
    const item = await getItemById(postId);
    const user = ctx.user;

    let userId;
    let likeCount;
    let canLike;

    if (user != null) {
        userId = user.id;
        canLike = await didUserLike(postId, userId)
    }

    const isOwner = user && user.id == item._ownerId;
    const hasUser = user !== undefined;
    likeCount = await getTotalLikesCount(postId);
    ctx.render(detailsTemp(item, hasUser, isOwner, likeCount, canLike, onDelete, onClickDonation));

    async function onClickDonation() {
        const like = {
            postId,
        }
        await likeTheater(like);
        likeCount = await getTotalLikesCount(like);
        canLike = await didUserLike(postId, userId);
        ctx.render(detailsTemp(item, hasUser, isOwner, likeCount, canLike, onDelete, onClickDonation));
    }

    async function onDelete() {
        const choise = confirm('Are you sure you want to delete this item?');
        if (choise) {
            await deleteItem(postId);
            ctx.page.redirect('/');
        }
    }
}