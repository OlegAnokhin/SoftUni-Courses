function solve() {
    let repository = document.getElementById("recipientName");
    let title = document.getElementById("title");
    let message = document.getElementById("message");
    let submitBtn = document.getElementById('add');
    submitBtn.addEventListener('click', createTask);
    let resetBtn = document.getElementById('reset');
    resetBtn.addEventListener('click', clearFields);

    function createTask(e) {
        e.preventDefault();
        let repositoryValue = repository.value;
        let titleValue = title.value;
        let messageValue = message.value;
        if (!repositoryValue || !titleValue || !messageValue) {
            return;
        }
        repository.value = "";
        title.value = "";
        message.value = "";
        createOrder(repositoryValue, titleValue, messageValue);
    }
    function clearFields(e) {
        e.preventDefault();
        repository.value = "";
        title.value = "";
        message.value = "";
    }
    function createOrder(repositoryValue, titleValue, messageValue) {
        let listOfMails = document.getElementById("list");
        let liContainer = document.createElement("li");
        let h1 = document.createElement("h4");
        h1.textContent = `Title: ${titleValue}`;
        let h2 = document.createElement("h4");
        h2.textContent = `Recipient Name: ${repositoryValue}`;
        let span = document.createElement("span");
        span.textContent = `${messageValue}`;
        let div = document.createElement("div");
        div.id = "list-action";
        let sendBtn = document.createElement("button");
        sendBtn.type = "submit";
        sendBtn.id = "send";
        sendBtn.textContent = "Send";
        sendBtn.addEventListener("click", sendMails);
        let deleteBtn = document.createElement("button");
        deleteBtn.type = "submit";
        deleteBtn.id = "delete";
        deleteBtn.textContent = "Delete";
        deleteBtn.addEventListener("click",(e)=> deleteMails(e));
        liContainer.appendChild(h1);
        liContainer.appendChild(h2);
        liContainer.appendChild(span);
        div.appendChild(sendBtn);
        div.appendChild(deleteBtn);
        liContainer.appendChild(div);
        listOfMails.appendChild(liContainer);

        function sendMails() {
            let sendMailEl = document.querySelector(".sent-list");
            let li2Container = document.createElement("li");
            let span1 = document.createElement("span");
            span1.textContent = `To: ${repositoryValue}`;
            let span2 = document.createElement("span");
            span2.textContent = `Title: ${titleValue}`;
            let div = document.createElement("div");
            div.classList = "btn";
            let deleteBtn = document.createElement("button");
            deleteBtn.type = "submit";
            deleteBtn.classList.add("delete")
            deleteBtn.textContent = "Delete";
            deleteBtn.addEventListener("click",(e)=> deleteMails(e));
            li2Container.appendChild(span1);
            li2Container.appendChild(span2);
            div.appendChild(deleteBtn);
            li2Container.appendChild(div);
            sendMailEl.appendChild(li2Container);
            liContainer.remove();
        }
        function deleteMails(e) {
            e.target.parentNode.parentNode.remove();
            let delMailEl = document.querySelector(".delete-list");
            let li3Container = document.createElement("li");
            let span1 = document.createElement("span");
            span1.textContent = `To: ${repositoryValue}`;
            let span2 = document.createElement("span");
            span2.textContent = `Title: ${titleValue}`;
            li3Container.appendChild(span1);
            li3Container.appendChild(span2);
            delMailEl.appendChild(li3Container);
        }
    }
}
solve()