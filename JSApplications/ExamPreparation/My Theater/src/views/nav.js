import { logout } from "../api/users.js";
import { html, render, page } from "../lib.js";
import { getUsedData } from "../util.js";

const nav = document.querySelector('header');
const navTemp = (hasUser) => html`
<nav>
    <a href="/">Theater</a>
    <ul>
        ${hasUser ? html`
        <li><a href="/profile">Profile</a></li>
        <li><a href="/create">Create Event</a></li>
        <li><a @click=${onLogout} href="javascript:void(0)">Logout</a></li>`
        : html`
        <li><a href="/login">Login</a></li>
        <li><a href="/register">Register</a></li>`}
    </ul>
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