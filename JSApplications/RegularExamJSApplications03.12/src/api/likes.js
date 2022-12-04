import { post, get } from "./api.js";

export async function likeTheater(albumId) {
    return await post(`/data/likes`, albumId);
}
export async function getTotalLikesCount(albumId) {
    return await get(`/data/likes?where=albumId%3D%22${albumId}%22&distinct=_ownerId&count`);
}
export async function didUserLike(albumId, userId){
    return await get(`/data/likes?where=albumId%3D%22${albumId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}