function attachEvents() {
    document.getElementById('submit').addEventListener('click', getWeather);
}
async function getWeather() {
    const currSec = document.getElementById('current');
    const upcomingContainer = document.getElementById('upcoming');
    const forecastContainer = document.getElementById('forecast');

    try {
        debugger
        const url = `http://localhost:3030/jsonstore/forecaster/locations`;
        const townName = document.getElementById('location').value;
        const respons = await fetch(url);
        const data = await respons.json();
        const info = data.find(x => x.name === townName);
        const [todayData, upcomingData] = await Promise.all([
            getToday(info.code),
            getUpcoming(info.code)
        ])
        forecastContainer.style.display = 'block';
        const todayHTMLTemp = createToday(todayData);
        currSec.appendChild(todayHTMLTemp);
        const upcomingHTMLTemp = createUpcoming(upcomingData);
        upcomingContainer.appendChild(upcomingHTMLTemp);
    } catch (e){
        forecastContainer.style.display = 'block';
        document.querySelector('.label').textContent = 'Error'
    }
}

async function getToday(code) {
    const urlToday = `http://localhost:3030/jsonstore/forecaster/today/${code}`;
    const responsToday = await fetch(urlToday);
    const dataToday = await responsToday.json();
    return dataToday;
}
async function getUpcoming(code) {
    const urlThreeDays = `http://localhost:3030/jsonstore/forecaster/upcoming/${code}`
    const responsThree = await fetch(urlThreeDays);
    const dataThree = await responsThree.json();
    return dataThree;
}
function createToday(data) {
    const enumItem = {
        "Sunny": "&#x2600", // ☀
        "Partly sunny": "&#x26C5", // ⛅
        "Overcast": "&#x2601", // ☁
        "Rain": "&#x2614", // ☂
        "Degrees": "&#176" // °
    }
    const { condition, high, low } = data.forecast;
    const conditionContainer = document.createElement('div');
    conditionContainer.classList.add('forecasts');

    const conditionIconSpan = document.createElement('span');
    conditionIconSpan.classList.add('condition symbol');
    conditionIconSpan.innerHTML = enumItem[condition];

    const conditionSpan = document.createElement('span');
    conditionSpan.classList.add('condition');

    const nameSpan = document.createElement('span');
    nameSpan.classList.add('forecast-data');
    nameSpan.textContent = data.name;

    const tempSpan = document.createElement('span');
    tempSpan.classList.add('forecast-data');
    tempSpan.innerHTML = `${low}${enumItem['Degrees']}/${high}${enumItem['Degrees']}`;

    const conditionTxtSpan = document.createElement('span');
    conditionTxtSpan.classList.add('forecast-data');
    conditionTxtSpan.textContent = condition;

    conditionSpan.appendChild(nameSpan);
    conditionSpan.appendChild(tempSpan);
    conditionSpan.appendChild(conditionTxtSpan);

    conditionContainer.appendChild(conditionIconSpan);
    conditionContainer.appendChild(conditionSpan);
    return conditionContainer;
}
function createUpcoming(data) {
    const container = document.createElement('div');
    container.classList.add('forecast-info');
    data.forecast.forEach(data => {
        const spanHolder = generateSpans(data);
        container.appendChild(spanHolder)
    });
    return container;
}
function generateSpans(data) {
    const enumItem = {
        "Sunny": "&#x2600", // ☀
        "Partly sunny": "&#x26C5", // ⛅
        "Overcast": "&#x2601", // ☁
        "Rain": "&#x2614", // ☂
        "Degrees": "&#176" // °
    }
    const { condition, high, low } = data
    const spanHolder = document.createElement('span');
    spanHolder.classList.add('upcoming');

    const iconSpan = document.createElement('span');
    iconSpan.classList.add('symbol');
    iconSpan.innerHTML = enumItem[condition];

    const tempSpan = document.createElement('span');
    tempSpan.classList.add('forecast-data');
    tempSpan.innerHTML = `${low}${enumItem['Degrees']}/${high}${enumItem['Degrees']}`;

    const conditionSpan = document.createElement('span');
    conditionSpan.classList.add('forecast-data');
    conditionSpan.textContent = condition;

    spanHolder.appendChild(iconSpan);
    spanHolder.appendChild(tempSpan);
    spanHolder.appendChild(conditionSpan);
    return spanHolder;
}

attachEvents();