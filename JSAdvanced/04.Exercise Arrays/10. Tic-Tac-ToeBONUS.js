function TicTacToe(input) {
    let initDachBoard = [
        [false, false, false],
        [false, false, false],
        [false, false, false]
    ]
    let isFirstPl = true;
    for (let coordinates of input) {
        let [x, y] = coordinates.split(" ");
        if (initDachBoard[x][y]) {
            console.log(`This place is already taken. Please choose another!`);
            continue;
        }
        let marker = isFirstPl ? "X" : "O";
        initDachBoard[x][y] = marker;
        for (let i = 0; i < initDachBoard.length; i++) {
            if (initDachBoard[i][0] === marker &&
                initDachBoard[i][1] === marker &&
                initDachBoard[i][2] === marker) {
                console.log(`Player ${marker} wins!`)
                initDachBoard.forEach(row => console.log(row.join("\t")));
                return;
            } else if (initDachBoard[0][i] === marker &&
                initDachBoard[1][i] === marker &&
                initDachBoard[2][i] === marker) {
                console.log(`Player ${marker} wins!`)
                initDachBoard.forEach(row => console.log(row.join("\t")));
                return;
            } else if (initDachBoard[0][0] === marker &&
                initDachBoard[1][1] === marker &&
                initDachBoard[2][2] === marker) {
                console.log(`Player ${marker} wins!`)
                initDachBoard.forEach(row => console.log(row.join("\t")));
                return
            } else if (initDachBoard[2][0] === marker &&
                initDachBoard[1][1] === marker &&
                initDachBoard[0][2] === marker) {
                console.log(`Player ${marker} wins!`);
                initDachBoard.forEach(row => console.log(row.join("\t")));
                return;
            }
        }
        let isFreeSpace = false;
        for (let row = 0; row < initDachBoard.length; row++){
            for ( let col = 0; col < initDachBoard[row].length; col++){
                if(!initDachBoard[row][col]){
                    isFreeSpace = true;
                    break;
                }
            }
            if(isFreeSpace){
                break;
            }
        }
        if (!isFreeSpace){
            console.log(`The game ended! Nobody wins :(`);
            initDachBoard.forEach(row => console.log(row.join("\t")));
            return;
        }
        isFirstPl = !isFirstPl;
    }

}
TicTacToe(["0 1", "0 0", "0 2", "2 0", "1 0", "1 1", "1 2", "2 2", "2 1", "0 0"]);