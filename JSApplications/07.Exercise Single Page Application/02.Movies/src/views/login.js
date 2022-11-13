import { login } from '../api/api.js';

export async function showLoginView(context) {
    [...document.querySelectorAll('section')].forEach(s => s.style.display = 'none');
    document.getElementById("form-login").style.display = 'block';
    debugger
    //let section = document.getElementById("form-login");
    let ctx = null;
    ctx = context;
    // context.showSection(section);

    // export function showLogin(context){

    // }
    const form = document.getElementById('login-form');
    form.addEventListener('submit', onSubmit);

    async function onSubmit(e) {
        debugger
        e.preventDefault();
        let formData = new FormData(form);
        let email = formData.get('email').trim();
        let password = formData.get('password').trim();
        await login(email, password);
        form.reset();
        ctx.updateNavigation();
        ctx.goTo('home');
    }
}