function lowestPrices(input) {
    let result = {};
    for (let el of input) {
        let [town, product, price] = el.split(" | ");
        price = Number(price);

        if (result.hasOwnProperty(product)) {
            let currPrice = result[product]["price"];
            if (currPrice > price) {
                result[product] = { town, price }
            }
        } else {
            result[product] = { town, price };
        }
    }
    for (let [product, value] of Object.entries(result)) {
        console.log(`${product} -> ${value.price} (${value.town})`)
    }
}
lowestPrices([
    'Sample Town | Sample Product | 1000',
    'Sample Town | Orange | 2',
    'Sample Town | Peach | 1',
    'Sofia | Orange | 3',
    'Sofia | Peach | 2',
    'New York | Sample Product | 1000.1',
    'New York | Burger | 10'
]);