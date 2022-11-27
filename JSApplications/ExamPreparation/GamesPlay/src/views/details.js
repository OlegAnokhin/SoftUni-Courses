import { deleteGame, getGameById, getComments, createComment } from '../api/data.js';
import { html, nothing } from '../lib.js';

const detailsTemp = (game, hasUser, isOwner, onDelete, onSubmit, comments) => html`
<section id="game-details">
  <h1>Game Details</h1>
  <div class="info-section">

    <div class="game-header">
      <img class="game-img" src=${game.imageUrl} />
      <h1>${game.title}</h1>
      <span class="levels">MaxLevel: ${game.maxLevel}</span>
      <p class="type">${game.category}</p>
    </div>

    <p class="text">
    ${game.summary}
    </p>

    <div class="details-comments">
      <h2>Comments:</h2>
      <ul>
    ${comments.length == 0 ? html`
    <p class="no-comment">No comments.</p>` 
    : comments.map(comm => html`
    <li class="comment">
      <p>${comm.comment}</p>
    </li>`)}
      </ul>      
    </div>
    ${isOwner ? html`
    <div class="buttons">
      <a href="/edit/${game._id}" class="button">Edit</a>
      <a @click=${onDelete} href="javascript:void(0)" class="button">Delete</a>
    </div>` : nothing}
  </div>

  ${(() => {
    if(hasUser && !isOwner) {
  return html` 
  <article class="create-comment">
    <label>Add new comment:</label>
    <form @submit=${onSubmit} class="form">
      <textarea name="comment" placeholder="Comment......"></textarea>
      <input class="btn submit" type="submit" value="Add Comment">
    </form>
  </article>`}
})()}
</section>`

export async function detailsView(ctx) {
  const id = ctx.params.id
  const game = await getGameById(id);
  const comments = await getComments(id);
  const hasUser = !!ctx.user;
  const isOwner = hasUser && ctx.user.id == game._ownerId;
  ctx.render(detailsTemp(game,hasUser, isOwner, onDelete, onSubmit, comments));

  async function onDelete() {
    const choise = confirm('Are you sure you want to delete this game?');
    if (choise) {
      await deleteGame(id);
      ctx.page.redirect('/');
    }
  }
  async function onSubmit(event) {
    event.preventDefault();
    const formData = new FormData(event.target);
    const currComment = {
      gameId: id,
      comment: formData.get('comment')
    };
    if (currComment.comment == '') {
      return alert('The field are requared!')
    }
    await createComment(currComment);
    const comments = await getComments(id);
    event.target.reset();
    ctx.render(detailsTemp(game,hasUser, isOwner, onDelete, onSubmit, comments));
  }
}