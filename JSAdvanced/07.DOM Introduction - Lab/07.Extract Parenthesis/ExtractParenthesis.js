function extract(elementId) {
    let elementText = document.getElementById(elementId).textContent;
    let pattern = /\(([^)]+)\)/g;
    let result = elementText.matchAll(pattern);
    let matches = [];
    for (let text of result) {
        matches.push(text[1]);
    }
    return matches.join("; ");
}
let result = extract('content');
console.log(result)