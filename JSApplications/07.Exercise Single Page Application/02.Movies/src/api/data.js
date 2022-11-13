import * as api from './api.js';

export async function getAllMovies(){
    return api.get('/data/movies');
}
export async function createIdea(idea){
    return api.post('/data/movies', idea);
}
export async function updateMovie(id){
    return api.put('/data/movies/' + id);
}
export async function deleteById(id){
    return api.del('/data/movies/' + id);
}