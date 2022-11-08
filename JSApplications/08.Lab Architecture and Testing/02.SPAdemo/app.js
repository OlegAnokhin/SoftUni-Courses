import { checkUserNav, onLogout } from "./auth.js";
import { showHomeView } from "./home.js";
import { showCatalogView } from "./catalog.js";
import { showLoginView } from "./login.js";
import { showRegisterView } from "./register.js";
import { showCreateView } from "./create.js";
import "./details.js";
import { showDetailsView } from "./details.js";

document.querySelector('nav').addEventListener('click', onNavigate)

const views = {
    "home-link": showHomeView,
    "catalog-link": showCatalogView,
    "login-link": showLoginView,
    "register-link": showRegisterView,
    "logout-link": onLogout,
    "create-link": showCreateView,
    "details-link": showDetailsView
};

checkUserNav();

goto("home-link");

function onNavigate(e){
    if(e.target.tagName == 'A'){
        const id = e.target.id;
        if(goto(id)){
            e.preventDefault();
        }
    }
}

function goto(viewName, ...params){
    const view = views[viewName];
    if(typeof view == 'function'){
        document.querySelector('main').replaceChildren();
        view({
            goto
        }, ...params);
        return true;
    }
    return false;
}