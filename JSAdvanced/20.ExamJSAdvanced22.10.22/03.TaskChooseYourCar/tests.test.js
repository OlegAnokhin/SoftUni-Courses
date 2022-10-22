let chooseYourCar = require(`./chooseYourCar`);
let {expect, assert} = require('chai');

describe("Tests chooseYourCar", function() {

    describe("Tests choosingType", function() {
        it("test1 invalid year", function() {
            expect(() => chooseYourCar.choosingType("Sedan", "red", 1899))
            .to.throw("Invalid Year!")
        });
        it("test2 invalid year", function() {
            expect(() => chooseYourCar.choosingType("Sedan", "red", 2023))
            .to.throw("Invalid Year!")
        });
        it("test invalid type", function() {            
            expect(() => chooseYourCar.choosingType("bus", "red", 2000))
            .to.throw("This type of car is not what you are looking for.")
        });
        it("test valid type after 2010", function() {            
            expect(chooseYourCar.choosingType("Sedan", "red", 2010))
            .to.equal(`This red Sedan meets the requirements, that you have.`)
        });
        it("test valid type before 2010", function() {            
            expect(chooseYourCar.choosingType("Sedan", "red", 2009))
            .to.equal(`This Sedan is too old for you, especially with that red color.`)
        });
     });
     describe("Tests brandName", function() {
        it("test with first invalid type", function () {
            expect(() => chooseYourCar.brandName("test", 1)
                .to.throw("Invalid Information!")
            );
        });
        it("test with second invalid type", function () {
            expect(() => chooseYourCar.brandName(["Volkswagen", "BMW", "Audi"], "test")
                .to.throw("Invalid Information!")
            );
        });
        it("test with negativ index", function () {
            expect(() => chooseYourCar.brandName(["Volkswagen", "BMW", "Audi"], -1)
                .to.throw("Invalid Information!")
            );
        });
        it("test with invalid index", function () {
            expect(() => chooseYourCar.brandName(["Volkswagen", "BMW", "Audi"], 8)
                .to.throw("Invalid Information!")
            );
        });
        it("test correct input", () => {
            expect(chooseYourCar.brandName(["Volkswagen", "BMW", "Audi"], 1)
            ).to.equal("Volkswagen, Audi");
        });
        it("test correct zero input", () => {
            expect(chooseYourCar.brandName(["Volkswagen"], 0)
            ).to.equal("");
        });
     });
     describe("Tests CarFuelConsumption", function() {
        it("test with first invalid type", function () {
            expect(() => chooseYourCar.carFuelConsumption("10", 10)
                .to.throw("Invalid Information!")
            );
        });
        it("test with first negative", function () {
            expect(() => chooseYourCar.carFuelConsumption(-10, 10)
                .to.throw("Invalid Information!")
            );
        });
        it("test with first zero", function () {
            expect(() => chooseYourCar.carFuelConsumption(0, 10)
                .to.throw("Invalid Information!")
            );
        });
        it("test with second invalid type", function () {
            expect(() => chooseYourCar.carFuelConsumption(10, "10")
                .to.throw("Invalid Information!")
            );
        });
        it("test with second negative", function () {
            expect(() => chooseYourCar.carFuelConsumption(10, -10)
                .to.throw("Invalid Information!")
            );
        });
        it("test with second zero", function () {
            expect(() => chooseYourCar.carFuelConsumption(10, 0)
                .to.throw("Invalid Information!")
            );
        });
        it("test correct input low", () => {
            expect(chooseYourCar.carFuelConsumption(100, 7)
            ).to.equal(`The car is efficient enough, it burns 7.00 liters/100 km.`);
        });
        it("test correct input more low", () => {
            expect(chooseYourCar.carFuelConsumption(10, 0.6)
            ).to.equal(`The car is efficient enough, it burns 6.00 liters/100 km.`);
        });
        it("test correct input", () => {
            expect(chooseYourCar.carFuelConsumption(100, 8)
            ).to.equal(`The car burns too much fuel - 8.00 liters!`);
        });
     });
});
