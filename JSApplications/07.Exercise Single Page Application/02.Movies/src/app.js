 import { showHomeView } from './views/home.js';
 import { showLoginView } from './views/login.js';
// import { showRegister } from './src/views/register.js';
// import { showCatalog } from './src/views/catalog.js';
// import { showCreate } from './src/views/create.js';
// import { showDetails } from './src/views/details.js';
 import { logout } from './api/api.js';

//let main = document.querySelector('main');

let links = {
    "Home": "home",
    "Login": "login",
    // 'registerLink': 'register',
    // 'createLink': 'create',
    // 'catalogLink': 'catalog',
    // 'detailsLink': 'details'
}
let views = {
    "home": showHomeView,
    "login": showLoginView,
    // 'register': showRegister,
    // 'catalog': showCatalog,
    // 'create': showCreate,
    // 'details': showDetails,
}
showHomeView()
//let nav = document.querySelectorAll("ul li");

let nav = document.getElementsByClassName("navbar")[0]
nav.addEventListener('click', onNavigation);

async function onLogout(e) {
    debugger
    await logout();
    updateNavigation();
    goTo('home');
}
function onNavigation(e) {
    e.preventDefault();
    if (e.target.id == 'logoutBtn') {
        onLogout();
    } else {
        let name = links[e.target.parentElement.innerText];        
        goTo(name);     
    }
}
function goTo(name, ...params) {
    debugger
    let view = views[name];
    view(context, ...params);
}
let context = {
   // showSection,
    updateNavigation,
    goTo
}
// function showSection(name) {
//     main.replaceChildren(name);
// }

function updateNavigation() {
    let userData = JSON.parse(sessionStorage.getItem('userData'));
    if (userData != null) {
        //document.getElementById('welcome-msg').textContent = `Welcome, ${username}!`;
        [...nav.querySelectorAll('.user')].forEach(el => el.style.display = 'block');
        [...nav.querySelectorAll('.guest')].forEach(el => el.style.display = 'none');
    } else {        
        [...nav.querySelectorAll('.user')].forEach(el => el.style.display = 'none');
        [...nav.querySelectorAll('.guest')].forEach(el => el.style.display = 'block');
    }
}
updateNavigation();
