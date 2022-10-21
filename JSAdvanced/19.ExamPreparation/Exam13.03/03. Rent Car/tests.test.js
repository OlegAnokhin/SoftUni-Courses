let rentCar = require(`./rentCar`);
let {expect, assert} = require('chai');

describe("Tests Rent Car", function() {
    describe("test searchCar", function() {
        it("test invalid first value", function() {            
            expect(() => rentCar.searchCar(5, "test"))
            .to.throw("Invalid input!")
        });
        it("test invalid second value", function() {            
            expect(() => rentCar.searchCar(["Volkswagen", "BMW", "Audi"], 5))
            .to.throw("Invalid input!")
        });
        it("test not find", function() {            
            expect(() => rentCar.searchCar(["Volkswagen", "BMW", "Audi"], "null"))
            .to.throw("There are no such models in the catalog!");
        });
        it("test correct input", function() {
            expect(rentCar.searchCar(
                ["Volkswagen", "BMW", "Audi"],
                "BMW"
            )).to.equal("There is 1 car of model BMW in the catalog!");
        });
     });
     describe("test calculatePriceOfCar", function() {
        it("test invalid first value", function() {            
            expect(() => rentCar.calculatePriceOfCar(5, 5))
            .to.throw("Invalid input!")
        });
        it("test invalid second value", function() {            
            expect(() => rentCar.calculatePriceOfCar("BMW", "5"))
            .to.throw("Invalid input!")
        });
        it("test not find", function() { 
            expect(() => rentCar.calculatePriceOfCar("null", 5))
            .to.throw("No such model in the catalog!");
        });
        it("test with correct input", function() {
            expect(rentCar.calculatePriceOfCar("BMW", 10))
            .to.equal(`You choose BMW and it will cost $450!`);
        })
     });
     describe("test checkBudget", function() {
        it("test invalid first value", function() {            
            expect(() => rentCar.checkBudget("5", 5, 5))
            .to.throw("Invalid input!")
        });
        it("test invalid second value", function() {            
            expect(() => rentCar.checkBudget(5, "5", 5))
            .to.throw("Invalid input!")
        });
        it("test invalid third value", function() {            
            expect(() => rentCar.checkBudget(5, 5, "5"))
            .to.throw("Invalid input!")
        });
        it("test with correct input", function() {
            expect(rentCar.checkBudget(1, 1, 100))
            .to.equal(`You rent a car!`);
        })
        it("test with correct input and equal budget", function() {
            expect(rentCar.checkBudget(10, 10, 100))
            .to.equal(`You rent a car!`);
        })
        it("test with correct input and low budget", function() {
            expect(rentCar.checkBudget(10, 10, 90))
            .to.equal("You need a bigger budget!");
        })
     });
});
