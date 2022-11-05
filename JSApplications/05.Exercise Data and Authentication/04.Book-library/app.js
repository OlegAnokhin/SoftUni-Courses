function solve() {
    const url = `http://localhost:3030/jsonstore/collections/books`;
    const loadBtn = document.getElementById("loadBooks");
    loadBtn.addEventListener('click', onLoadAllBooks);
    const table = document.querySelector('tbody');
    table.addEventListener('click', onModify);
    const addForm = document.querySelector('form');
    addForm.addEventListener('click', onSubmit);
    let editId = '';

    async function onSubmit(e) {
        e.preventDefault();
        if (e.target.tagName !== 'BUTTON') {
            return;
        }
        if (e.target.textContent == 'Save') {
            onSave(e);
            return;
        }
        let { title, author } = Object.fromEntries(new FormData(addForm).entries());
        if (title == '' || author == '') {
            return;
        }
        await fetch(url, {
            method: 'post',
            headers: { 
                'Content-Type': 'application/json' 
            },
            body: JSON.stringify({ title, author })
        });
        document.querySelector('[name="title"]').value = '';
        document.querySelector('[name="author"]').value = '';
        onLoadAllBooks();
    }    
    async function onSave(e) {
        debugger
        let { title, author } = Object.fromEntries(new FormData(addForm).entries());
        if (title == '' || author == '') {
            return;
        }
        document.querySelector('form h3').textContent = 'FORM';
        document.querySelector('form button').textContent = 'Submit';
        await fetch(`${url}/${editId}`, {
            method: 'put',
            headers: { 
                'Content-Type': 'application/json' 
            },
            body: JSON.stringify({ title, author })
        });
        document.querySelector('[name="title"]').value = '';
        document.querySelector('[name="author"]').value = '';
        onLoadAllBooks();
    }
    async function onLoadAllBooks() {
        const response = await fetch(url);
        const data = Object.entries(await response.json());
        table.innerHTML = '';
        for (const [key, { author, title }] of data) {
            let row = document.createElement('tr');
            row.appendChild(createTag('td', title));
            row.appendChild(createTag('td', author));
            let actionElement = document.createElement('td');
            let editBtn = createTag('button', 'Edit', null, key);
            let deleteBtn = createTag('button', 'Delete', null, key);
            actionElement.appendChild(editBtn);
            actionElement.appendChild(deleteBtn);
            row.appendChild(actionElement);
            table.appendChild(row)
        }
    }
    async function onEdit(e) {
        editId = e.target.id;
        let title = e.target.parentNode.parentNode.children[0].textContent;
        let author = e.target.parentNode.parentNode.children[1].textContent;
        document.querySelector('[name="title"]').value = title;
        document.querySelector('[name="author"]').value = author;
        document.querySelector('form h3').textContent = 'Edit FORM';
        document.querySelector('form button').textContent = 'Save';
        e.target.parentNode.parentNode.remove();
    };
    async function onDelete(e) {
        await fetch(`${url}/${e.target.id}`, {
            method: 'delete',
        });
        e.target.parentNode.parentNode.remove();
    };
    function onModify(e) {
        if (e.target.tagName !== 'BUTTON') {
            return;
        }
        e.target.textContent == 'Edit' ? onEdit(e) : onDelete(e);
    }
    function createTag(tag, text = null, className = null, id = null, type = null) {
        let el = document.createElement(tag);
        if (text) { el.textContent = text; }
        if (type) { el.type = type; }
        if (id) { el.id = id; }
        if (className) { el.className = className; }
        return el;
    }
}
solve();