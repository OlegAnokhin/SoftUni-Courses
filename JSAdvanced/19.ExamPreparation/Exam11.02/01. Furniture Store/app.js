window.addEventListener('load', solve);

function solve() {
    document.querySelector("button").addEventListener('click', createTask);
    let model = document.getElementById('model');
    let year = document.getElementById('year');
    let description = document.getElementById('description');
    let price = document.getElementById('price');

    function createTask(e) {
        e.preventDefault();
        let modelValue = model.value;
        let yearValue = year.value;
        let descriptValue = description.value;
        let priceValue = Number(price.value).toFixed(2);
        if (!modelValue || !yearValue || !descriptValue || !priceValue) {
            return;
        }
        if(Number(yearValue) < 0 || Number(priceValue) < 0){
            return;
        }
        model.value = '';
        year.value = '';
        description.value = '';
        price.value = '';
        createOrder(modelValue, yearValue, descriptValue, priceValue);
    };
    function createOrder(modelValue, yearValue, descriptValue, priceValue) {
        let furnitureList = document.getElementById('furniture-list');
        let totalSection = document.querySelector('.total-price');

        let trContainer = document.createElement('tr');
        trContainer.classList.add('info');
        let td1 = document.createElement('td');
        td1.textContent = `${modelValue}`;
        let td2 = document.createElement('td');
        td2.textContent = `${priceValue}`;
        let td3 = document.createElement('td');
        let moreBtn = document.createElement('button');
        moreBtn.classList.add('moreBtn');
        moreBtn.textContent = 'More Info';
        moreBtn.addEventListener('click', moreInfo);
        let buyBtn = document.createElement('button');
        buyBtn.classList.add('buyBtn');
        buyBtn.addEventListener('click', buyIt)
        buyBtn.textContent = 'Buy it';
        let tr2Container = document.createElement('tr');
        tr2Container.classList.add('hide');
        let td4 = document.createElement('td');
        td4.textContent = `Year: ${yearValue}`;
        let td5 = document.createElement('td');
        td5.textContent = `Description: ${descriptValue}`;

        trContainer.appendChild(td1);
        trContainer.appendChild(td2);
        trContainer.appendChild(td3);
        td3.appendChild(moreBtn);
        td3.appendChild(buyBtn);
        tr2Container.appendChild(td4);
        tr2Container.appendChild(td5).colSpan = 3;

        furnitureList.appendChild(trContainer);
        furnitureList.appendChild(tr2Container);

        function moreInfo() {
            if(moreBtn.textContent == 'More Info'){
                moreBtn.textContent = 'Less Info';
                tr2Container.style.display = 'contents';
            }else{
                moreBtn.textContent = 'More Info';
                tr2Container.style.display = 'none';
            }
        };
        function buyIt() {
            trContainer.remove();
            tr2Container.remove();
            let currTotal = Number(totalSection.textContent);
            totalSection.textContent = (currTotal + Number(priceValue)).toFixed(2);
        };
    };
};