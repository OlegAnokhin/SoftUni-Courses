import { deleteItem, getItemById } from '../api/data.js';
import { didUserDonation, donationPost, getTotalDonationCount } from '../api/donations.js';
import { html, nothing } from '../lib.js';

const detailsTemp = (item, isOwner, onDelete, hasUser, donationCount, onClickDonation, canDonate) => html`
<section id="details-page">
            <h1 class="title">Post Details</h1>
            
            <div id="container">
                <div id="details">
                    <div class="image-wrapper">
                        <img src=${item.imageUrl} alt="Material Image" class="post-image">
                    </div>
                    <div class="info">
                        <h2 class="title post-title">${item.title}</h2>
                        <p class="post-description">Description: ${item.description}</p>
                        <p class="post-address">Address: ${item.address}</p>
                        <p class="post-number">Phone number: ${item.phone}</p>
                        <p class="donate-Item">Donate Materials: ${donationCount}</p>
                        <div class="btns">

                        ${isOwner ? html`
                            <a href="/edit/${item._id}" class="edit-btn btn">Edit</a>
                            <a @click=${onDelete} href="javascript:void(0)" class="delete-btn btn">Delete</a>`: nothing}                        
                        ${(() => {
                            if(canDonate == 0) {
                                if(hasUser && !isOwner) {
                                    return html`
                                    <a @click=${onClickDonation} href="javascript:void(0)" class="donate-btn btn">Donate</a>`
                                }
                            }
                        })()}    
                        </div>
                    </div>
                </div>
            </div>
        </section>`

export async function detailsView(ctx) {
    const postId = ctx.params.id
    const item = await getItemById(postId);
    const user = ctx.user;

    let userId;
    let donationCount;
    let canDonate;

    if(user != null) {
        userId = user.id;
        canDonate = await didUserDonation(postId, userId)
    }

    const isOwner = user && user.id == item._ownerId;
    const hasUser = user !== undefined;
    donationCount = await getTotalDonationCount(postId);
    ctx.render(detailsTemp(item, isOwner, onDelete, hasUser, donationCount, onClickDonation, canDonate));

    async function onClickDonation() {
        const donation = {
            postId
        }
        await donationPost(donation);
        donationCount = await getTotalDonationCount(postId);
        canDonate = await didUserDonation(postId, userId);
        ctx.render(detailsTemp(item, isOwner, onDelete, hasUser, donationCount, onClickDonation, canDonate));
    }

    async function onDelete() {
        const choise = confirm('Are you sure you want to delete this item?');
        if (choise) {
            await deleteItem(postId);
            ctx.page.redirect('/');
        }
    }
}