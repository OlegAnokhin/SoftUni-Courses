import { deleteItem, getItemById } from '../api/data.js';
import { didUserLike, getTotalLikesCount, likeTheater } from '../api/likes.js';
import { html, nothing } from '../lib.js';

const detailsTemp = (item, hasUser, isOwner, likeCount, canLike, onDelete, onClickLike) => html`
<section id="details">
        <div id="details-wrapper">
          <p id="details-title">Album Details</p>
          <div id="img-wrapper">
            <img src=${item.imageUrl} alt="example1" />
          </div>
          <div id="info-wrapper">
            <p><strong>Band:</strong><span id="details-singer">${item.singer}</span></p>
            <p>
              <strong>Album name:</strong><span id="details-album">${item.album}</span>
            </p>
            <p><strong>Release date:</strong><span id="details-release">${item.release}</span></p>
            <p><strong>Label:</strong><span id="details-label">${item.label}</span></p>
            <p><strong>Sales:</strong><span id="details-sales">${item.sales}</span></p>
          </div>
          <div id="likes">Likes: <span id="likes-count">${likeCount}</span></div>

          <div id="action-buttons">
            ${hasUser && !isOwner ? html`
            <a @click=${onClickLike} href="javascript:void(0)" id="like-btn">Like</a>` : nothing}            
            ${isOwner ? html`
            <a href="/edit/${item._id}" id="edit-btn">Edit</a>
            <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>` : nothing}            
          </div>
        </div>
      </section>`

export async function detailsView(ctx) {
    const postId = ctx.params.id
    const item = await getItemById(postId);
    const user = ctx.user;

    let userId;
    let likeCount = 0;
    let canLike;
    if (user != null) {
        userId = user.id;
        canLike = await didUserLike(postId, userId)
    }

    const isOwner = user && user.id == item._ownerId;
    const hasUser = user !== undefined;
    likeCount = await getTotalLikesCount(postId);
    ctx.render(detailsTemp(item, hasUser, isOwner, likeCount, canLike, onDelete, onClickLike));

    async function onClickLike() {
        const like = {
            postId,
        }
        await likeTheater(like);
        likeCount = await getTotalLikesCount(like);
        canLike = await didUserLike(postId, userId);
        ctx.render(detailsTemp(item, hasUser, isOwner, likeCount, canLike, onDelete, onClickLike));
    }

    async function onDelete() {
        const choise = confirm('Are you sure you want to delete this item?');
        if (choise) {
            await deleteItem(postId);
            ctx.page.redirect('/dashboard');
        }
    }
}