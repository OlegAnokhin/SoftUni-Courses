import { post, get } from "./api.js";

// export async function getMyPosts(userId) {
//     return await get(`/data/posts?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
// }
export async function likeBook(bookId) {
    return await post(`/data/likes`, bookId);
}
export async function getTotalLikesCount(bookId) {
    return await get(`/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`);
}
export async function didUserLike(bookId, userId){
    return await get(`/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}