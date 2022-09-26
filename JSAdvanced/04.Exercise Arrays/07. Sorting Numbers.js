function sortingArr(arr){
    let result = [];
    let sortedArr = arr.sort((a,b)=> a - b);
    while(sortedArr.length != 0){
        result.push(sortedArr.shift());    
        result.push(sortedArr.pop());
    }        
    return result;
}
console.log(sortingArr([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]));
