function storeCatalog(input) {
    let store = {};
    for(let row of input.sort((a,b) => a.localeCompare(b))){
        let [prName, prPrice] = row.split(' : ');
        prPrice = Number(prPrice);
        let firstLetter = prName[0];
        let currProduct = {prName, prPrice};
        if(!store[firstLetter]){
            store[firstLetter] = [];
        }
        store[firstLetter].push(currProduct);
    }
    for (let letter of Object.keys(store)){
        console.log(letter);
        for(let product of store[letter]){
            console.log(`  ${product.prName}: ${product.prPrice}`);
        }
    }
}

storeCatalog([
    'Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']);