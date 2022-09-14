function squareOfStars(input){
    if (input == null){
        for (let i = 0; i < 5; i++){
            console.log('* '.repeat(5));
        }
    }
    else {
        for (let q = 0; q < input; q++){
            console.log('* '.repeat(input));
        } 
    }
}
squareOfStars(2);
squareOfStars();