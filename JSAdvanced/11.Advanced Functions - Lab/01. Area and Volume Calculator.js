function area() {
    return Math.abs(this.x * this.y);
};
function vol() {
    return Math.abs(this.x * this.y * this.z);
};
function solve(area, vol, input) {
    input = JSON.parse(input);
    let result = [];
    for (let entry of input) {
        let calcArea = area.call(entry);
        let calcVol = vol.call(entry);
        result.push({
            area: calcArea, volume: calcVol });
    };
    return result;
}
let result = solve(area, vol,`[
    {"x":"1","y":"2","z":"10"},    
    {"x":"7","y":"7","z":"10"},    
    {"x":"5","y":"2","z":"10"}    
    ]`);
console.log(JSON.stringify(result));