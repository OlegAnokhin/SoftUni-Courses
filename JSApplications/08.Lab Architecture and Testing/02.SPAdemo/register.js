import { post } from './api.js';
import { checkUserNav } from './auth.js';
import { createSubmitHandler, setUserData } from './util.js';

document.getElementById('register-form').addEventListener('submit', onRegister);
createSubmitHandler('register-form', onRegister)

const section = document.getElementById('register-view');
section.remove();
let ctx = null;

export function showRegisterView(inCtx) {
    ctx = inCtx;
    document.querySelector('main').appendChild(section);
}

async function onRegister({ email, username, password, repass }) {
        if(password != repass){
            return alert('Password don\'t match!')
        }
        const userdata = await post('/users/register', { email, username, password });
        setUserData(userdata);
        checkUserNav();
        ctx.goto("catalog-link");
}