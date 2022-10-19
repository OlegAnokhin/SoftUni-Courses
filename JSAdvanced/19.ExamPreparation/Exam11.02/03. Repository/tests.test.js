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
    let clonedEntyty = {
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
        it("Test should have nextId func", function () {
            let repository = new Repository(properties);
            expect(repository).to.have.property('nextId');
            expect(typeof repository.nextId).to.equal('function');
            expect(repository.nextId()).to.equal(0);
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
            // expect(repository.data.get(0)).to.have.property('name').that.equals('Pesho');
            // expect(repository.data.get(0)).to.have.property('age').that.equals(22);
            // expect(repository.data.get(0)).to.have.property('birthday');
        });
        it("Test should throw with miss prop", function () {
            let entity1 = {
                age: 22,
                birthday: new Date(1998, 0, 7)
            };
            let entity2 = {
                name: "Pesho",
                birthday: new Date(1998, 0, 7)
            };
            let entity3 = {
                name: "Pesho",
                age: 22
            };
            let repository = new Repository(properties);
            expect(()=> repository.add(entity1)).to.throw(Error, `Property name is missing from the entity!`);
            expect(()=> repository.add(entity2)).to.throw(Error, `Property age is missing from the entity!`);
            expect(()=> repository.add(entity3)).to.throw(Error, `Property birthday is missing from the entity!`);
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
    describe("Test get count", function () {
        it("Test should return count", function () {
            let repository = new Repository(properties);
            repository.add(entity);
            repository.add(entity);
            repository.add(entity)
            expect(repository.count).is.equal(3)
        });
        it("Test should return zero ", function () {
            let repository = new Repository(properties);
            expect(repository.count).is.equal(0)
        });
    })
    describe("Test get Id", function () {
        it("Test should return id", function () {
            let repository = new Repository(properties);
            let id = repository.add(entity);
            expect(repository.getId(0)).to.deep.equal(clonedEntyty)
        });
        it("Test should throw error", function () {
            let repository = new Repository(properties);
            expect(() =>repository.getId(0)).to.throw(Error, `Entity with id: 0 does not exist!`)
        });
    })
    describe("Test update", function () {
        it("Test should return correct value", function () {
            let NewEntity = {
                name: "Gosho",
                age: 33,
                birthday: new Date(1998, 0, 7)
            };
            let repo = new Repository(properties);
            repo.add(entity);
            repo.update(0, NewEntity)
            expect(repo.getId(0).name).to.equal('Gosho')
        });
        it('Should throw error when updating incorect value', () => {
            let invalidEntity1 = {
                age: 22,
                birthday: new Date(1998, 0, 7)
            };

            let invalidEntity2 = {
                name: "Pesho",
                birthday: new Date(1998, 0, 7)
            };

            let invalidEntity3 = {
                name: "Pesho",
                age: 22,
            };

            let repository = new Repository(properties);

            repository.add(entity);

            expect(() => repository.update(0, invalidEntity1)).to.throw(Error, `Property name is missing from the entity!`)
            expect(() => repository.update(0, invalidEntity2)).to.throw(Error, `Property age is missing from the entity!`)
            expect(() => repository.update(0, invalidEntity3)).to.throw(Error, `Property birthday is missing from the entity!`)
        });
        it("Test should throw error", function () {
            let repository = new Repository(properties);
            expect(() => repository.update(0, entity)).to.throw(Error, `Entity with id: 0 does not exist!`)
        });
    })
    describe("Test del", function () {
        it("Test should return correct value", function () {
            let repository = new Repository(properties);
            repository.add(entity);
            repository.add(entity);
            expect(repository.count).is.equal(2)
            repository.del(1)
            expect(repository.count).is.equal(1)
            repository.del(0)
            expect(repository.count).is.equal(0)
        });
        it("Test should throw error", function () {
            let repository = new Repository(properties);
            expect(() => repository.del(0)).to.throw(Error, `Entity with id: 0 does not exist!`)
            expect(() => repository.del(-1.7)).to.throw(`Entity with id: -1.7 does not exist!`);
        });
    })
});
