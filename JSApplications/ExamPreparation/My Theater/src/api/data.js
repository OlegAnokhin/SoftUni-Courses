import {del, get, post, put} from './api.js'

export async function getAllData() {
    return get('/data/theaters?sortBy=_createdOn%20desc&distinct=title');
}
export async function createItem(item) {
    return post('/data/theaters', item);
}
export async function getItemById(id) {
    return get('/data/theaters/' + id);
}
export async function deleteItem(id) {
    return del('/data/theaters/' + id);
}
export async function updateItem(id, item) {
    return put('/data/theaters/' + id , item);
}
export async function getUserTheaters(userId) {
    return get(`/data/theaters?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`)
}
