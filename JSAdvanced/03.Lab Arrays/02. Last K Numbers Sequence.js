function lastNumber(num1, num2){
    let arr = [1];
    for (let i = 1; i < num1; i++){
        let start = i - num2 < 0 ? 0 : i - num2;
        arr.push(arr.slice(start).reduce((acc, num) => acc + num));
    }
    return arr;
}
console.log(lastNumber(6, 3));
console.log(lastNumber(8, 2));