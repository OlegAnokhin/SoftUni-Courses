function jansNotation(array){
     let result = [];
     let number = [];
     let operators = [];

     let operationEnum = {
        "+":(a,b)=> a+b,
        "-":(a,b)=> a-b,
        "*":(a,b)=> a*b,
        "/":(a,b)=> a/b
     }
     for (let el of array){
        if(typeof(el) === "number"){
            number.push(el);
        } else{
            operators.push(el);
        }
     }
     if (operators.length < number.length -1){
        console.log("Error: too many operands!");
        return;
     }else if(number.length === operators.length || number.length === 0){
        console.log("Error: not enough operands!");
        return;
     }
     for (let el of array){
        if(typeof(el) === "number"){
            result.push(el);
            continue;
        } 
        let nummA = result.pop();
        let nummB = result.pop();
        let amount = operationEnum[el](nummB, nummA)
        result.push(amount)
     }
     console.log(result.join());
}
jansNotation([3, 4, '+']);
jansNotation([5, 3, 4, '*', '-'])