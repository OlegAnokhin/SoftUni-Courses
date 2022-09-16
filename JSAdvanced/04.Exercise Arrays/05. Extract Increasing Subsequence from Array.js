function extractIncr(arr){
    // let result = [];
    // let biggestNum = arr.shift();
    let result = arr.reduce((acc, num) => {

        if (acc.length !== 0) {
        if (acc[acc.length - 1] <= num) {
        acc.push(num);
        }
        } else {
        acc.push(num);
        }
        return acc;
        }, []);
 
    // result.push(biggestNum);
    // for (num of arr){
    //     if (num >= biggestNum){
    //         result.push(num);
    //         biggestNum = num;
    //     }
    // }
     return result;
}
extractIncr([20, 3, 2, 15,]);