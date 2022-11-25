import { deleteOffer, getOfferById } from '../api/data.js';
import { html, nothing } from '../lib.js';

const detailsTemp = (offer, isOwner, onDelete) => html`
    <section id="details">
          <div id="details-wrapper">
            <img id="details-img" src=${offer.imageUrl} alt="example1" />
            <p id="details-title">${offer.title}</p>
            <p id="details-category">
              Category: <span id="categories">${offer.category}</span>
            </p>
            <p id="details-salary">
              Salary: <span id="salary-number">${offer.salary}</span>
            </p>
            <div id="info-wrapper">
              <div id="details-description">
                <h4>Description</h4>
                <span
                  >${offer.description}</span
                >
              </div>
              <div id="details-requirements">
                <h4>Requirements</h4>
                <span
                  >${offer.requirements}</span
                >
              </div>
            </div>
            <!-- <p>Applications: <strong id="applications">1</strong></p> -->

            ${isOwner ? html`
            <div id="action-buttons">
              <a href="/edit/${offer._id}" id="edit-btn">Edit</a>
              <a @click=${onDelete} href="javascript:void(0)" id="delete-btn">Delete</a>` : nothing}

              <!--Bonus - Only for logged-in users ( not authors )-->
              <!-- <a href="" id="apply-btn">Apply</a> -->
            </div>
          </div>
        </section>`

export async function detailsView(ctx) {
    const id = ctx.params.id
    const offer = await getOfferById(id);

    const hasUser = !!ctx.user;
    const isOwner = hasUser && ctx.user.id == offer._ownerId;
    ctx.render(detailsTemp(offer, isOwner, onDelete));

    async function onDelete() {
        const choise = confirm('Are you sure you want to delete this item?');
        if (choise) {
            await deleteOffer(id);
            ctx.page.redirect('/dashboard');
        }
    }
}