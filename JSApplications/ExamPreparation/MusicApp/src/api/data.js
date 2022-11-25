import {del, get, post, put} from './api.js'

export async function getAllData() {
    return get('/data/albums?sortBy=_createdOn%20desc&distinct=name');
}
export async function createData(item) {
    return post('/data/albums', item);
}
export async function getDataById(id) {
    return get('/data/albums/' + id);
}

export async function deleteData(id) {
    return del('/data/albums/' + id);
}
export async function updateData(id, item) {
    return put('/data/albums/' + id , item);
}
