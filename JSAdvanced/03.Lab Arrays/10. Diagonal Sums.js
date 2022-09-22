function diagonalSum(input){
    let firstDiogonal = 0;
    let secondDiogonal = 0;
    for (let row = 0; row < input.length; row++) {
        firstDiogonal += input[row][row];
        secondDiogonal += input[row][input[row].length - 1 - row]
    }
    return result = firstDiogonal + ' ' + secondDiogonal
}
console.log(diagonalSum([
    [20, 40],
    [10, 60]]));
console.log('--------');
console.log(diagonalSum([
    [3, 5, 17],
    [-1, 7, 14], 
    [1, -8, 89]]));