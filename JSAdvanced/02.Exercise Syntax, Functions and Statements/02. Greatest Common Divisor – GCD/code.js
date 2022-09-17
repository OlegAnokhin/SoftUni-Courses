function greatesDiv(num1, num2){
    let biggestNum = 0;
    for (let i = num1; i > 0; i--){
        if (num1 % i === 0 && num2 % i === 0){
            biggestNum = i;
            break;
        }
    }
    return biggestNum;
}
console.log(greatesDiv(15, 5));
console.log(greatesDiv(2154, 458));