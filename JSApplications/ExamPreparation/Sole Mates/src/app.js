import { updateNav } from './views/nav.js';
import { page, render } from './lib.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { registerView } from './views/register.js';
import { dashboardView } from './views/dashboard.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { createView } from './views/create.js';
import { getUsedData } from './util.js';
//import { searchView } from './views/search.js';


const main = document.querySelector('main');

page(decorateContext);
page('/', homeView);
page('/dashboard', dashboardView);
page('/dashboard/:id', detailsView);
page('/edit/:id', editView);
page('/create', createView);
page('/login', loginView);
page('/register', registerView);
//page('/search', searchView);

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
