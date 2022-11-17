import { html } from "../../../node_modules/lit-html/lit-html.js";
import {getItemById, deleteById} from "../api/data.js"
let context = null;

export async function detailsView(ctx){
    context = ctx;
    const id = ctx.params.id;
    const item = await getItemById(id);
    const userData = JSON.parse(sessionStorage.getItem("userData"));

    ctx.render(createDetailsTemp(item, userData._id === item._ownerId, deleteItemById))
}
async function deleteItemById(e) {
    e.preventDefault();
    const id = e.targer.dataset.id;
    await deleteById(id);
    context.page.redirect('/')
}
function renderOwnerBtn(isOwner, deleteItemById, id){
    
    return isOwner ? html`
                <div>
                    <a href="/edit/${id}" class="btn btn-info">Edit</a>
                    <a @click=${deleteItemById} data-id=${id} href=”javascript:void(0)” class="btn btn-red">Delete</a>
                </div>
    ` : "";
}

function createDetailsTemp(item, isOwner, deleteItemById){
    const itemImgArr = item.img.split("/")
    return html`
    <div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                        <img src=${"/images/" + itemImgArr[itemImgArr.lenght - 1]} />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                <p>Make: <span>${item.make}</span></p>
                <p>Model: <span>${item.model}</span></p>
                <p>Year: <span>${item.year}</span></p>
                <p>Description: <span>${item.description}</span></p>
                <p>Price: <span>${item.price} $</span></p>
                <p>Material: <span>${item.material}</span></p>                
            ${renderOwnerBtn(isOwner,deleteItemById, item._id)}
            </div>
        </div>
    `
}