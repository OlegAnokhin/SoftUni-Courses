function fromTo(input) {
    let arr = JSON.parse(input);
    let colNames = Object.keys(arr[0]);
    let values = arr.map(obj => Object.values(obj));
    let result = `<table>\n`;
    makeKeyROw(colNames);
    makeValueRow(values);
    result += `</table>`;
    function makeKeyROw(colNames) {
        result += `    <tr>`
        for (let colName of colNames) {
            result += `<th>${colName}</th>`
        }
        result += `</tr>\n`;
    }
    function makeValueRow(values) {
        for (let value of values) {
            result += `    <tr>`
            result += `<td>${escapeHtml(value[0])}</td><td>${escapeHtml(value[1])}</td>`
            result += `</tr>\n`;
        }
    }
    function escapeHtml(value){
        return value.toString().replace('<', '&lt;').replace('>', '&gt;')
   }
   console.log(result);
}
console.log(fromTo(`[{"Name":"Stamat","Score":5.5},{"Name":"Rumen","Score":6}]`));

console.log(fromTo(`[{"Name":"Pesho","Score":4,"Grade":8},{"Name":"Gosho","Score":5," Grade":8},
         {"Name":"Angel","Score":5.50," Grade":10}]`));


        //  function solve(input) {
        //     let data = JSON.parse(input);
        //     let htmlText = ['<table>'];
        //     let singleObject = data[0]; 
        //     htmlText.push(makeHeaderRowFromKeys(singleObject));
        //     data.forEach(obj => htmlText.push(makeRowsFromValues(obj)));
        //     htmlText.push('</table>')
        //     function makeHeaderRowFromKeys(array) {
        //         let keys = [];
        //         Object.keys(array).forEach(key => {
        //             keys.push(`<th>${escapeHTML(key)}</th>`);
        //         })
        //         return '<tr>' + keys.join('') + '</tr>';
        //     }
        //     function makeRowsFromValues(obj) {
        //         let rows = [];
        //         Object.values(obj).forEach(value => {
        //             rows.push(`<td>${escapeHTML(value)}</td>`);
        //         })
        //         return '<tr>' + rows.join('') + '</tr>';
        //     }
        //     function escapeHTML(value) {
        //         return value
        //             .toString()
        //             .replace(/&/g, '&amp;')
        //             .replace(/</g, '&lt;')
        //             .replace(/>/g, '&gt;')
        //             .replace(/"/g, '&quot;')
        //             .replace(/'/g, '&#39;');
        //     }
        //     return htmlText.join('\r\n')
        // }
        // console.log(solve(`[{"Name":"Stamat",
        // "Score":5.5},
        // {"Name":"Rumen",
        // "Score":6}]`
        // ));