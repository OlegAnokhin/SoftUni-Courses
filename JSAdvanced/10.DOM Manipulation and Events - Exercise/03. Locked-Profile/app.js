function lockedProfile(){
    let buttons = document.querySelectorAll('div button');
    for(let i = 0; i < buttons.length; i++){
        let button = buttons[i];
        let currProf = button.parentElement;
        let conditionProf = currProf.querySelector('input[value="lock"]');
        let hiddenInfo = document.getElementById(`user${i+1}HiddenFields`);
        button.addEventListener('click', (event) =>{
            if(!conditionProf.checked && button.textContent == 'Show more'){
                hiddenInfo.style.display = 'block';
                button.textContent = 'Hide it';
            }else if(!conditionProf.checked && button.textContent == 'Hide it'){
                hiddenInfo.style.display = 'none';
                button.textContent = 'Show more';
            }
        });
    }
}