function toggle() {
    let buttonEl = document.getElementsByClassName("button")[0];
    let hideDiv = document.getElementById("extra");
    if (buttonEl.textContent == "More"){
        buttonEl.textContent = "Less";
        hideDiv.style.display = "block";
    }else {
        buttonEl.textContent = "More";
        hideDiv.style.display = "none";
    }
}