import { logout } from "../api/users.js";
import { html, render, page } from "../lib.js";
import { getUsedData } from "../util.js";

const nav = document.querySelector('header');
const navTemp = (hasUser) => html`
        <a id="logo" href="/"
          ><img id="logo-img" src="./images/logo.jpg" alt=""
        /></a>

        <nav>
          <div>
            <a href="/dashboard">Dashboard</a>
          </div>
          ${hasUser 
                ? html`
        <div class="user">
            <a href="/create">Create Offer</a>
            <a @click=${onLogout} href="javascript:void(0)">Logout</a>
        </div>`
        : html`
        <div class="guest">
            <a href="/login">Login</a>
            <a href="/register">Register</a>
          </div>`}
        </nav>
`

export function updateNav() {
    const user = getUsedData();
    render(navTemp(user), nav);
}
function onLogout() {
    logout();
    updateNav();
    page.redirect('/dashboard')
}