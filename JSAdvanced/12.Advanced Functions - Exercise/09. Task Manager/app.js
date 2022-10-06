function solve() {    
    document.getElementsByTagName("form")[0].addEventListener("submit", createTask);
    let sections = Array.from(document.getElementsByTagName("section"));
    let openSec = sections[1];
    let inProgresSec = sections[2];
    let completeSec = sections[3];

    function createTask(e){        
        e.preventDefault()
        let form = e.target;
        let title = form.elements[0].value;
        let description = form.elements[1].value;
        let data = form.elements[2].value;
        if(title.length === 0 || description.length === 0 || data.length === 0){
            return;
        }
        let newArticle = createPartialArticle(title, description, data, {class:"green", text:"Start"},{class:"red", text:"Delete"});
        openSec.children[1].appendChild(newArticle);
        updateEventListener();
    }
    function updateEventListener(){
        Array.from(document.getElementsByTagName("button")).forEach(button => {
            button.addEventListener("click", despachHandler)
        })
    }

    function createPartialArticle(title, description, data, firstButtonInfo, secondButtonInfo){
        let buttons = createPartialButton(firstButtonInfo, secondButtonInfo);
        let article = document.createElement("article");
        let innerHTML = `<h3>${title}</h3>` +
                        `<p>Description: ${description}</p>` +
                        `<p>Due Date: ${data}</p>` +
                        buttons  ;                        
        article.innerHTML = innerHTML;
        //article.addEventListener("click", despachHandler)
        return article;                
    }
    function createPartialButton(firstButtonInfo, secondButtonInfo){
        let buttons = `<div class="flex">` +
                      `<button class="${firstButtonInfo.class}" >${firstButtonInfo.text}</button>` +
                      `<button class="${secondButtonInfo.class}">${secondButtonInfo.text}</button>` +
                      `</div>`
        return buttons;
    }
    function despachHandler(e){
        if(e.target.innerText === "Add"){
            return;
        }
        let cmdObj = cmd(e);
        let text = e.target.innerText.toLowerCase();
        cmdObj[text](e);
    }
    function cmd(e){
        let art = e.target.parentElement.parentElement;
        return {
            start: function(e){                
                inProgresSec.children[1].appendChild(art);
                e.target.parentElement.remove();
                art.innerHTML += createPartialButton({class:"red", text: "Delete"},{class:"orange", text:"Finish"});
                updateEventListener();
            },
            delete: function(e){
                art.remove();
            },
            finish: function(e){
                completeSec.children[1].appendChild(art);
                e.target.parentElement.remove();
            }
        }
    }
}