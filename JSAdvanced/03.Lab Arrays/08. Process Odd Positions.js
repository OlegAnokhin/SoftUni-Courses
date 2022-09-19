function prOddPos(array){
    let result = array
    .filter((el, index) => index % 2 !== 0)
    .map(x => x * 2)
    .reverse()
    .join(" ");
    return result;

    
    // let result = [];
    // for (let i = 1; i < array.length; i+=2) {
    //     let currNum = array[i] * 2;
    //     result.push(currNum);        
    // }
    // result.reverse();
    // console.log(result.join(" "));
}
prOddPos([10, 15, 20, 25]);
prOddPos([3, 0, 10, 4, 7, 3]);