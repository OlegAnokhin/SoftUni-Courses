import { logout } from "../api/users.js";
import { html, render, page } from "../lib.js";
import { getUsedData } from "../util.js";

const nav = document.querySelector('header');
const navTemp = (hasUser) => html`
    <h1><a class="home" href="/">GamesPlay</a></h1>
    <nav>
      <a href="/catalog">All games</a>
      ${hasUser ? html`
      <div id="user">
        <a href="/create">Create Game</a>
        <a @click=${onLogout} href="javascript:void(0)">Logout</a>
      </div>` : html`
      <div id="guest">
        <a href="/login">Login</a>
        <a href="/register">Register</a>
      </div>`}
    </nav>`

export function updateNav() {
  const user = getUsedData();
  render(navTemp(user), nav);
}
function onLogout() {
  logout();
  updateNav();
  page.redirect('/')
}