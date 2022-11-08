import { post } from './api.js';
import { checkUserNav } from './auth.js';
import { createSubmitHandler } from './util.js';

createSubmitHandler('login-form', onLogin);
const section = document.getElementById('login-view');
section.remove();
let ctx = null;

export function showLoginView(inCtx) {
    ctx = inCtx;
    document.querySelector('main').appendChild(section);
}
async function onLogin({ email, password }) {
        const userdata = await post('/users/login', { email, password });
        setUserData(userdata);
        checkUserNav();
        ctx.goto("catalog-link");
}