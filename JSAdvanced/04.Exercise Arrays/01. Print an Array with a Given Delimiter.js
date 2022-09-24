function printWithDel(arr, delimiter) {
    return arr.join(delimiter);
}
console.log(printWithDel(['One', 'Two', 'Three', 'Four', 'Five'], '-'));
console.log(printWithDel(['How about no?', 'I', 'will', 'not', 'do', 'it!'], '_'));

// function printWithDel(arr, delimiter) {
//     let result = "";
//     let count = 0;
//     for (let element of arr) {
//         if (count == arr.length - 1) {
//             result += element;
//         } else {
//             result += element + delimiter;
//             count++;
//         }
//     }
//     console.log(result);
// }
// printWithDel(['One', 'Two', 'Three', 'Four', 'Five'], '-');
// printWithDel(['How about no?', 'I', 'will', 'not', 'do', 'it!'], '_');