function attachEvents() {
    document.getElementById("btnLoad").addEventListener('click', onLoadAllRec);
    document.getElementById("btnCreate").addEventListener('click', handleCreateRec);
}
function handleCreateRec(){
    const personEl = document.getElementById("person");
    const phoneEl = document.getElementById("phone");
    onCreateRecord(personEl.value, phoneEl.value);
    personEl.value = "";
    phoneEl.value = "";
}
function renderRec(data){
    const ul = document.getElementById('phonebook');
    ul.innerHTML = "";
    Object.values(data).forEach(rec => {
        const li = document.createElement('li');
        li.textContent = `${rec.person}: ${rec.phone}`;
        li.setAttribute('data-id', rec._id);
        const btn = document.createElement("button");
        btn.textContent = "Delete";  
        btn.addEventListener('click', HandleDelete)   
        li.appendChild(btn);   
        ul.appendChild(li);
    })
}
function HandleDelete(e){
    const li = e.target.parentElement;
    const id = li.getAttribute("data-id");
    onDeleteRec(id);
    li.remove();    
}
async function onLoadAllRec(){
    const url = `http://localhost:3030/jsonstore/phonebook`;
    const response = await fetch(url);
    const data = await response.json();
    return renderRec(data);
}
async function onCreateRecord(person , phone){
    const url = `http://localhost:3030/jsonstore/phonebook`;
    const body = {
        person,
        phone
    }
    const header = getHeader("POST", body)
    const response = await fetch(url, header);
    const data = await response.json();
    onLoadAllRec();
    return data;
}
async function onDeleteRec(id){
    const url = `http://localhost:3030/jsonstore/phonebook/${id}`;
    const headers = getHeader("DELETE", null);
    const response = await fetch(url, headers);
    const data = await response.json();
    return data;
}
function getHeader(method, body){
    return {
        method: `${method}`,
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(body)
    }
}
attachEvents();