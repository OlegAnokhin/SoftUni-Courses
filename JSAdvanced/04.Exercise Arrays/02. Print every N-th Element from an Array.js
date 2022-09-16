function printEveryN(arr, step){
    // let result = [];
    // for (let i = 0; i < arr.length; i += step){
    //     result.push(arr[i]);
    // }
    // return result;
    return arr.filter((el, i) => {
        if (i % step === 0 ){
            return el;
        }
    });
}
printEveryN(['5','20','31','4','20'],2);
printEveryN(['dsa', 'asd', 'test', 'tset',2]);