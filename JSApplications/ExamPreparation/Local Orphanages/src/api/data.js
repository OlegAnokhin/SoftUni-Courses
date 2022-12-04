import {del, get, post, put} from './api.js'

export async function getAllData() {
    return get('/data/posts?sortBy=_createdOn%20desc');
}
export async function createItem(item) {
    return post('/data/posts', item);
}
export async function getItemById(id) {
    return get('/data/posts/' + id);
}

export async function deleteItem(id) {
    return del('/data/posts/' + id);
}
export async function updateItem(id, item) {
    return put('/data/posts/' + id , item);
}
export async function getAllUserPosts(userId) {
    return get(`/data/posts?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`)
}
