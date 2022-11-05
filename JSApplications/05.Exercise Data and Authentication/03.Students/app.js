async function solve(e) {
    const url = `http://localhost:3030/jsonstore/collections/students`;
    const table = document.querySelector('tbody');
    const form = document.getElementById('form');

    form.addEventListener('submit', onSubmit);
    const response = await fetch(url);
    const data = await response.json();
    table.innerHTML = '';
    const allStudents = Object.values(data);
    allStudents.forEach(st => {
        let row = document.createElement('tr');
        for (let data in st) {
            if (data == '_id') {
                continue;
            }
            let cell = document.createElement('td');
            cell.textContent = st[data];
            row.appendChild(cell);
        }
        table.appendChild(row);
    });
    async function onSubmit(e) {
        e.preventDefault();
        let data = new FormData(form);
        let currStudent = Object.fromEntries(data.entries());
        if(Object.values(currStudent).includes('')){
            return;
        }
        let formText = document.querySelectorAll('input[type=text]');
        formText.forEach(i => i.value = "");
        await fetch(url, {
            method: 'POST',
            headers: { 
                'Content-Type': 'application/json' 
            },
            body: JSON.stringify(currStudent)
        });
        solve();
    }
}

solve();