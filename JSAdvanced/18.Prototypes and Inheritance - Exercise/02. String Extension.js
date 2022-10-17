(
    function stringExtension() {
    String.prototype.ensureStart = function (str) {
        return this.startsWith(str) ? `${this}` : str + this;    
    };
    String.prototype.ensureEnd = function (str) {
        return this.endsWith(str) ? `${this}` : this + str;
    };
    String.prototype.isEmpty = function () {
        return this.length == 0 ? true : false;
    };
    String.prototype.truncate = function (n) {
        if (this.length <= n) {
            return this.toString();
        };
        if (n < 4) {
            return '.'.repeat(n);
        };
        let input = this.split(' ');
        while ((input.join(' ') + '...').length > n) {
            if (input.length > 1) {
                input.pop();
            }else {
                input[0] = input[0].slice(0, n - 3);
            }
        };
        return input.join(' ').trim() + '...';
    };
    String.format = function (str, ...params) {
        params.forEach((value, index) => str = str.replace(`{${index}}`.toString(), value));
        return str;
    }

    // let str = 'my string';
    // str = str.ensureStart('my');
    // console.log(str);
    // str = str.ensureStart('hello ');
    // console.log(str);
    // str = str.ensureEnd(' hello');
    // console.log(str)
    // str = str.isEmpty();
    // console.log(str)
    // str = str.truncate(16);
    // console.log(str)
    // str = str.truncate(14);
    // console.log(str)
    // str = str.truncate(8);
    // console.log(str)
    // str = str.truncate(4);
    // console.log(str)
    // str = str.truncate(2);
    // console.log(str)
    // str = String.format('The {0} {1} fox', 'quick', 'brown');
    // console.log(str)
    // str = String.format('jumps {0} {1}', 'dog');
    // console.log(str)
}
)()

//stringExtension();
