window.addEventListener("load", solve);

function solve() {
  //document.querySelector("publish").addEventListener('click', createTask);
  document.getElementById('publish').addEventListener('click', createTask);
  let make = document.getElementById("make");
  let model = document.getElementById("model");
  let year = document.getElementById("year");
  let fuel = document.getElementById("fuel");
  let originalCost = document.getElementById("original-cost");
  let sellingPrice = document.getElementById("selling-price");

  let submitBtn = document.getElementById('publish');
  // let editBtn = document.getElementById('editBTN');
  // let continueBtn = document.getElementById('continueBTN');

  function createTask(e) {
    e.preventDefault();
    let makeValue = make.value;
    let modelValue = model.value;
    let yearValue = year.value;
    let fuelValue = fuel.value;
    let originalCostValue = Number(originalCost.value);
    let sellingPriceValue = Number(sellingPrice.value);

    if (!makeValue || !modelValue || !yearValue
      || !fuelValue || !originalCostValue || !sellingPriceValue) {
      return;
    }
    if (sellingPriceValue < originalCostValue) {
      return;
    }
    make.value = "";
    model.value = "";
    year.value = "";
    fuel.value = "";
    originalCost.value = "";
    sellingPrice.value = "";
    createOrder(makeValue, modelValue, yearValue, fuelValue, originalCostValue, sellingPriceValue);
  }
  function createOrder(makeValue, modelValue, yearValue, fuelValue, originalCostValue, sellingPriceValue) {

    let carsList = document.getElementById('table-body');
    let trContainer = document.createElement('tr');
    trContainer.classList.add('row');
    let td1 = document.createElement('td');
    td1.textContent = `${makeValue}`;
    let td2 = document.createElement('td');
    td2.textContent = `${modelValue}`;
    let td3 = document.createElement('td');
    td3.textContent = `${yearValue}`;
    let td4 = document.createElement('td');
    td4.textContent = `${fuelValue}`;
    let td5 = document.createElement('td');
    td5.textContent = `${originalCostValue}`;
    let td6 = document.createElement('td');
    td6.textContent = `${sellingPriceValue}`;
    let td7 = document.createElement('td');
    let editBtn = document.createElement('button');
    editBtn.setAttribute('class', 'action-btn edit');
    editBtn.textContent = 'Edit';
    editBtn.addEventListener('click', edit);
    let sellBtn = document.createElement('button');
    sellBtn.setAttribute('class', 'action-btn sell');
    sellBtn.addEventListener('click', sellIt)
    sellBtn.textContent = 'Sell';
    trContainer.appendChild(td1);
    trContainer.appendChild(td2);
    trContainer.appendChild(td3);
    trContainer.appendChild(td4);
    trContainer.appendChild(td5);
    trContainer.appendChild(td6);
    trContainer.appendChild(td7);
    td7.appendChild(editBtn);
    td7.appendChild(sellBtn);
    carsList.appendChild(trContainer);

    function edit() {
      make.value = makeValue;
      model.value = modelValue;
      year.value = yearValue;
      fuel.value = fuelValue;
      originalCost.value = originalCostValue;
      sellingPrice.value = sellingPriceValue;
      trContainer.remove();
    };
    function sellIt() {
      debugger
      let soldCarsList = document.getElementById('cars-list');
      let profitSection = document.getElementById('profit')
      let diffrence = Number(sellingPriceValue) - Number(originalCostValue)
      trContainer.remove();
      let liContainer = document.createElement('li');
      liContainer.classList.add('each-list');
      let span1 = document.createElement('span');
      span1.textContent = `${makeValue} ${modelValue}`;
      let span2 = document.createElement('span');
      span2.textContent = `${yearValue}`;
      let span3 = document.createElement('span');
      span3.textContent = `${diffrence}`;
      liContainer.appendChild(span1);
      liContainer.appendChild(span2);
      liContainer.appendChild(span3);
      soldCarsList.appendChild(liContainer);

      let currTotal = Number(profitSection.textContent);
      profitSection.textContent = (currTotal + Number(diffrence)).toFixed(2);
    };
  }
}
