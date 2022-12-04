import { deleteItem, getItemById } from '../api/data.js';
//import { didUserDonation, donationPost, getTotalDonationCount } from '../api/donations.js';
import { html, nothing } from '../lib.js';

const detailsTemp = (item, isOwner, onDelete) => html`
<section id="details-page" class="details">
    <div class="book-information">
        <h3>${item.title}</h3>
        <p class="type">Type: ${item.type}</p>
        <p class="img"><img src=${item.imageUrl}></p>
        <div class="actions">
            <!-- Edit/Delete buttons ( Only for creator of this book )  -->
            ${isOwner ? html `
            <a class="button" href="/edit/${item._id}">Edit</a>
            <a @click=${onDelete} class="button" href="javascript:void(0)">Delete</a>`:nothing}
            

            <!-- Bonus -->
            <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
            <!-- <a class="button" href="#">Like</a> -->

            <!-- ( for Guests and Users )  -->
            <div class="likes">
                <img class="hearts" src="/images/heart.png">
                <span id="total-likes">Likes: 0</span>
            </div>
            <!-- Bonus -->
        </div>
    </div>
    <div class="book-description">
        <h3>Description:</h3>
        <p>${item.description}</p>
    </div>
</section>`

export async function detailsView(ctx) {
    const postId = ctx.params.id
    const item = await getItemById(postId);
    const user = ctx.user;

    let userId;
   // let donationCount;
   // let canDonate;

    if (user != null) {
        userId = user.id;
   //     canDonate = await didUserDonation(postId, userId)
    }

    const isOwner = user && user.id == item._ownerId;
    const hasUser = user !== undefined;
   // donationCount = await getTotalDonationCount(postId);
    ctx.render(detailsTemp(item, isOwner, onDelete));

    // async function onClickDonation() {
    //     const donation = {
    //         postId
    //     }
    //     await donationPost(donation);
    //     donationCount = await getTotalDonationCount(postId);
    //     canDonate = await didUserDonation(postId, userId);
    //     ctx.render(detailsTemp(item, isOwner, onDelete));
    // }

    async function onDelete() {
        const choise = confirm('Are you sure you want to delete this item?');
        if (choise) {
            await deleteItem(postId);
            ctx.page.redirect('/');
        }
    }
}