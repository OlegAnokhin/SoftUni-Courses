import { getDataById, updateData } from '../api/data.js';
import { html } from '../lib.js';

const editTemp = (item, onSubmit) => html`
<section id="edit">
          <div class="form">
            <h2>Edit item</h2>
            <form @submit=${onSubmit} class="edit-form">
              <input
                type="text"
                name="brand"
                id="shoe-brand"
                placeholder="Brand"
                .value=${item.brand}
              />
              <input
                type="text"
                name="model"
                id="shoe-model"
                placeholder="Model"
                .value=${item.model}
              />
              <input
                type="text"
                name="imageUrl"
                id="shoe-img"
                placeholder="Image url"
                .value=${item.imageUrl}
              />
              <input
                type="text"
                name="release"
                id="shoe-release"
                placeholder="Release date"
                .value=${item.release}
              />
              <input
                type="text"
                name="designer"
                id="shoe-designer"
                placeholder="Designer"
                .value=${item.designer}
              />
              <input
                type="text"
                name="value"
                id="shoe-value"
                placeholder="Value"
                .value=${item.value}
              />

              <button type="submit">post</button>
            </form>
          </div>
        </section>`

export async function editView(ctx) {
    const id = ctx.params.id
    const item = await getDataById(id);
    ctx.render(editTemp(item, onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);

        const item = {
            brand: formData.get('brand'),
            model: formData.get('model'),
            imageUrl: formData.get('imageUrl'),            
            release: formData.get('release'),            
            designer: formData.get('designer'),
            value: formData.get('value')            
            };
            if (item.brand == '' || item.model == '' || item.imageUrl == '' 
            || item.release == '' || item.designer == '' || item.value == '') {
                return alert('All fields are requared!')
            }

        await updateData(id, item);
        event.target.reset();
        ctx.page.redirect('/dashboard/' + id)
    }
}
