import { html, render } from '../node_modules/lit-html/lit-html.js';
import { get } from './api.js';

async function solve() {
   let result = await get();
   let fieldList = document.querySelector('tbody');
   let element = document.createDocumentFragment();
   element = html`
   ${result.map(student => html`
   <tr>
      <td>${student.firstName} ${student.lastName}</td>
      <td>${student.email}</td>
      <td>${student.course}</td>
   </tr>
   `)}`
   render(element, fieldList);
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick(e) {
      let searchField = document.getElementById('searchField');
      let searchText = searchField.value;
      Array.from(fieldList.querySelectorAll('tr'))
         .forEach(row => {
            let currRow = Array.from(row.children)
            .map(child => child.textContent).join(' ');
            currRow.toLowerCase().includes(searchText.toLowerCase())
               ? row.setAttribute('class', 'select')
               : row.removeAttribute('class', 'select');
         })
      searchField.value = '';
   }
}
solve()