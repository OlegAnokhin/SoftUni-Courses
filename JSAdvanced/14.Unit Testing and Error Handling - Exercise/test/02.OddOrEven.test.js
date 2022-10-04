let { assert } = require("chai");
const { isOddOrEven } = require("../02.EvenOrOdd");
describe("MyTests", () => {
    describe("Test isOddOrEven type", () => {
        it("Result Should be undefine with arr", () => {
            assert.equal(isOddOrEven([]), undefined)
        });
        it("Result Should be undefine with empty obj", () => {
            assert.equal(isOddOrEven({}), undefined)
        });
        it("Result Should be undefine with obj", () => {
            assert.equal(isOddOrEven({ name: "Pesho" }), undefined)
        });
        it("Result Should be undefine with number", () => {
            assert.equal(isOddOrEven(666), undefined)
        });
        it("Result Should be undefine with boolean", () => {
            assert.equal(isOddOrEven(true), undefined)
        });
    });
    describe("Test isOddOrEven with correct value", ()=>{
        it("Result Should be correct with even", () => {
            assert.equal(isOddOrEven("Oleg"), "even")
        });
        it("Result Should be correct with odd", () => {
            assert.equal(isOddOrEven("Petya"), "odd")
        });
    });
});