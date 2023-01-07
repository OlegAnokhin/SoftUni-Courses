import page from '../../node_modules/page/page.mjs';
import {render} from '../../node_modules/lit-html/lit-html.js';
import { logout } from './api/data.js';
import { homeView } from './api/views/homeView.js';
import { loginView } from './api/views/loginView.js';
import { registerView } from './api/views/registerView.js';
import { browseView } from './api/views/browseView.js';
import { editView } from './api/views/editView.js';
import { myTeamView } from './api/views/myTeamsView.js';
import { teamHomeView } from './api/views/teamHomeView.js';
import { createView } from './api/views/createView.js';

const rootElement = document.getElementsByTagName('main')[0];


page("/",middleWare, homeView);
page("/index.html",middleWare, homeView);
page("/login",middleWare, loginView);
page("/register",middleWare, registerView);
page("/browse",middleWare, browseView);
page("/edit/:id",middleWare, editView);
page("/my-team",middleWare, myTeamView);
page("/details/:id",middleWare, teamHomeView);
page("/create",middleWare, createView);

page.start();
updateNav();


function middleWare(ctx, next) {
    //ctx.render = (content) => render(content, rootElement);
    ctx.render = myRender
    ctx.updateNav = updateNav;
    next()
}
document.querySelector('.logout').addEventListener('click',async (e)=>{
    e.preventDefault();
    await logout();
    updateNav();
    page.redirect('/');
})
function updateNav() {
    const userData = JSON.parse(sessionStorage.getItem('userdata'));
    if(userData) {
        document.querySelectorAll('.user').forEach(x=>x.getElementsByClassName.display = 'block');
        document.querySelectorAll('.guest').forEach(x=>x.getElementsByClassName.display = 'none');
    } else {
        document.querySelectorAll('.user').forEach(x=>x.getElementsByClassName.display = 'none');
        document.querySelectorAll('.guest').forEach(x=>x.getElementsByClassName.display = 'block');
    }
}
function myRender(content) {
    render(content, rootElement)
}