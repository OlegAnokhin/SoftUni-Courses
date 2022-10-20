let carService = require(`./03. Car Service/03. Car Service_Resources`);
let { expect, assert } = require('chai');
const { partsToBuy } = require('./03. Car Service/03. Car Service_Resources');

describe("Tests carService", () => {
    describe("test isItExpensive ", () => {
        it("test correct input Engine", () => {
            expect(carService.isItExpensive("Engine")).to.equal(
                `The issue with the car is more severe and it will cost more money`
            );
        });
        it("test correct input Transmission", () => {
            expect(carService.isItExpensive("Transmission")).to.equal(
                `The issue with the car is more severe and it will cost more money`
            );
        });
        it("test correct input tire", () => {
            expect(carService.isItExpensive("tire")).to.equal(
                `The overall price will be a bit cheaper`
            );
        });
    });
    describe("test discount", () => {
        it("test with first invalid parameter", () => {
            expect(() => carService.discount("1", 100)
                .to.throw("Invalid input")
            );
        });
        it("test with second invalid parameter", () => {
            expect(() => carService.discount(1, "100")
                .to.throw("Invalid input")
            );
        });
        it("test correct input 0%", () => {
            expect(carService.discount(2, 100)).to.equal(
                "You cannot apply a discount"
            );
        });
        it("test correct input 15%", () => {
            expect(carService.discount(3, 100)).to.equal(
                `Discount applied! You saved 15$`
            );
        });
        it("test correct input 30%", () => {
            expect(carService.discount(8, 100)).to.equal(
                `Discount applied! You saved 30$`
            );
        });
        describe("test partsToBuy", function () {
            it("test with first invalid type", function () {
                expect(() => carService.partsToBuy("test", ["tire", "engine"])
                    .to.throw("Invalid input")
                );
            });
            it("test with second invalid type", function () {
                expect(() => carService.partsToBuy(["tire", "engine"], "test")
                    .to.throw("Invalid input")
                );
            });
            it("test correct input", () => {
                expect(carService.partsToBuy(
                    [{ part: "blowoff valve", price: 145 }, { part: "coil springs", price: 230 }],
                    ["blowoff valve", "injectors"]
                )).to.equal(145);
            });
            it("test with empty partsCatalog", () => {
                expect(carService.partsToBuy(
                    [],
                    ["blowoff valve", "injectors"]
                )).to.equal(0);
            });
        });
    });
});
