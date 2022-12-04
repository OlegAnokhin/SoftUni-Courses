import { getItemById, updateItem } from '../api/data.js';
import { html } from '../lib.js';

const editTemp = (item, onSubmit) => html`
<section id="editPage">
    <form @submit=${onSubmit} class="theater-form">
        <h1>Edit Theater</h1>
        <div>
            <label for="title">Title:</label>
            <input id="title" name="title" type="text" placeholder="Theater name" .value=${item.title}>
        </div>
        <div>
            <label for="date">Date:</label>
            <input id="date" name="date" type="text" placeholder="Month Day, Year" .value=${item.date}>
        </div>
        <div>
            <label for="author">Author:</label>
            <input id="author" name="author" type="text" placeholder="Author" .value=${item.author}>
        </div>
        <div>
            <label for="description">Theater Description:</label>
            <textarea id="description" name="description"
                placeholder="Description">${item.description}</textarea>
        </div>
        <div>
            <label for="imageUrl">Image url:</label>
            <input id="imageUrl" name="imageUrl" type="text" placeholder="Image Url"
            .value=${item.imageUrl}>
        </div>
        <button class="btn" type="submit">Submit</button>
    </form>
</section>`

export async function editView(ctx) {
    const id = ctx.params.id
    const item = await getItemById(id);
    ctx.render(editTemp(item, onSubmit));

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

        await updateItem(id, item);
        event.target.reset();
        ctx.page.redirect('/details/' + id)
    }
}
