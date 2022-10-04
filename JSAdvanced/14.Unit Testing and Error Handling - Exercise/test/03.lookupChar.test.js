let { assert } = require("chai");
let { lookupChar } = require("../03.CharLookup");

describe("Test lookupChar with Incorrect value", ()=>{
    it("Result Should be undefine with first param is incorrect", () => {
        assert.equal(lookupChar(5, 5), undefined)
    });
    it("Result Should be undefine with second param is incorrect", () => {
        assert.equal(lookupChar("5", "5"), undefined)
    });
    it("Result Should be undefine with second param is decimal", () => {
        assert.equal(lookupChar("5", 6.66), undefined)
    });
});
describe("Test lookupChar with correct value but incorect index", ()=>{
    it("Result Should be invalid index whit bigger index", () => {
        assert.equal(lookupChar("Oleg", 10), "Incorrect index")
    });
    it("Result Should be invalid index whit equal index", () => {
        assert.equal(lookupChar("Oleg", 4), "Incorrect index")
    });
    it("Result Should be invalid index whit smaller index", () => {
        assert.equal(lookupChar("Oleg", -6), "Incorrect index")
    });
});
describe("Test lookupChar with correct value", ()=>{
    it("Result Should be correct with first letter", () => {
        assert.equal(lookupChar("Oleg", 0), "O")
    });
    it("Result Should be correct with last letter", () => {
        assert.equal(lookupChar("Oleg", 3), "g")
    });
});