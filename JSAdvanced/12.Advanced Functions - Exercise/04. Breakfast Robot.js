function solution() {
    let store = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }
    let receptEnum = {
        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    }
    return function inputHandler(input) {
        let action = cmdOption();
        let [cmd, microEl, quantity] = input.split(" ")
        return action[cmd](microEl, quantity);
    }
    function cmdOption() {
        return {
            restock: (microEl, quantity) => {
                store[microEl] = store[microEl] + Number(quantity);
                return "Success"
            },
            prepare: (recept, quantity) => {
                let isDone = true;
                let str = "";
                let copyStore = JSON.parse(JSON.stringify(store));
                for (let [k, defQua] of Object.entries(receptEnum[recept])) {
                    let needValue = Number(quantity) * defQua;
                    if (store[k] < needValue) {
                        isDone = false;
                        str = `Error: not enough ${k} in stock`
                        break;
                    }
                    copyStore[k] -= needValue;
                }
                if(!isDone){
                    return str;
                }
                store = copyStore;
                return "Success";
            },
            report: () => {
                return `protein=${store.protein} carbohydrate=${store.carbohydrate} fat=${store.fat} flavour=${store.flavour}`
            }
        }
    }
}
let manager = solution();
console.log(manager("restock flavour 50")); // Success
console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock
console.log(manager("report"));
// restock carbohydrate 10
// restock flavour 10
// prepare apple 1
// restock fat 10
// prepare burger 1
// report