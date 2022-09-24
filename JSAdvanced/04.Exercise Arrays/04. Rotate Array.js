function rotateArr(arr, step){
    for (let i = 1; i <= step; i++) {
        arr.unshift(arr.pop());                
    }
    return arr.join(" ");
}
console.log(rotateArr(['1', '2', '3', '4'], 2));
console.log(rotateArr(['Banana', 'Orange', 'Coconut', 'Apple'], 15));

// function rotateArr(arr, step){
//     arr.reverse();
//     for (let i = 1; i <= step; i++) {
//         let currEl = arr[0];
//         arr.shift();
//         arr.push(currEl);        
//     }
//     arr.reverse();
//     return arr.join(" ");
// }
// console.log(rotateArr(['1', '2', '3', '4'], 2));
// console.log(rotateArr(['Banana', 'Orange', 'Coconut', 'Apple'], 15));