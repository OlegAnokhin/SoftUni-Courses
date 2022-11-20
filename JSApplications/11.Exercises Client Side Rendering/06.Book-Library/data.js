import * as api from "./api.js";

const endpoint = {    
    "getAll" : "collections/books",
    "create" : "collections/books",
    "getBookById" : "collections/books/"
}
export async function getAllItem() {
    const res = await api.get(endpoint.getAll);
    return [...Object.values(res)];
}
export async function createBook(data) {
    const res = await api.post(endpoint.create, data);
    return [...Object.values(res)];
}
export async function getBookById(id) {
    const res = await api.get(endpoint.getBookById + id);
    return [...Object.values(res)];
}
export async function updateById(id, data) {
    const res = await api.put(endpoint.getBookById + id, data);
    return [...Object.values(res)];
}
export async function deleteById(id) {
    const res = await api.del(endpoint.getBookById + id);
    return [...Object.values(res)];
}