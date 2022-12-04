import { getItemById, updateItem } from '../api/data.js';
import { html } from '../lib.js';

const editTemp = (item, onSubmit) => html`
<section id="edit-page" class="edit">
    <form @submit=${onSubmit} id="edit-form" action="#" method="">
        <fieldset>
            <legend>Edit my Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" .value=${item.title}>
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description"
                        id="description">${item.description}</textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" .value=${item.imageUrl}>
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type" .value=${item.type}>
                        <option value="Fiction" selected>Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Save">
        </fieldset>
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
            description: formData.get('description'),
            imageUrl: formData.get('imageUrl'),            
            type: formData.get('type'),            
            };
            if (item.title == '' || item.description == '' 
            || item.imageUrl == '' || item.type == '') {
                return alert('All fields are requared!')
            }

        await updateItem(id, item);
        event.target.reset();
        ctx.page.redirect('/details/' + id)
    }
}
