function solve() {
    const url = 'http://localhost:3030/jsonstore/bus/schedule';
    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    const infoElement = document.querySelector('.info');
    let stopId = 'depot';
    let stopName = '';
    
    async function depart() {
        let respons = await fetch(`${url}/${stopId}`);
        if (!respons.ok) {
            infoElement.textContent = "Error";
            departBtn.disabled = true;
            arriveBtn.disabled = true;
        }
        let data = await respons.json();
        stopName = data.name;
        infoElement.textContent = `Next stop ${stopName}`;
        stopId = data.next;
        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }
    function arrive() {
        infoElement.textContent = `Arriving at ${stopName}`;
        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }
    return {
        depart,
        arrive
    };
}
let result = solve();