function aggregateElements(input){
    let sum = 0;
    for (let i = 0; i < input.length; i++){
        sum += input[i];
    }
    let secondSum = 0;
    for (let i = 0; i < input.length; i++){
        secondSum += 1 / input[i];
    }
    let concatString = input.join('');
    console.log(sum);
    console.log(secondSum);
    console.log(concatString);
}
aggregateElements([1, 2, 3]);
aggregateElements([2, 4, 8, 16]);