function validityChecker(x1, y1, x2, y2){
    let distance = function(x1, y1, x2 = 0, y2 = 0){
        let isValid = false;
        // let distanceX = Math.pow((x2 - x1), 2);
        // let distanceY = Math.pow((y2 - y1), 2);
        let result = Math.sqrt((Math.pow((x2 - x1), 2)) + (Math.pow((y2 - y1), 2)));
        if(Number.isInteger(result)){
            isValid = true;
        }
        return isValid;
    };
    let firstCase = (distance(x1, y1)) ? 'valid' : 'invalid';
    console.log(`{${x1}, ${y1}} to {0, 0} is ${firstCase}`);
    let secondCase = (distance(x2, y2)) ? 'valid' : 'invalid';
    console.log(`{${x2}, ${y2}} to {0, 0} is ${secondCase}`);
    let thirdCase = (distance(x1, y1, x2, y2)) ? 'valid' : 'invalid';
    console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is ${thirdCase}`);
}
validityChecker(3, 0, 0, 4);
validityChecker(2, 1, 1, 1);