import page from "../node_modules/page/page.mjs";
import {render} from "../node_modules/lit-html/lit-html.js"
import { showAbout } from "./views/about.js";
import { showCatalog } from "./views/catalog.js";
import { showContact } from "./views/contact.js";
import { showHome } from "./views/home.js";
import { notFound } from "./views/notFound.js";
import{showDetails} from "./views/details.js";


function decorateContext(ctx, next) {
    ctx.render = function(content) {
        render(content, document.querySelector('main'));
    }
    next()
}
page(decorateContext)
page('/index.html','/');
page('/', showHome);
page('/catalog', showCatalog);
page('/catalog/:id', showDetails);
page('/about', showAbout);
page('/contact*', showContact);
page('*', notFound);

page.start();