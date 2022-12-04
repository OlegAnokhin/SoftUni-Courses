import { createItem } from '../api/data.js';
import { html } from '../lib.js';

const createTemp = (onSubmit) => html`
<section id="create">
    <div class="form">
        <h2>Add Album</h2>
        <form @submit=${onSubmit} class="create-form">
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" />
            <input type="text" name="album" id="album-album" placeholder="Album" />
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" />
            <input type="text" name="release" id="album-release" placeholder="Release date" />
            <input type="text" name="label" id="album-label" placeholder="Label" />
            <input type="text" name="sales" id="album-sales" placeholder="Sales" />

            <button type="submit">post</button>
        </form>
    </div>
</section>`

export function createView(ctx) {
    ctx.render(createTemp(onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);
        const item = {
            singer: formData.get('singer'),
            album: formData.get('album'),
            imageUrl: formData.get('imageUrl'),
            release: formData.get('release'),
            label: formData.get('label'),
            sales: formData.get('sales'),
        };
        if (item.singer == '' || item.album == '' || item.imageUrl == ''
            || item.release == '' || item.label == '' || item.sales == '') {
            return alert('All fields are requared!')
        }
        await createItem(item);
        event.target.reset();
        ctx.page.redirect('/dashboard')
    }
}
