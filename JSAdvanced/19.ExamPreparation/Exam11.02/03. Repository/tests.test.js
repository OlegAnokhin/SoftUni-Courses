let { Repository } = require("./solution.js");
let { expect } = require('chai');

describe("Tests Repository", function () {
    let properties = {
        name: "string",
        age: "number",
        birthday: "object"
    };
    let entity = {
        name: "Pesho",
        age: 22,
        birthday: new Date(1998, 0, 7)
    };
    describe("Test Instantiation", function () {
        it("Test should add props", function () {
            let repository = new Repository(properties);
            expect(repository).to.have.property('props');
            expect(repository.props).to.deep.equal(properties);
        });
        it("Test should prop data", function () {
            let repository = new Repository(properties);
            expect(repository).to.have.property('data');
            expect(typeof repository.data).is.equal('object');
            expect(repository.data).instanceOf(Map)
        });
    });
    describe("Test add", function () {
        it("Test should return zero for first", function () {
            let repository = new Repository(properties);
            let result = repository.add(entity); 
            expect(result).is.equal(0)
        });
        it("Test should return count", function () {
            let repository = new Repository(properties);
            repository.add(entity); 
            expect(repository.count).is.equal(1)
        });
        it("Test should store", function () {
            let repository = new Repository(properties);
            repository.add(entity); 
            expect(repository.data.get(0)).not.to.be.undefined;
            expect(repository.data.get(0)).to.deep.equal(entity);
        });
        it("Test should throw with miss prop", function () {
            let entity = {
                name: "Pesho",
                age: 22
            };
            let repository = new Repository(properties);
            expect(()=> repository.add(entity)).to.throw(Error, `Property birthday is missing from the entity!`);
        });
        it("Test should throw with other type prop", function () {
            let entity = {
                name: "Pesho",
                age: 22,
                birthday: 'new Date(1998, 0, 7)'
            };
            let repository = new Repository(properties);
            expect(()=> repository.add(entity)).to.throw(Error, `Property birthday is not of correct type!`);
        });
    })
    // describe("Test get count", function () {
    //     it("Test should return count", function () {
    //         let entity = {
    //             name: "Pesho",
    //             age: 22,
    //             birthday: new Date(1998, 0, 7)
    //         };
    //         let repository = new Repository();
    //         repository.add(entity)
    //         expect(repository.count).is.equal(1)
    //     });
    // })
});
