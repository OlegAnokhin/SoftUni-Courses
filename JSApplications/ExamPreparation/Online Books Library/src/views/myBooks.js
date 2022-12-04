import { getAllUserBooks } from '../api/data.js';
import { html } from '../lib.js';

const myBooksTemp = (items) => html`
<section id="my-books-page" class="my-books">
    <h1>My Books</h1>
    <ul class="my-books-list">
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
</section>`

export async function myBooksView(ctx) {
    const userId = ctx.user.id;
    const userItems = await getAllUserBooks(userId);
    ctx.render(myBooksTemp(userItems));
}