function generateReport() {
    let checkBoxesIndices = [];
    let checkBoxes = Array.from(document.querySelectorAll('input'));
    let rows = Array.from(document.querySelectorAll('tbody tr'));
    let outputElement = document.getElementById('output');
    
    checkBoxes.forEach((el, index) => {
        if (el.checked) {
            checkBoxesIndices.push(index);
        };
    });
    for (let i = 0; i < checkBoxes.length; i++) {
        let element = checkBoxes[i];
        if (element.checked) {
            checkBoxesIndices.push(i);
        };
    };
    let result = [];
    for (let row of rows) {
        let obj = {};
        for (let index of checkBoxesIndices) {
            let propName = checkBoxes[index].name;
            let propData = row.children[index].textContent;
            obj[propName] = propData;
        }
        result.push(obj);
    }
    let report = JSON.stringify(result);
    outputElement.textContent = report
}