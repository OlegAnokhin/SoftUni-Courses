import { updateNav } from './views/nav.js';
import { page, render } from './lib.js';
import { getUsedData } from './util.js';
import { homeView } from './views/home.js';
import { loginView } from './views/login.js';
import { registerView } from './views/register.js';
import { catalogView } from './views/catalog.js';
import { detailsView } from './views/details.js';
import { editView } from './views/edit.js';
import { createView } from './views/create.js';
import { searchView } from './views/search.js';


const main = document.querySelector('main');

page(decorateContext);
page('/', homeView);
page('/home', homeView);
page('/catalog', catalogView);
page('/catalog/:id', detailsView);
page('/edit/:id', editView);
page('/create', createView);
page('/login', loginView);
page('/register', registerView);
page('/search', searchView);
page('*', homeView);

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
