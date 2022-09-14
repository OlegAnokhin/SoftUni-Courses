function sumOfNumber(start, end){
    let num1 = Number(start);
    let num2 = Number(end);
    let result = 0;
    for (let i = num1; i <= num2; i++){
        result += i;
    }
    console.log(result);
}
sumOfNumber('1', '5');
sumOfNumber('-8', '20');