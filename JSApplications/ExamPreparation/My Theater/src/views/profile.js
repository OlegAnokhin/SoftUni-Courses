import { getUserTheaters } from '../api/data.js';
import { html } from '../lib.js';

const myProfileTemp = (items, userEmail) => html`
<section id="profilePage">
            <div class="userInfo">
                <div class="avatar">
                    <img src="./images/profilePic.png">
                </div>
                <h2>${userEmail}</h2>
            </div>
            <div class="board">
                ${items.length == 0 ? html`
                <div class="no-events">
                    <p>This user has no events yet!</p>
                </div>`
                : items.map(item => html`
                <div class="eventBoard">
                    <div class="event-info">
                        <img src=${item.imageUrl}>
                        <h2>${item.title}</h2>
                        <h6>${item.date}</h6>
                        <a href="/details/${item._id}" class="details-button">Details</a>
                    </div>
                </div>`)}
            </div>
</section>`

export async function myProfileView(ctx) {
    const userId = ctx.user.id;
    const userEmail = ctx.user.email;
    const userItems = await getUserTheaters(userId);
    ctx.render(myProfileTemp(userItems, userEmail));
}