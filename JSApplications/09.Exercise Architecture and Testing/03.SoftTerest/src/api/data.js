import * as api from './api.js';
const endpoints = {
    "getAllIdea" : "data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc",
    "createIdea" : "data/ideas",
    "getById" : "data/ideas/"
}
export async function getAllIdea(){
    return api.get(endpoints.getAllIdea);
}
export async function createIdea(data){
    return api.post(endpoints.createIdea, data);
}
export async function getById(id){
    return api.get(endpoints.getById, + id);
}
export async function deleteById(id){
    return api.del(endpoints.getById, + id);
}