async function getInfo() {
    const stopInfoElement = document.getElementById('stopId');
    const stopId = stopInfoElement.value;
    const url = `http://localhost:3030/jsonstore/bus/businfo/${stopId}`;    
    const stopNameElement = document.getElementById('stopName');
    const busList = document.getElementById('buses');
    busList.innerHTML = '';
    stopInfoElement.value = '';

    try{
        const respons = await fetch(url);
        const data = await respons.json();
    
        stopNameElement.textContent = data.name;
        Object.entries(data.buses).forEach(([busNumber, timeArrive]) => {
            const li = document.createElement('li');
            li.textContent = `Bus ${busNumber} arrives in ${timeArrive} minutes`;
            busList.appendChild(li);
        })
    }
    catch(e){
        stopNameElement.textContent = 'Error'
    }
}