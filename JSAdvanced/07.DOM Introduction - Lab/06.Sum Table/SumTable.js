function sumTable() {
    let tableRow = document.querySelectorAll('table tr');
    let sum = 0;
    for (let i = 1; i < tableRow.length - 1; i++){
        let colums = tableRow[i].children;
        sum += Number(colums[1].textContent);  
    }
    document.getElementById('sum').innerText = sum
}