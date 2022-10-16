function validate(e) {
    let formElement = document.getElementById('registerForm');
    let username = document.getElementById("username");
    let email = document.getElementById("email");
    let password = document.getElementById("password");
    let confPassword = document.getElementById("confirm-password");
    let isCompany = document.getElementById("company");
    let companyInfo = document.getElementById("companyInfo");
    let validMessage = document.getElementById("valid");

    isCompany.addEventListener("change", (e)=> {
        if(isCompany.checked) {
            companyInfo.style.display = "block";
        }else {
            companyInfo.style.display = "none";
        }
    });
    formElement.addEventListener("submit", (e) => {
        e.preventDefault();
        let userPattern = /^[A-Za-z0-9]{3,20}$/;
        let passPattern = /^[\w]{5,15}$/;
        let emailPattern = /^[^@.]+@[^@]*\.[^@]*$/;
        if(userPattern.test(username.value) == true){
            username.style.borderColor = "none";        
        }else{
            username.style.borderColor = "red";
        }
        if(emailPattern.test(email.value) == true) {
            email.style.borderColor = "none";
        }else{
            email.style.borderColor = "red";
        }
        if(passPattern.test(password.value) == true
        && passPattern.test(confPassword.value)== true
        && password.value == confPassword.value) {
            password.style.borderColor = "none";
            confPassword.style.borderColor = "none";
        }else{
            password.style.borderColor = "red";
            confPassword.style.borderColor = "red";
        }
        if(isCompany.checked) {
            let companyNumber = document.getElementById("companyNumber");
            if(companyNumber.value < 1000 || companyNumber.value > 9999) {
                companyNumber.style.borderColor = "red";
            }else{
                companyNumber.style.borderColor = "none"
            }
        }
        let finalForm = Array.from(formElement.elements).slice(1).map(x => x.style.borderColor);
        if(!finalForm.some(x=>x == "red")) {
            validMessage.style.display = "block";
        }else{
            validMessage.style.display = "none"
        }
        console.log(finalForm);
    });
}
