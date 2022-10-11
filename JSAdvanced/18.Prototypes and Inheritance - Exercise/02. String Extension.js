//(
    function stringExtension() {
    Array.prototype.ensureStart = function (str) {
        return this[this.length - 1];
    }
    Array.prototype.ensureEnd = function (str) {
        return this.slice(n);
    }
    Array.prototype.isEmpty = function () {
        return this.slice(0, n)
    }
    Array.prototype.truncate = function (n) {
        return this.reduce((prevValue , nextValue) => prevValue + nextValue);
    }
    Array.prototype.format = function (string, ...params) {
        return this.sum() / this.length;
    }

    let str = 'my string';
    str = str.ensureStart('my');
    str = str.ensureStart('hello ');
    str = str.truncate(16);
    str = str.truncate(14);
    str = str.truncate(8);
    str = str.truncate(4);
    str = str.truncate(2);
    str = String.format('The {0} {1} fox','quick', 'brown');
    str = String.format('jumps {0} {1}','dog');
}
//)()

stringExtension();
