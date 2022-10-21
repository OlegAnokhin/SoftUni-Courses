let flowerShop = require(`./flowerShop`);
let {expect, assert} = require('chai');

describe("Tests flowerShop", function() {
    describe("test calcPriceOfFlowers", function() {
        it("test invalid first value", function() {            
            expect(() => flowerShop.calcPriceOfFlowers(5, 5, 5))
            .to.throw("Invalid input!")
        });
        it("test invalid second value", function() {            
            expect(() => flowerShop.calcPriceOfFlowers("5", "5", 5))
            .to.throw("Invalid input!")
        });
        it("test invalid third value", function() {            
            expect(() => flowerShop.calcPriceOfFlowers("5", 5, "5"))
            .to.throw("Invalid input!")
        });
        it("test with correct input", function() {
            expect(flowerShop.calcPriceOfFlowers("5", 10, 5))
            .to.equal(`You need $50.00 to buy 5!`);
        })
     });
     describe("test checkFlowersAvailable", function() {
        it("test correct input with", function() {
            expect(flowerShop.checkFlowersAvailable(
                "Rose",
                ["Rose", "Lily", "Orchid"]
            )).to.equal(`The Rose are available!`);
        });
        it("test correct input without", function() {
            expect(flowerShop.checkFlowersAvailable(
                "Rose",
                ["Lily", "Orchid"]
            )).to.equal(`The Rose are sold! You need to purchase more!`);
        });
     });
     describe("test sellFlowers", function() {
        it("test invalid first value", function() {            
            expect(() => flowerShop.sellFlowers(
                5,
                5
                ))
            .to.throw("Invalid input!")
        });
        it("test invalid second value", function() {            
            expect(() => flowerShop.sellFlowers(
                    ["Rose", "Lily", "Orchid"],
                    "5"                    
                ))
            .to.throw("Invalid input!")
        });
        it("test invalid value -1", function() {            
            expect(() => flowerShop.sellFlowers(
                    ["Rose", "Lily", "Orchid"],
                    -1                   
                ))
            .to.throw("Invalid input!")
        });
        it("test invalid value 3", function() {            
            expect(() => flowerShop.sellFlowers(
                    ["Rose", "Lily", "Orchid"],
                    3                   
                ))
            .to.throw("Invalid input!")
        });
        it("test correct input 1", function() {
            expect(flowerShop.sellFlowers(
                ["Rose","Lily", "Orchid"],
                1
            )).to.equal('Rose / Orchid');
        });
     });
});
