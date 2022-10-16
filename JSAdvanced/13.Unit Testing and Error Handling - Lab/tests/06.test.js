let rgbToHexColor = require(`../06. RGB to Hex`);
let { assert } = require("chai");

describe("Test RGB to Hex", function () {
    it("test with incorrect red", () => {
        assert.equal(rgbToHexColor('255',255,255), undefined);
    })
    it("test with incorrect green", () => {
        assert.equal(rgbToHexColor(255,'255',255), undefined);
    })
    it("test with incorrect blue", () => {
        assert.equal(rgbToHexColor(255,255,'255'), undefined);
    })
    it("test with incorrect red negative value", () => {
        assert.equal(rgbToHexColor(-10,255,255), undefined);
    })
    it("test with incorrect green negative value", () => {
        assert.equal(rgbToHexColor(255,-10,255), undefined);
    })
    it("test with incorrect blue negative value", () => {
        assert.equal(rgbToHexColor(255,255,-10), undefined);
    })
    it("test with incorrect red value", () => {
        assert.equal(rgbToHexColor(510,255,255), undefined);
    })
    it("test with incorrect green value", () => {
        assert.equal(rgbToHexColor(255,510,255), undefined);
    })
    it("test with incorrect blue value", () => {
        assert.equal(rgbToHexColor(255,255,510), undefined);
    })
    it("test with floats value", () => {
        assert.equal(rgbToHexColor(25.5, 25.5, 25.5), undefined)
    })
    it("test with incorrect value", () => {
        assert.equal(rgbToHexColor(), undefined)
    })
    it("test with one missing value", () => {
        assert.equal(rgbToHexColor(255, 255), undefined)
    })
    it("test with correct white value", () => {
        assert.equal(rgbToHexColor(255,255,255), '#FFFFFF')
    })
    it("test with correct black value", () => {
        assert.equal(rgbToHexColor(6,6,6), '#060606')
    })
    it("test with correct black floats value", () => {
        assert.equal(rgbToHexColor(0.0,0.0,0.0), '#000000')
    })
})