let sum = require(`../04. Sum of Numbers`);
let { assert } = require("chai");

describe("Test Sum of Numbers", function () {
    it("test with correct values", () => {
        assert.equal(sum([1, 2, 3, 4]), 10);
    })
    it("Test empty array", function () {
        assert.equal(sum([]), 0);
    })
})