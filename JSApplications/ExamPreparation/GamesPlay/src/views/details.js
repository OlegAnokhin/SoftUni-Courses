import { deleteGame, getGameById } from '../api/data.js';
import { html, nothing } from '../lib.js';

const detailsTemp = (game, isOwner, onDelete) => html`
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

    <!-- Bonus ( for Guests and Users ) -->
    <!-- <div class="details-comments">
      <h2>Comments:</h2>
      <ul> -->
        <!-- list all comments for current game (If any) -->
        <!-- <li class="comment">
          <p>Content: I rate this one quite highly.</p>
        </li>
        <li class="comment">
          <p>Content: The best game.</p>
        </li>
      </ul> -->
      <!-- Display paragraph: If there are no games in the database -->
      <!-- <p class="no-comment">No comments.</p>
    </div> -->
    ${isOwner ? html`
    <div class="buttons">
      <a href="/edit/${game._id}" class="button">Edit</a>
      <a @click=${onDelete} href="javascript:void(0)" class="button">Delete</a>
    </div>` : nothing}
  </div>

  <!-- Bonus -->
  <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
  <!-- <article class="create-comment">
    <label>Add new comment:</label>
    <form class="form">
      <textarea name="comment" placeholder="Comment......"></textarea>
      <input class="btn submit" type="submit" value="Add Comment">
    </form>
  </article> -->

</section>`

export async function detailsView(ctx) {
  const id = ctx.params.id
  const game = await getGameById(id);

  const hasUser = !!ctx.user;
  const isOwner = hasUser && ctx.user.id == game._ownerId;
  ctx.render(detailsTemp(game, isOwner, onDelete));

  async function onDelete() {
    const choise = confirm('Are you sure you want to delete this game?');
    if (choise) {
      await deleteGame(id);
      ctx.page.redirect('/');
    }
  }
}