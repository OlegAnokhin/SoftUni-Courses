import { createItem } from '../api/data.js';
import { html } from '../lib.js';

const createTemp = (onSubmit) => html`
<section id="createPage">
    <form @submit=${onSubmit} class="create-form">
        <h1>Create Theater</h1>
        <div>
            <label for="title">Title:</label>
            <input id="title" name="title" type="text" placeholder="Theater name" value="">
        </div>
        <div>
            <label for="date">Date:</label>
            <input id="date" name="date" type="text" placeholder="Month Day, Year">
        </div>
        <div>
            <label for="author">Author:</label>
            <input id="author" name="author" type="text" placeholder="Author">
        </div>
        <div>
            <label for="description">Description:</label>
            <textarea id="description" name="description" placeholder="Description"></textarea>
        </div>
        <div>
            <label for="imageUrl">Image url:</label>
            <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url" value="">
        </div>
        <button class="btn" type="submit">Submit</button>
    </form>
</section>`

export function createView(ctx) {
    ctx.render(createTemp(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);

        const item = {
            title: formData.get('title'),
            date: formData.get('date'),
            author: formData.get('author'),
            description: formData.get('description'),
            imageUrl: formData.get('imageUrl'),
        };
        if (item.title == '' || item.date == '' || item.author == ''
            || item.description == '' || item.imageUrl == '') {
            return alert('All fields are requared!')
        }

        await createItem(item);
        event.target.reset();
        ctx.page.redirect('/')
    }
}
