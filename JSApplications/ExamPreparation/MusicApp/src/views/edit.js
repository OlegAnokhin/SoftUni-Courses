import { getDataById, updateData } from '../api/data.js';
import { html } from '../lib.js';

const editTemp = (item, onSubmit) => html`
<section class="editPage">
            <form @submit=${onSubmit}>
                <fieldset>
                    <legend>Edit Album</legend>

                    <div class="container">
                        <label for="name" class="vhide">Album name</label>
                        <input id="name" name="name" class="name" type="text" .value=${item.name}>

                        <label for="imgUrl" class="vhide">Image Url</label>
                        <input id="imgUrl" name="imgUrl" class="imgUrl" type="text" .value=${item.imgUrl}>

                        <label for="price" class="vhide">Price</label>
                        <input id="price" name="price" class="price" type="text" .value=${item.price}>

                        <label for="releaseDate" class="vhide">Release date</label>
                        <input id="releaseDate" name="releaseDate" class="releaseDate" type="text" .value=${item.releaseDate}>

                        <label for="artist" class="vhide">Artist</label>
                        <input id="artist" name="artist" class="artist" type="text" .value=${item.artist}>

                        <label for="genre" class="vhide">Genre</label>
                        <input id="genre" name="genre" class="genre" type="text" .value=${item.genre}>

                        <label for="description" class="vhide">Description</label>
                        <textarea name="description" class="description" rows="10"
                            cols="10">${item.description}</textarea>

                        <button class="edit-album" type="submit">Edit Album</button>
                    </div>
                </fieldset>
            </form>
        </section>`

export async function editView(ctx) {
    const id = ctx.params.id
    const item = await getDataById(id);
    ctx.render(editTemp(item, onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);

        const item = {
          name: formData.get('name'),
          imgUrl: formData.get('imgUrl'),
          price: formData.get('price'),
          releaseDate: formData.get('releaseDate'),
          artist: formData.get('artist'),
          genre: formData.get('genre'),
          description: formData.get('description') 
        };
        if (item.name == '' || item.imgUrl == '' || item.price == ''
          || item.releaseDate == '' || item.artist == '' || item.genre == '' || item.description == '') {
          return alert('All fields are requared!')
        }

        await updateData(id, item);
        event.target.reset();
        ctx.page.redirect('/catalog/' + id)
    }
}
