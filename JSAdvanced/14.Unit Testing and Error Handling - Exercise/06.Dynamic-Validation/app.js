function validate() {
    let input = document.getElementById("email");
    input.addEventListener("change", onChange);

    function onChange(e){
        let email = e.target.value;
        let regex = /[A-Za-z0_9]+@[A-Za-z0_9]+\.[A-Za-z]+/g;
        if(regex.test(email)){
            e.target.classList.remove("error")
        }else{
            e.target.classList.add("error")
        }        
    }
}