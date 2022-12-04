import { getItemById, updateItem } from '../api/data.js';
import { html } from '../lib.js';

const editTemp = (item, onSubmit) => html`
<section id="edit">
    <div class="form">
        <h2>Edit Album</h2>
        <form @submit=${onSubmit} class="edit-form">
            <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" .value=${item.singer}/>
            <input type="text" name="album" id="album-album" placeholder="Album" .value=${item.album}/>
            <input type="text" name="imageUrl" id="album-img" placeholder="Image url" .value=${item.imageUrl}/>
            <input type="text" name="release" id="album-release" placeholder="Release date" .value=${item.release}/>
            <input type="text" name="label" id="album-label" placeholder="Label" .value=${item.label}/>
            <input type="text" name="sales" id="album-sales" placeholder="Sales" .value=${item.sales}/>

            <button type="submit">post</button>
        </form>
    </div>
</section>`

export async function editView(ctx) {
    const id = ctx.params.id
    const item = await getItemById(id);
    ctx.render(editTemp(item, onSubmit));

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

        await updateItem(id, item);
        event.target.reset();
        ctx.page.redirect('/details/' + id)
    }
}
