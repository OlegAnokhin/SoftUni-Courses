window.addEventListener("load", solve);

function solve() {
  document.getElementById('form-btn').addEventListener('click', createTask);
  let firstName = document.getElementById("first-name");
  let lastName = document.getElementById("last-name");
  let age = document.getElementById("age");
  let genre = document.getElementById("genre");
  let storyTitle = document.getElementById("story-title");
  let storyText = document.getElementById("story");
  let submitBtn = document.getElementById('form-btn');

  function createTask(e) {
    e.preventDefault();
    let firstNameValue = firstName.value;
    let lastNameValue = lastName.value;
    let ageValue = age.value;
    let genreValue = genre.value;
    let storyTitleValue = storyTitle.value;
    let storyTextValue = storyText.value;

    if (!firstNameValue || !lastNameValue || !ageValue || !genreValue
      || !storyTitleValue || !storyTextValue) {
      return;
    }
    submitBtn.disabled = true
    firstName.value = "";
    lastName.value = "";
    age.value = "";
    genre.value = "";
    storyTitle.value = "";
    storyText.value = "";

    createOrder(firstNameValue, lastNameValue, ageValue,
      genreValue, storyTitleValue, storyTextValue);
  }
  function createOrder(firstNameValue, lastNameValue, ageValue,
    genreValue, storyTitleValue, storyTextValue) {

    let infoPrevSection = document.getElementById("preview-list");
    let liContainer = document.createElement('li');
    liContainer.classList.add('story-info');
    let article = document.createElement('article');
    let h1 = document.createElement('h4');
    h1.textContent = `Name: ${firstNameValue} ${lastNameValue}`;
    let p1 = document.createElement('p');
    p1.textContent = `Age: ${ageValue}`;
    let p2 = document.createElement('p');
    p2.textContent = `Title: ${storyTitleValue}`;
    let p3 = document.createElement('p');
    p3.textContent = `Genre: ${genreValue}`;
    let p4 = document.createElement('p');
    p4.textContent = `${storyTextValue}`;
    let saveBtn = document.createElement('button');
    saveBtn.classList.add('save-btn');
    saveBtn.textContent = 'Save Story';
    let editBtn = document.createElement('button');
    editBtn.classList.add('edit-btn');
    editBtn.textContent = 'Edit Story';
    let deleteBtn = document.createElement('button');
    deleteBtn.classList.add('delete-btn');
    deleteBtn.textContent = 'Delete Story';

    liContainer.appendChild(article);
    article.appendChild(h1);
    article.appendChild(p1);
    article.appendChild(p2);
    article.appendChild(p3);
    article.appendChild(p4);
    liContainer.appendChild(saveBtn);
    liContainer.appendChild(editBtn);
    liContainer.appendChild(deleteBtn);
    infoPrevSection.appendChild(liContainer);

    saveBtn.addEventListener('click', saveFunc)
    editBtn.addEventListener('click', editFunc);
    deleteBtn.addEventListener('click', deleteFunc);
    saveBtn.disabled = false;
    editBtn.disabled = false;
    deleteBtn.disabled = false;
    function saveFunc() {
      let result = document.getElementById('main');
      let arr = Array.from(result.children);
      arr.forEach(el => el.remove());
      let H = document.createElement('h1');
      H.textContent = `Your scary story is saved!`;
      result.appendChild(H);
    }
    function editFunc() {
      submitBtn.disabled = false;
      saveBtn.disabled = true;
      editBtn.disabled = true;
      deleteBtn.disabled = true;
      firstName.value = firstNameValue;
      lastName.value = lastNameValue;
      age.value = ageValue;
      genre.value = genreValue;
      storyTitle.value = storyTitleValue;
      storyText.value = storyTextValue;
      liContainer.remove();
    }
    function deleteFunc() {
      liContainer.remove();
      submitBtn.disabled = false;
    }
  }
}
