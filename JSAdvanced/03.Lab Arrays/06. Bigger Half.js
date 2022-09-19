function biggerHalf(input){
    let result = input
        .sort((a, b) => a - b)
        .slice(input.length / 2);
    return result;
}
console.log(biggerHalf([4, 7, 2, 5]));
console.log(biggerHalf([3, 19, 14, 7, 2, 19, 6]));