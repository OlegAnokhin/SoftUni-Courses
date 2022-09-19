function biggestEl(array){
    let biggNum = Number.MIN_SAFE_INTEGER;
    for (let row = 0; row < array.length; row++) {
        let currBiggNum = Math.max(...array[row]);
        if (currBiggNum >= biggNum){
            biggNum = currBiggNum;
        }
    }
    return biggNum;
}

console.log(biggestEl([[20, 50, 10],
                       [8, 33, 145]]));