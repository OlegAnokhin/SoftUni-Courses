let PaymentPackage = require(`./12.PaymentPackage`);
let { assert } = require('chai')

describe("PaymenttPackage", () => {
    describe("create instanse", () => {
        let paymentPackage;
        beforeEach(function () {
            paymentPackage = new PaymentPackage("Oleg", 666);
        });
        it("name should be correct", () => {
            assert.equal(paymentPackage._name, "Oleg", "name has correct");
        })
        it("value should be correct", () => {
            assert.equal(paymentPackage._value, 666, "name has correct");
        })
        it("vat should be correct", () => {
            assert.equal(paymentPackage._VAT, 20, "value has correct");
            assert.equal(typeof (paymentPackage._VAT), 'number', "vat is correct")
        })
        it("active should be correct", () => {
            assert.equal(paymentPackage._active, true, "active has correct");
            assert.equal(typeof (paymentPackage._active), "boolean", "active is correct type")
        })
    })
    describe("test getters", () => {
        let paymentPackage;
        beforeEach(function () {
            paymentPackage = new PaymentPackage("Oleg", 666);
        });
        it("instance should be return correct", () => {
            assert.equal(paymentPackage.name, "Oleg");
        })
        it("value should be return correct", () => {
            assert.equal(paymentPackage.value, 666);
            paymentPackage.value = 0;
            assert.equal(paymentPackage.value, 0);
        })
        it(" VAT should be return correct", () => {
            assert.equal(paymentPackage.VAT, 20);
        })
        it("test active should be return correct", () => {
            assert.equal(paymentPackage.active, true);
        })
    })
    describe("test setters", () => {
        it("set incorect type name", () => {
            assert.throw(() => { new PaymentPackage(10, 10) }, 'Name must be a non-empty string');
        })
        it("set empty name", () => {
            assert.throw(() => { new PaymentPackage("", 10) }, 'Name must be a non-empty string');
        })
        it("set correct name", () => {
            let paymentPackage = new PaymentPackage("Oleg", 10);
            assert.equal(paymentPackage.name, "Oleg");
            paymentPackage.name = "Gosho"
            assert.equal(new paymentPackage("Gosho"));
        })
        it("set incorect value type ", () => {
            assert.throw(() => { new PaymentPackage("Oleg", "10") }, 'Value must be a non-negative number');
        })
        it("set negative value ", () => {
            assert.throw(() => { new PaymentPackage("Oleg", -666) }, 'Value must be a non-negative number');
        })
        it("set incorect VAT type ", () => {
            let paymentPackage = new PaymentPackage("Oleg", 10);
            assert.throw(() => { paymentPackage.VAT = "ala-ba-la" }, 'VAT must be a non-negative number');
        })
        it("set negative VAT ", () => {
            let paymentPackage = new PaymentPackage("Oleg", 10);
            assert.throw(() => { paymentPackage.VAT = -666 }, 'VAT must be a non-negative number');
        })
        it("set incorect status value", () => {
            let paymentPackage = new PaymentPackage("Oleg", 10);
            assert.throw(() => { paymentPackage.active = "ala-ba-la" }, 'Active status must be a boolean')
        })
    })
    describe("test output toString", () => {
        let paymentPackage;
        beforeEach(function () {
            paymentPackage = new PaymentPackage("Oleg", 666);
        });
        it("test active state", () => {
            const output = [
                `Package: Oleg`,
                `- Value (excl. VAT): 10`,
                `- Value (VAT 20%): ${10 * (1 + 20 / 100)}`
            ].join('\n');
            assert.equal(paymentPackage.toString(), output);
        })
        it("test not active state", () => {
            const output = [
                `Package: Oleg (inactive)`,
                `- Value (excl. VAT): 10`,
                `- Value (VAT 20%): ${10 * (1 + 20 / 100)}`
            ].join('\n');
            paymentPackage.active = false;
            assert.equal(paymentPackage.toString(), output);
        })
    })
})