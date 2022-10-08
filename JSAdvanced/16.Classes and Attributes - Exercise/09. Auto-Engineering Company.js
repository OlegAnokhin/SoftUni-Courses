function autoCompany(array) {
    let carList = {};
    array.forEach(line => {
        let [brand, model, qty] = line.split(' | ');
        if (!carList.hasOwnProperty(brand)) {
            carList[brand] = {};
        }
        if (!carList[brand].hasOwnProperty(model)) {
            carList[brand][model] = 0;
        }
        carList[brand][model] += Number(qty);
    });
    for(let brand in carList){
        console.log(brand)
        Object.entries(carList[brand])
        .forEach(el => console.log('###' + el[0] +' -> ' + el[1]))
    }
}

autoCompany(
    ['Audi | Q7 | 1000',
        'Audi | Q6 | 100',
        'BMW | X5 | 1000',
        'BMW | X6 | 100',
        'Citroen | C4 | 123',
        'Volga | GAZ-24 | 1000000',
        'Lada | Niva | 1000000',
        'Lada | Jigula | 1000000',
        'Citroen | C4 | 22',
        'Citroen | C5 | 10'
    ]
)