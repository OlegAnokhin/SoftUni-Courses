function validate() {
    let input = document.getElementById('email');
    let regex = /[A-Za-z]+@[A-Za-z]+.[a-z]+/g;
    let check = function(e){
        if(regex.test(e.currentTarget.value)){
            e.currentTarget.removeAttribute('class');
        }else{
            e.currentTarget.classList.add('error');
        }
    }
    input.addEventListener('change', check)
}