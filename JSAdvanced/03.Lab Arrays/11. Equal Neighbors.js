function equalNeighbors(input) {
    let result = 0;
    for (let row = 0; row < input.length; row++) {
        for (let col = 0; col < input[row].length; col++) {
            let something = input[row][col];
            let neighborsRigth = input[row][col + 1];
            if (row < input.length - 1) {
                let neighborsDown = input[row + 1][col];
                if (neighborsDown === something) {
                    result++;
                }
            }
            if (neighborsRigth === something) {
                result++;
            }
        }
    }
    return result;
}
console.log(equalNeighbors([
    ['2', '2', '5', '7', '4'],
    ['4', '0', '5', '3', '4'],
    ['2', '5', '5', '4', '2']]));

console.log(equalNeighbors([
    ['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]));

console.log(equalNeighbors([
    ['test', 'yes', 'yo', 'ho'],
    ['well', 'done', 'yo', '6'],
    ['not', 'done', 'yet', '5']]));