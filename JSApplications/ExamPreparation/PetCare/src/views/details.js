import { html, nothing } from '../lib.js';
import { deletePet, getPetById } from '../api/pets.js';

const detailsTemp = (pet, hasUser, isOwner, onDelete) => html`
        <section id="detailsPage">
            <div class="details">
                <div class="animalPic">
                    <img src=${pet.image}>
                </div>
                <div>
                    <div class="animalInfo">
                        <h1>Name: ${pet.name}</h1>
                        <h3>Breed: ${pet.breed}</h3>
                        <h4>Age: ${pet.age}</h4>
                        <h4>Weight: ${pet.weight}</h4>
                        <h4 class="donation">Donation: 0$</h4>
                    </div>
                    ${hasUser ? html`
                    <div class="actionBtn">
                        ${isOwner ? html`
                        <a href="/edit/${pet._id}" class="edit">Edit</a>
                        <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>` : html`
                        <a href="#" class="donate">Donate</a>`}
                    </div>` : nothing}
                </div>
            </div>
        </section>`
// function petControls(hasUser, canDonate, isOwner) {
//     if(hasUser == false) {
//         return nothing;
//     }
//     if (canDonate) {
//         return html`
//         <div class="actionBtn">
//             <a href="#" class="donate">Donate</a>   
//         </div>`;
//     }
// }

export async function detailsView(ctx) {
    const id = ctx.params.id
    const pet = await getPetById(id);

    const hasUser = !!ctx.user;
    const canDonate = 0;
    const isOwner = hasUser && ctx.user.id == pet._ownerId;
    ctx.render(detailsTemp(pet, hasUser, canDonate, isOwner, onDelete));

    async function onDelete() {
        const choise = confirm('Are you sure you want to delete this pet?');
        if (choise) {
            await deletePet(id);
            ctx.page.redirect('/');
        }
    }
}