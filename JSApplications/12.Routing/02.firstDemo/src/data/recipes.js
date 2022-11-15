import { get } from "./api.js";

const endpoint = {
    'recipes': '/data/recipes',
    'byId': 'data/recipes/'
}

export async function getAll(){
return get(endpoint.recipes)
}

export async function getById(){
    return get(endpoint.byId + id)
}