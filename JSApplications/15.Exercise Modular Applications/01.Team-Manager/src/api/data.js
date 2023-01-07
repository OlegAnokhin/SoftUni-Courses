import * as api from "./api.js";

const endpoint = {
    "login": "users/login",
    "register": "users/register",
    "logout": "users/logout",
    "getAllTeams": "data/teams",
    "getAllMembers": "data/members?where=status%3D%22member%22",
    "createTeam": "data/teams",
    "teamsInfo": "data/teams/",
    "memberRequest": "data/members",
   // "memberRequest": "data/members/",    

}
export async function register(email, username, password) {
    const res = await api.post(endpoint.register, { email, username, password });
    sessionStorage.setItem("userData", JSON.stringify(res));
    return res;
}
export async function login(email, password) {
    const res = await api.post(endpoint.login, { email, password });
    sessionStorage.setItem("userData", JSON.stringify(res));
    return res;
}
export async function logout() {
    const res = await api.get(endpoint.logout);
    sessionStorage.removeItem("userData");
    return res;
}
export async function getAllTeams() {
    const res = await api.get(endpoint.getAllTeams);
    return res;
}
export async function getAllMembers() {
    const res = await api.get(endpoint.getAllMembers);
    return res;
}
export async function createTeam(name, imageUrl, description) {
    const res = await api.post(endpoint.createTeam, {name, imageUrl, description});
    return res;
}
export async function teamsInfo(id) {
    const res = await api.get(endpoint.teamsInfo + id);
    return res;
}
export async function updateTEamInfo(id, name, imageUrl, description) {
    const res = await api.put(endpoint.teamsInfo + id, {name, imageUrl, description});
    return res;
}
export async function memberRequest(teamId) {
    const res = await api.post(endpoint.memberRequest, {teamId});
    return res;
}
// export async function aproveRequest(teamId) {
//     const res = await api.post(endpoint.memberRequest, {teamId});
//     return res;
// }

