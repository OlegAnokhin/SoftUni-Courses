// import { getSearchResult } from '../api/searchBonus.js';
// import { html } from '../lib.js';

// const searchTemp = (isClicked, makeSearch, result, hasUser) => html`
//     <section id="search">
//         <h2>Search by Brand</h2>
    
//         <form class="search-wrapper cf">
//             <input id="#search-input" type="text" name="search" placeholder="Search here..." required />
//             <button @click=${makeSearch} type="submit">Search</button>
//         </form>
    
//         <h3>Results:</h3>
//         <div id="search-container">
//         ${ isClicked ? createResultTemp(result, hasUser): nothing}
//         </div>   
//     </section>`
// const createResultTemp = (result, hasUser) => {
//     return html `
//      ${result.length > 0 ? 
//         html `${result.map(item => createCard(item, hasUser))}`:
//         html`<h2>There are no results found.</h2>`}
//         `
//     } 
// const createCard = (item, hasUser) => html`
//     <div id="search-container">
//         <ul class="card-wrapper">
//             <!-- Display a li with information about every post (if any)-->
//             <li class="card">
//                 <img src="./images/travis.jpg" alt="travis" />
//                 <p>
//                     <strong>Brand: </strong><span class="brand">Air Jordan</span>
//                 </p>
//                 <p>
//                     <strong>Model: </strong><span class="model">1 Retro High TRAVIS SCOTT</span>
//                 </p>
//                 <p><strong>Value:</strong><span class="value">2000</span>$</p>
//                 <a class="details-btn" href="">Details</a>
//             </li>
//         </ul>
//     </div>`
// export async function searchView(ctx) {
//     ctx.render(searchTemp(false, makeSearch));

//     async function makeSearch(event) {
//         const searchEl = document.getElementById("search-input");
//         const query = searchEl.value;

//         if(!query) {
//             return alert('Field are required!')
//         }
//         const result = await getSearchResult(query);
//         ctx.render(searchTemp(true, makeSearch, result, !!ctx.user))
//     }
// }