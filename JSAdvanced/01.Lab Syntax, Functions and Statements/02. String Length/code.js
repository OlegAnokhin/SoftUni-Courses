function solve(arr1, arr2, arr3){

    let firstLenght = arr1.length;
    let secondLenght = arr2.length;
    let thirdLenght = arr3.length;

    let sum = firstLenght + secondLenght + thirdLenght;
    let average = Math.floor(sum / 3);
    console.log(sum);
    console.log(average);
}
solve('chocolate', 'ice cream', 'cake')
solve('Oleg', 'Petya', 'Dany')