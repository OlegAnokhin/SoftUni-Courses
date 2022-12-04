import { deleteItem, getItemById } from '../api/data.js';
import { didUserLike, getTotalLikesCount, likeBook } from '../api/likes.js';
import { html, nothing } from '../lib.js';

const detailsTemp = (item, hasUser, isOwner,likesCount, canLike, onDelete, onClickDonation) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${item.title}</h3>
        <p class="type">Type: ${item.type}</p>
        <p class="img"><img src=${item.imageUrl}></p>
        <div class="actions">
            ${isOwner ? html `
            <a class="button" href="/edit/${item._id}">Edit</a>
            <a @click=${onDelete} class="button" href="javascript:void(0)">Delete</a>`:nothing}
            ${(() => {
                if(canLike == 0) {
                    if(hasUser && !isOwner) {
                        return html`
                        <a @click=${onClickDonation} class="button" href="javascript:void(0)">Like</a>`
                    }
                }
            })()}
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: ${likesCount}</span>
            </div>
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${item.description}</p>
    </div>
</section>`

export async function detailsView(ctx) {
    const bookId = ctx.params.id
    const item = await getItemById(bookId);
    const user = ctx.user;

    let userId;
    let likesCount;
    let canLike;

    if (user != null) {
        userId = user.id;
        canLike = await didUserLike({bookId, userId})
    }

    const isOwner = user && user.id == item._ownerId;
    const hasUser = user !== undefined;
    likesCount = await getTotalLikesCount(bookId);
    ctx.render(detailsTemp(item, hasUser, isOwner,likesCount, canLike, onDelete, onClickDonation));

    async function onClickDonation() {
        const like = {
            bookId
        }
        await likeBook(like);
        likesCount = await getTotalLikesCount(bookId);
        canLike = await didUserLike(bookId, userId);
        ctx.render(detailsTemp(item, hasUser, isOwner,likesCount, canLike, onDelete, onClickDonation));
    }

    async function onDelete() {
        const choise = confirm('Are you sure you want to delete this item?');
        if (choise) {
            await deleteItem(bookId);
            ctx.page.redirect('/');
        }
    }
}