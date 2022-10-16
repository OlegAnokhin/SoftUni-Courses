let {createCalculator} = require(`../07. Add or Subtract`);
let { assert, expect } = require("chai");

describe("Test Add / Subtract", function () {
    it("should return obj", () => {
        assert.isObject(createCalculator());
    })
    it("should return obj with prop add", () => {
        expect(createCalculator()).to.have.property("add");
    })
    it("should return obj with prop subtract", () => {
        expect(createCalculator()).to.have.property("subtract");
    })
    it("should return obj with prop get", () => {
        expect(createCalculator()).to.have.property("get");
    })
})
describe("Test Add", ()=> {
    it("test with correct values", () => {
        let func = createCalculator();
        func["add"](100);
        func["add"]("100");
        expect(func["get"]()).to.be.equal(200)
    })
})
describe("Test subtract", ()=> {
    it("test with correct values", () => {
        let func = createCalculator();
        func["add"](100);
        func["add"]("100");
        func["subtract"](25);
        func["subtract"]("25");
        expect(func["get"]()).to.be.equal(150)
    })
})