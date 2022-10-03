function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   let fieldList = Array.from(document.querySelectorAll('tbody tr'));
   let searchText = document.getElementById('searchField');

   function onClick() {
      for (let row of fieldList) {
         row.classList.remove('select');
         if (row.textContent.includes(searchText.value)) {
            row.className = 'select';
         }
      };
      searchText.value = '';   
   }
}