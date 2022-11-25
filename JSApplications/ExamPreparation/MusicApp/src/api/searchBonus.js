import { get } from "./api.js";

export async function getSearchResult(query) {
    // const url = '/data/albums?where=name'
    // return get(url + encodeURIComponent(`LIKE "${query}"`));
    return get(`/data/albums?where=name%20LIKE%20%22${query}%22`);
}
