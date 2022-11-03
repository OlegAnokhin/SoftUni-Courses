window.addEventListener("DOMContentLoaded", onLoadHTML);
document.getElementById('addForm').addEventListener('submit', createCatch);
document.getElementById("logout").addEventListener('click', onLogout);
document.querySelector(".load").addEventListener('click', onLoadCatch);



async function onLogout(){
    const url = `http://localhost:3030/users/logout`;
    const header = getHeader("GET", "");
    const response = await fetch(url, header);
    sessionStorage.clear();
    onLoadHTML();
}
function onLoadHTML(){
    const token = sessionStorage.getItem("accessToken");
    const username = document.querySelector("p.email span");
    const addBtn = document.querySelector(".add");
    if(token){
        document.getElementById("guest").style.display = "none";
        document.getElementById("user").style.display = "inline-block";
        username.innerHTML = sessionStorage.getItem("email");
        addBtn.disabled = false;
    } else{
        document.getElementById("guest").style.display = "inline-block";
        document.getElementById("user").style.display = "none";
        username.innerHTML = "guest"
        addBtn.disabled = true;
    }
}
async function onLoadCatch(){
    const url = `http://localhost:3030/data/catches`;
    const response = await fetch(url);
    const data = await response.json();
    //render
    return data; 
}
function createCatch(e){
    e.preventDefault();
    const form = e.target;
    const formData =  new FormData(form);
    const data = Object.fromEntries(formData);
    onCreateCatch(data);
}
 async function onCreateCatch(body){
    const url = `http://localhost:3030/data/catches`;
    const header = getHeader("POST", body); 
    const response = await fetch(url, header);
    const data = await response.json();
    return data;
}
function getHeader(method, body){
    const token = sessionStorage.getItem("accessToken");
    const header = {
        method: `${method}`,
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': token
        },
        //body: !! body ? JSON.stringify(body): ""
    }
    if(body){
        header.body = JSON.stringify(body)
    }
    return header;
}