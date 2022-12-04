import {del, get, post, put} from './api.js'

export async function getAllData() {
    return get('/data/books?sortBy=_createdOn%20desc');
}
export async function createItem(item) {
    return post('/data/books', item);
}
export async function getItemById(id) {
    return get('/data/books/' + id);
}
export async function deleteItem(id) {
    return del('/data/books/' + id);
}
export async function updateItem(id, item) {
    return put('/data/books/' + id , item);
}
export async function getAllUserBooks(userId) {
    return get(`/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`)
}
