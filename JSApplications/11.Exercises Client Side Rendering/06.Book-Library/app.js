import { html, render } from '../node_modules/lit-html/lit-html.js';
import * as data from "./data.js";

const body = document.querySelector('body');
function showHomeView() {
    let element = document.createDocumentFragment();
    element = html`
        <button id="loadBooks">LOAD ALL BOOKS</button>
        <table>
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Author</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody>
        
            </tbody>
        </table>
        
        <form id="add-form">
            <h3>Add book</h3>
            <label>TITLE</label>
            <input type="text" name="title" placeholder="Title...">
            <label>AUTHOR</label>
            <input type="text" name="author" placeholder="Author...">
            <input type="submit" value="Submit">
        </form>
        
        <form id="edit-form">
            <input type="hidden" name="id">
            <h3>Edit book</h3>
            <label>TITLE</label>
            <input type="text" name="title" placeholder="Title...">
            <label>AUTHOR</label>
            <input type="text" name="author" placeholder="Author...">
            <input type="submit" value="Save">
        </form>
      
    `
    render(element, body);
}
showHomeView()
const editForm = document.querySelector('#edit-form')
editForm.style.display = 'none';
document.getElementById('loadBooks').addEventListener('click', createBookCard);
document.querySelector('#add-form').addEventListener('submit', addBook)

async function createBookCard() {
    let result = await data.getAllItem();
    const tbody = document.querySelector('tbody');
    let element = document.createDocumentFragment();
    element = html`
        ${result.map(book => html`
        <tr .id=${book._id}>
            <td>${book.title}</td>
            <td>${book.author}</td>
            <td>
                <button .id='edit'>Edit</button>
                <button .id='delete'>Delete</button>
            </td>
        </tr>
        `)}`
    render(element, tbody);
    document.querySelector('tbody').addEventListener('click', checkBtn);
}
async function addBook(e) {
    e.preventDefault();
    const formData = new FormData(e.target);
    const { title, author } = Object.fromEntries(formData);
    if (title == '' || author == '') {
        return;
    }
    await data.createBook({ title, author });
    document.querySelector('[name="title"]').value = '';
    document.querySelector('[name="author"]').value = '';
    createBookCard();
}
function checkBtn(e) {
    if (e.target.tagName !== 'BUTTON') {
        return;
    }
    e.target.textContent == 'Edit' ? onEdit(e) : onDelete(e);
}
async function onDelete(e) {
    const id = e.target.parentElement.parentElement.id;
    data.deleteById(id)
    e.target.parentNode.parentNode.remove();
};

async function onEdit(e) {
    e.preventDefault();
    const id = e.target.parentElement.parentElement.id;
    const title = e.target.parentNode.parentNode.children[0].textContent;
    const author = e.target.parentNode.parentNode.children[1].textContent;
    const addForm = document.querySelector('#add-form');
    const editForm = document.querySelector('#edit-form');

    addForm.style.display = 'none';
    editForm.style.display = 'block';
    editForm.querySelector('[name="title"]').value = title;
    editForm.querySelector('[name="author"]').value = author;
    editForm.addEventListener('submit', onSave);

    async function onSave(e) {
        e.preventDefault();
        const title = editForm.querySelector('[name="title"]').value;
        const author = editForm.querySelector('[name="author"]').value;
        if (title == '' || author == '') {
            return;
        }
        await data.createBook({ title, author });
        editForm.querySelector('[name="title"]').value = '';
        editForm.querySelector('[name="author"]').value = '';
        data.deleteById(id)
        addForm.style.display = 'block';
        editForm.style.display = 'none';
        createBookCard();
    }
}