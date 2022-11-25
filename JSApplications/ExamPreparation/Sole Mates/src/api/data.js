import {del, get, post, put} from './api.js'

export async function getAllData() {
    return get('/data/shoes?sortBy=_createdOn%20desc');
}
export async function createData(item) {
    return post('/data/shoes', item);
}
export async function getDataById(id) {
    return get('/data/shoes/' + id);
}

export async function deleteData(id) {
    return del('/data/shoes/' + id);
}
export async function updateData(id, item) {
    return put('/data/shoes/' + id , item);
}
