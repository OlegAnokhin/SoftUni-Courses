import { updateNav } from './views/nav.js';
import { page, render } from './lib.js';
import { getUsedData } from './util.js';
import { homeView } from './views/home.js';
import { dashboardView } from './views/dashboard.js';
import { loginView } from './views/login.js';
import { registerView } from './views/register.js';
import { createView } from './views/create.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';

const main = document.querySelector('main');

page(decorateContext);
page('/', homeView);
page('/dashboard', dashboardView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/details/:id', detailsView);
page('/edit/:id', editView);

updateNav();
page.start();

function decorateContext(ctx, next) {
    ctx.render = renderMain;
    ctx.updateNav = updateNav;

    const user = getUsedData();
    if(user) {
        ctx.user = user;
    }
    next();
}

function renderMain(result) {
    render(result, main)
}