function solve() {
    document.getElementById('add-worker').addEventListener('click', createTask);
    let firstName = document.getElementById("fname");
    let lastName = document.getElementById("lname");
    let email = document.getElementById("email");
    let birth = document.getElementById("birth");
    let position = document.getElementById("position");
    let salary = document.getElementById("salary");
  
    function createTask(e) {
      e.preventDefault();
      let firstNameValue = firstName.value;
      let lastNameValue = lastName.value;
      let emailValue = email.value;
      let birthValue = birth.value;
      let positionValue = position.value;
      let salaryValue = salary.value;
      if (!firstNameValue || !lastNameValue || !emailValue
        || !birthValue || !positionValue || !salaryValue) {
        return;
      }
      firstName.value = "";
      lastName.value = "";
      email.value = "";
      birth.value = "";
      position.value = "";
      salary.value = "";
      createOrder(firstNameValue, lastNameValue, emailValue, birthValue, positionValue, salaryValue);
    }
    function createOrder(firstNameValue, lastNameValue, emailValue, birthValue, positionValue, salaryValue) {
        let tableEl = document.getElementById("tbody");
        let totalSection = document.getElementById('sum');
        let totalSalary = Number(salaryValue) + Number(totalSection.textContent);
        totalSection.textContent = totalSalary.toFixed(2);
        let trContainer = document.createElement('tr');
        trContainer.classList.add('info');
        let td1 = document.createElement('td');
        td1.textContent = `${firstNameValue}`;
        let td2 = document.createElement('td');
        td2.textContent = `${lastNameValue}`;
        let td3 = document.createElement('td');
        td3.textContent = `${emailValue}`;
        let td4 = document.createElement('td');
        td4.textContent = `${birthValue}`;
        let td5 = document.createElement('td');
        td5.textContent = `${positionValue}`;
        let td6 = document.createElement('td');
        td6.textContent = `${salaryValue}`;
        let td7 = document.createElement('td');
        let firedBtn = document.createElement('button');
        firedBtn.classList.add('fired');
        firedBtn.textContent = 'Fired';
        firedBtn.addEventListener('click', Fired);
        let edinBtn = document.createElement('button');
        edinBtn.classList.add('edit');
        edinBtn.textContent = 'Edit';
        edinBtn.addEventListener('click', Edit);
        trContainer.appendChild(td1);
        trContainer.appendChild(td2);
        trContainer.appendChild(td3);
        trContainer.appendChild(td4);
        trContainer.appendChild(td5);
        trContainer.appendChild(td6);
        trContainer.appendChild(td7);
        td7.appendChild(firedBtn);
        td7.appendChild(edinBtn);
        tableEl.appendChild(trContainer);
        function Fired(){
            trContainer.remove();
            let ammount = Number(totalSection.textContent)
            ammount -= Number(salaryValue);
            totalSection.textContent = ammount.toFixed(2);
        }
        function Edit(){
            trContainer.remove();
            firstName.value = firstNameValue;
            lastName.value = lastNameValue;
            email.value = emailValue;
            birth.value = birthValue;
            position.value = positionValue;
            salary.value = salaryValue;
            let ammount = Number(totalSection.textContent)
            ammount -= Number(salaryValue);
            totalSection.textContent = ammount.toFixed(2);
        }
    }
}
solve()