import * as api from "./api.js";

const endpoint = {
    "login" : "users/login",
    "register" : "users/register",
    "logout" : "users/logout",
    "create" : "users/catalog",
    "all" : "users/catalog",
    "getItemById" : "users/catalog/",
    "myFurniture" : "users/catalog?where=_ownerId%3D%22",

}
export async function login(email, password) {
    const res = await api.post(endpoint.login, {email, password});
    sessionStorage.setItem("userData", JSON.stringify(res));
    return res;
}
export async function register(email, password) {
    const res = await api.post(endpoint.register, {email, password});
    sessionStorage.setItem("userData", JSON.stringify(res));
    return res;
}
export async function logout() {
    const res = await api.get(endpoint.logout);
    sessionStorage.removeItem("userData");
    return res;
}
export async function createItem(data) {
    const res = await api.post(endpoint.create, data);
    return res;
}
export async function getAllItem() {
    const res = await api.get(endpoint.all);
    return res;
}
export async function getItemById(id) {
    const res = await api.get(endpoint.getItemById + id);
    return res;
}
export async function updateById(id, data) {
    const res = await api.put(endpoint.getItemById + id, data);
    return res;
}
export async function deleteById(id) {
    const res = await api.del(endpoint.getItemById + id);
    return res;
}
export async function getMyItems() {
    const userData = JSON.parse(sessionStorage.getItem("userData"));
    const userId = userData && userData._id;
    let id = `${userId}%22`;
    const res = await api.get(endpoint.myFurniture + id);
    return res;
}