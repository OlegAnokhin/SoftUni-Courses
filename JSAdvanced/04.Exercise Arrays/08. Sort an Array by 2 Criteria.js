function sortArrBy2(arr) {

    let result = arr.sort((a, b) => {
        if (a.length !== b.length) {
            return a.length - b.length
        } else {
            return a.localeCompare(b)
        }
    })
    console.log(result.join("\n"));
}
sortArrBy2(['alpha', 'beta', 'gamma']);
sortArrBy2(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);