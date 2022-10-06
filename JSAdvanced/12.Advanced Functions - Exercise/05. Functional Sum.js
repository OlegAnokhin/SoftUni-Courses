function add(input) {
    let result = 0;
    function sum(num){
        result += num;
        return sum;
    }
    sum.toString = () => result;
    return sum(input)
}

console.log(add(4).toString());
console.log(add(1)(6)(-3).toString());