const host = "http://localhost:3030/";

async function requester(url, option) {
    try {
        //let response = await fetch(host + url, option);
        let response = await fetch(`${host}${url}`, option);
        if (!response.ok) {
            if (response.status === 403) {
                sessionStorage.removeItem("user");
            }
            const err = await response.json();
            throw new Error(err.message);
        }
        if (response.status === 204) {
            return response;
        } else {
            return response.json();
        }
    } catch (error) {
        alert(error.message)
        throw error
    }
}
function createOption(method = "GET", data) {
    const option = {
        method,
        headers: {}
    }
    if (data) {
        option.headers["Content-Type"] = "Application/json";
        option.body = JSON.stringify(data);
    }
    const user = JSON.parse(sessionStorage.getItem("user"));
    if (user) {
        // const token = user.accessToken;
        option.headers["X-Authorization"] = user.token;
    }
    return option;
}
export async function get(url) {
    return requester(url, createOption);
}
export async function post(url, data) {
    return requester(url, createOption("post", data));
}
export async function put(url, data) {
    return requester(url, createOption("put", data));
}
export async function del(url) {
    return requester(url, createOption("delete"));
}
const endpoint = {
    "login": "users/login",
    "register": "user/register",
    "logout": "users/logout"
}
export async function login(email, password) {
    let result = await post(endpoint.login, { email, password });
    let user = {
        email: result.email,
        id: result._id,
        token: result.accessToken
    }
    sessionStorage.setItem("user", JSON.stringify(user));
}
export async function register(email, password) {
    let result = await post(endpoint.register, { email, password });
    let user = {
        email: result.email,
        id: result._id,
        token: result.accessToken
    }
    sessionStorage.setItem("user", JSON.stringify(user));
}
export async function logout() {
    await get(endpoint.logout);
    sessionStorage.removeItem("user");
}