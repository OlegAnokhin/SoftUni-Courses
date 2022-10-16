let {mathEnforcer} = require("../04.MathEnforcer");
let { assert, expect } = require("chai");

describe(" Test Math Enforcer", () => {
    describe("Test addFive", () => {
        it("Test with corect positive value", () => {
            assert.equal(mathEnforcer.addFive(5), 10)
        });
        it("Test with corect negative value", () => {
            assert.equal(mathEnforcer.addFive(-5), 0)
        });
        it("Test with corect float value", () => {
            expect(mathEnforcer.addFive(5.55)).to.be.closeTo(10.55, 0.01)
        });
        it("Test with string value", () => {
            assert.equal(mathEnforcer.addFive("5"), undefined)
        });
        it("Test with array value", () => {
            assert.equal(mathEnforcer.addFive([1,2,3]), undefined)
        });
        it("Test with object value", () => {
            assert.equal(mathEnforcer.addFive({}), undefined)
        });
        it("Test with empty value", () => {
            assert.equal(mathEnforcer.addFive(), undefined)
        });
    });
    describe("Test subtractTen", ()=>{
        it("Test with corect positive value", () => {
            assert.equal(mathEnforcer.subtractTen(50), 40)
        });
        it("Test with corect negative value", () => {
            assert.equal(mathEnforcer.subtractTen(-5), -15)
        });
        it("Test with corect float value", () => {
            expect(mathEnforcer.subtractTen(20.55)).to.be.closeTo(10.55, 0.01)
        });
        it("Test with string value", () => {
            assert.equal(mathEnforcer.subtractTen("5"), undefined)
        });
        it("Test with array value", () => {
            assert.equal(mathEnforcer.subtractTen([1,2,3]), undefined)
        });
        it("Test with object value", () => {
            assert.equal(mathEnforcer.subtractTen({}), undefined)
        });
        it("Test with empty value", () => {
            assert.equal(mathEnforcer.subtractTen(), undefined)
        });
    });
    describe("Test sum", ()=>{
        it("Test with corect positive value", () => {
            assert.equal(mathEnforcer.sum(20, 20), 40)
        });
        it("Test with corect negative value", () => {
            assert.equal(mathEnforcer.sum(-5 , -10), -15)
        });
        it("Test with corect float value", () => {
            expect(mathEnforcer.sum(20.55 , 30.44)).to.be.closeTo(50.99, 0.01)
            
        });
        it("Test with string first value", () => {
            assert.equal(mathEnforcer.sum("5", 5), undefined)
        });
        it("Test with string second value", () => {
            assert.equal(mathEnforcer.sum(5, "5"), undefined)
        });
    });
});