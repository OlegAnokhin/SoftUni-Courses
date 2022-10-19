let library = require(`./library`);
let {expect, assert} = require('chai');
const { calcPriceOfBook, findBook, arrangeTheBooks } = require('./library');

describe("Tests library", function() {
    describe("Test calcPriceOfBook", () => {
        it("test property exist", () => {
            expect(library).to.have.property('calcPriceOfBook');
        });
        it("test with correct input old book", () => {
            expect(library.calcPriceOfBook("Troy", 1980)).to.equal("Price of Troy is 10.00");
        });
        it("test with correct input normal", () => {
            expect(library.calcPriceOfBook("Troy", 1981)).to.equal("Price of Troy is 20.00");
        });
        it("test name with incorrect type", () => {
            expect(()=> library.calcPriceOfBook(1, 1981)).to.throw(`Invalid input`);
            expect(()=> library.calcPriceOfBook(1981)).to.throw(Error, `Invalid input`);
        });
        it("test year with incorrect type", () => {
            expect(()=> library.calcPriceOfBook("Troy", "1981")).to.throw(Error, `Invalid input`);
            expect(()=> library.calcPriceOfBook("Troy", 1981.55)).to.throw(`Invalid input`);
            expect(()=> library.calcPriceOfBook("Troy")).to.throw(Error, `Invalid input`);
        });
        it("test year with incorrect type", () => {
            expect(()=> library.calcPriceOfBook("Troy")).to.throw(`Invalid input`);
        });
     });
     describe("Test findBook", () => {      
        it("test property exist", function() {
            expect(library).to.have.property('findBook');
        });  
        it("test with correct input", () => {
            expect(library.findBook(["Troy", "Life Style", "Torronto"], "Troy")).to.equal("We found the book you want.");
        });
        it("test with correct input but not find", () => {
            expect(library.findBook(["Troy", "Life Style", "Torronto"], "bla-bla-bla")).to.equal("The book you are looking for is not here!");
        });
        it("test with empty arr", () => {
            expect(()=> library.findBook([], "bla-bla-bla")).to.throw("No books currently available");
        });
     });
     describe("Test arrangeTheBooks", () => {     
        it("test property exist", () => {
            expect(library).to.have.property('arrangeTheBooks');
        });  
        it("test with string", () => {
            expect(()=> library.arrangeTheBooks("10")).to.throw(Error, "Invalid input");
        });
        it("test with negative number", () => {
            expect(()=> library.arrangeTheBooks(-1)).to.throw("Invalid input");
        });
        it("test with empty", () => {
            expect(()=> library.arrangeTheBooks()).to.throw(Error, "Invalid input");
        });
        it("test with float number", () => {
            expect(()=> library.arrangeTheBooks(2.5)).to.throw("Invalid input");
        });
        it("test with zero", () => {
            expect(library.arrangeTheBooks(0)).to.equal('Great job, the books are arranged.');
        });
        it("test with correct smaller input", () => {
            expect(library.arrangeTheBooks(40)).to.equal('Great job, the books are arranged.');
        });
        it("test with correct greater input", () => {
            expect(library.arrangeTheBooks(41)).to.equal('Insufficient space, more shelves need to be purchased.');
        });
     });
});
