import {del, get, post, put} from './api.js'

export async function getAllData() {
    return get('/data/games?sortBy=_createdOn%20desc');
}
export async function getLatestData() {
    return get('/data/games?sortBy=_createdOn%20desc&distinct=category');
}
export async function createGame(game) {
    return post('/data/games', game);
}
export async function getGameById(id) {
    return get('/data/games/' + id);
}
export async function deleteGame(id) {
    return del('/data/games/' + id);
}
export async function updateGame(id, game) {
    return put('/data/games/' + id , game);
}
