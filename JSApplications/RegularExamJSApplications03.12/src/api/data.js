import {del, get, post, put} from './api.js'

export async function getAllData() {
    return get('/data/albums?sortBy=_createdOn%20desc');
}
export async function createItem(item) {
    return post('/data/albums', item);
}
export async function getItemById(id) {
    return get('/data/albums/' + id);
}
export async function deleteItem(id) {
    return del('/data/albums/' + id);
}
export async function updateItem(id, item) {
    return put('/data/albums/' + id , item);
}