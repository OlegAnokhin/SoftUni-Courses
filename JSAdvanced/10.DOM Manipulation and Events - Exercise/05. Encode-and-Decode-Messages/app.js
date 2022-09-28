function encodeAndDecodeMessages() {
    let buttons = document.querySelectorAll("button");
    buttons[0].addEventListener("click", encode);
    buttons[1].addEventListener("click", decode);

    function encode(event){
        let newMessage = "";
        let text = event.target.parentElement.children[1].value;
        for(let i = 0; i < text.length; i++){
            let currCh = text[i].charCodeAt();
            newMessage += String.fromCharCode(currCh + 1);
        }
        let textAreas = document.querySelectorAll("textarea");
        let resultTextArea = textAreas[1];
        resultTextArea.value = newMessage;
        let currTextArea = textAreas[0];
        currTextArea.value = "";
    }
    function decode(event){
        let currArea = event.target.parentElement.children[1];
        let text = currArea.value;
        let resultMessage = "";
        for(let i = 0; i < text.length; i++){
            let currCh = text[i].charCodeAt();
            resultMessage += String.fromCharCode(currCh - 1);
        }
        currArea.value = resultMessage;
    }
}