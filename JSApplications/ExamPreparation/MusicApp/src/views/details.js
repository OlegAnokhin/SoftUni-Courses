import { deleteData, getDataById } from '../api/data.js';
import { html, nothing } from '../lib.js';

const detailsTemp = (item,isOwner, onDelete) => html`
<section id="detailsPage">
            <div class="wrapper">
                <div class="albumCover">
                    <img src=${item.imgUrl}>
                </div>
                <div class="albumInfo">
                    <div class="albumText">

                        <h1>Name: ${item.name}</h1>
                        <h3>Artist: ${item.artist}</h3>
                        <h4>Genre: ${item.genre}</h4>
                        <h4>Price: $${item.price}</h4>
                        <h4>Date: ${item.releaseDate}</h4>
                        <p>${item.description}</p>
                    </div>
                    ${isOwner ? html`
                    <div class="actionBtn">
                        <a href="/edit/${item._id}" class="edit">Edit</a>
                        <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>
                    </div>` : nothing}
                </div>
            </div>
        </section>`

export async function detailsView(ctx) {
    const id = ctx.params.id
    const item = await getDataById(id);

    const hasUser = !!ctx.user;
    const isOwner = hasUser && ctx.user.id == item._ownerId;
    ctx.render(detailsTemp(item, isOwner, onDelete));

    async function onDelete() {
        const choise = confirm('Are you sure you want to delete this item?');
        if (choise) {
            await deleteData(id);
            ctx.page.redirect('/catalog');
        }
    }
}