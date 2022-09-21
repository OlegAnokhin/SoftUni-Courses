function colorize() {
    let tableRow = document.querySelectorAll('table tr');
    for (let i = 1; i < tableRow.length - 1; i++){
        if (i % 2 ===1){
            tableRow[i].style.backgroundColor = 'teal';
        }
    }
}