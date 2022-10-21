class CarDealership {
    constructor(name) {
        this.name = name;
        this.availableCars = [];
        this.soldCars = []
        this.totalIncome = 0;
    }
    addCar(model, horsepower, price, mileage) {
        let horsePower = Number.isInteger(horsepower);
        if (!model || horsepower < 0 || price < 0 || mileage < 0 || !horsePower) {
            throw new Error("Invalid input!");
        }
        this.availableCars.push({ model, horsepower, price, mileage });
        return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`
    }
    sellCar(model, desiredMileage) {
        let currCar = this.availableCars.find(c => c.model == model);
        if (!currCar) {
            throw new Error(`${model} was not found!`);
        }
        let currModel = currCar.model;
        let currHP = currCar.horsepower;
        let soldPrice = currCar.price;
        if (currCar.mileage - desiredMileage <= 40000) {
            soldPrice = soldPrice * 0.95;
        }
        if (currCar.mileage - desiredMileage > 40000) {
            soldPrice = soldPrice * 0.9;
        }
        if (currCar.mileage <= desiredMileage) {
            soldPrice = currCar.price;
        }
        this.availableCars = this.availableCars.filter(c => c.model !== model);
        this.soldCars.push({
            model: currModel,
            horsepower: currHP,
            soldPrice
        })
        this.totalIncome += soldPrice;
        return `${model} was sold for ${soldPrice.toFixed(2)}$`;
    }
    currentCar() {
        if (this.availableCars.length == 0) {
            return "There are no available cars";
        }
        let result = ["-Available cars:"];
        this.availableCars.map((p) => result.push(`---${p.model} - ${p.horsepower} HP - ${p.mileage.toFixed(2)} km - ${p.price.toFixed(2)}$`));
        return result.join("\n");
    }
    salesReport(criteria) {
        if (criteria !== "horsepower" && criteria !== "model") {
            throw new Error("Invalid criteria!")
        }
        let result = [`-${this.name} has a total income of ${this.totalIncome.toFixed(2)}$`];
        result.push(`-${this.soldCars.length} cars sold:`)
        if (criteria === "horsepower") {
            this.soldCars.sort((a, b) => b.horsepower - a.horsepower);
            this.soldCars.map((p) => result.push(`---${p.model} - ${p.horsepower} HP - ${p.soldPrice.toFixed(2)}$`));
            return result.join("\n");
        }
        if (criteria === "model") {
            this.soldCars.sort((a, b) => a.model.localeCompare(b.model));
            this.soldCars.map((p) => result.push(`---${p.model} - ${p.horsepower} HP - ${p.soldPrice.toFixed(2)}$`));
            return result.join("\n");
        }        
    }
}

let dealership = new CarDealership('SoftAuto');
dealership.addCar('Toyota Corolla', 100, 3500, 190000);
dealership.addCar('Mercedes C63', 300, 29000, 187000);
dealership.addCar('Audi A3', 120, 4900, 240000);
dealership.sellCar('Toyota Corolla', 230000);
dealership.sellCar('Mercedes C63', 110000);
console.log(dealership.salesReport('horsepower'));

// Output 4
// -SoftAuto has a total income of 29600.00$
// -2 cars sold:
// ---Mercedes C63 - 300 HP - 26100.00$
// ---Toyota Corolla - 100 HP - 3500.00$
