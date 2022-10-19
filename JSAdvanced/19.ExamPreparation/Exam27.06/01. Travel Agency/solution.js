window.addEventListener('load', solution);

function solution() {
  document.getElementById('submitBTN').addEventListener('click', createTask);
  let fullName = document.getElementById("fname");
  let email = document.getElementById("email");
  let phone = document.getElementById("phone");
  let address = document.getElementById("address");
  let postCode = document.getElementById("code");
  let submitBtn = document.getElementById('submitBTN');
  let editBtn = document.getElementById('editBTN');
  let continueBtn = document.getElementById('continueBTN');

  function createTask(e) {
    e.preventDefault();
    let fullNameValue = fullName.value;
    let emailValue = email.value;
    let phoneValue = phone.value;
    let addressValue = address.value;
    let postCodeValue = postCode.value;
    if (!fullNameValue || !emailValue) {
      return;
    }
    submitBtn.disabled = true
    fullName.value = "";
    email.value = "";
    phone.value = "";
    address.value = "";
    postCode.value = "";
    createOrder(fullNameValue, emailValue, phoneValue, addressValue, postCodeValue);
  }
  function createOrder(fullNameValue, emailValue, phoneValue, addressValue, postCodeValue) {
    let infoPrevSection = document.getElementById("infoPreview");
    let li1 = document.createElement('li');
    li1.textContent = `Full Name: ${fullNameValue}`;
    let li2 = document.createElement('li');
    li2.textContent = `Email: ${emailValue}`;
    let li3 = document.createElement('li');
    li3.textContent = `Phone Number: ${phoneValue}`;
    let li4 = document.createElement('li');
    li4.textContent = `Address: ${addressValue}`;
    let li5 = document.createElement('li');
    li5.textContent = `Postal Code: ${postCodeValue}`;
    infoPrevSection.appendChild(li1);
    infoPrevSection.appendChild(li2);
    infoPrevSection.appendChild(li3);
    infoPrevSection.appendChild(li4);
    infoPrevSection.appendChild(li5);

    editBtn.disabled = false;
    continueBtn.disabled = false;
    editBtn.addEventListener('click', edit);
    continueBtn.addEventListener('click', finish);

    function edit() {
      submitBtn.disabled = false
      editBtn.disabled = true;
      continueBtn.disabled = true;
      debugger
      
      fullName.value = fullNameValue;
      email.value = emailValue;
      phone.value = phoneValue;
      address.value = addressValue;
      postCode.value = postCodeValue;

      let arr = Array.from(infoPrevSection.children);
      arr.forEach(el => el.remove());
    }
    function finish() {
      let blockSection = document.getElementById('block');
      let arr = Array.from(blockSection.children);
      arr.forEach(el => el.remove());
      let h3 = document.createElement('h3');
      h3.textContent = `Thank you for your reservation!`;
      blockSection.appendChild(h3);
    }
  }
}
