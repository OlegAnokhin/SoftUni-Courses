import { post, get } from "./api.js";

export async function getMyPosts(userId) {
    return await get(`/data/posts?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}
export async function donationPost(listingId) {
    return await post(`/data/donations`, listingId);
}
export async function getTotalDonationCount(petId) {
    return await get(`/data/donations?where=postId%3D%22${petId}%22&distinct=_ownerId&count`);
}
export async function didUserDonation(listingId, userId){
    return await get(`/data/donations?where=postId%3D%22${listingId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}