let companyAdministration = require('./companyAdministration');
let { assert } = require("chai");

describe("Test companyAdministration", function()  {
    describe("Test hiringEmployee", function() {
        it("test diffr position", function () {
            let exp = `We are not looking for workers for this position.`;
            assert.throw(()=>companyAdministration.hiringEmployee("Todor", "DifferentPosition", 30), exp);
        });
        it("test experiance with greather 3 years", ()=> {
            let exp = `Oleg was successfully hired for the position Programmer.`
            assert.equal(companyAdministration.hiringEmployee("Oleg", "Programmer", 3), exp);
            assert.equal(companyAdministration.hiringEmployee("Oleg", "Programmer", 20), exp);
        })
        it("Test invalid value", function() {
            let exp = `Oleg is not approved for this position.`
            assert.equal(companyAdministration.hiringEmployee("Oleg", "Programmer", 0), exp);
            assert.equal(companyAdministration.hiringEmployee("Oleg", "Programmer", 1), exp);
        })
    });
    describe("Test calculateSalary ", function() {
        it("test calculate with wrong value", function () {
            assert.throw(()=>companyAdministration.calculateSalary(-10), "Invalid hours");
            assert.throw(()=>companyAdministration.calculateSalary("-10"), "Invalid hours");
        });
        it("test with valid value", function(){
            assert.equal(companyAdministration.calculateSalary(0), 0);
            assert.equal(companyAdministration.calculateSalary(1), 15);
            assert.equal(companyAdministration.calculateSalary(160), 160 * 15)
        })
        it("test with valid value + bonus", function(){
            assert.equal(companyAdministration.calculateSalary(170), 170 * 15 + 1000);
        })
    })
    describe("Test firedEmployee  ", function() {
        it("test firedEmployee with wrong data", function () {
            assert.throw(()=>companyAdministration.firedEmployee("Oleg", 0), "Invalid input");
            assert.throw(()=>companyAdministration.firedEmployee([], 0), "Invalid input");
            assert.throw(()=>companyAdministration.firedEmployee({}, 0), "Invalid input");
            assert.throw(()=>companyAdministration.firedEmployee(["Oleg"], 2), "Invalid input");
            assert.throw(()=>companyAdministration.firedEmployee(["Oleg"], -1), "Invalid input");
            assert.throw(()=>companyAdministration.firedEmployee(["Oleg"], "Pesho"), "Invalid input");
            assert.throw(()=>companyAdministration.firedEmployee(1, "sdfd"), "Invalid input");
        });
        it("test firedEmployee with corect data", function(){
            assert.equal(companyAdministration.firedEmployee(["Oleg"], 0), "");
            assert.equal(companyAdministration.firedEmployee(["Oleg", "Gosho"], 0), "Gosho");
            assert.equal(companyAdministration.firedEmployee(["Oleg", "Gosho"], 1), "Oleg")
        })
    })
})
