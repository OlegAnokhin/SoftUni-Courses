function radar(speed, area) {
    let currSpeedLimit;
    switch (area) {
        case 'motorway': currSpeedLimit = 130;
            break;
        case 'interstate': currSpeedLimit = 90;
            break;
        case 'city': currSpeedLimit = 50;
            break;
        case 'residential': currSpeedLimit = 20;
            break;
    }
    let currSpeed = Number(speed);
    if (currSpeed <= currSpeedLimit) {
        return(`Driving ${currSpeed} km/h in a ${currSpeedLimit} zone`);
    }else{
        let overSpeed = currSpeed - currSpeedLimit;
        let status;
        if (overSpeed <= 20) {
            status = 'speeding';
        } else if (overSpeed > 20 && overSpeed <= 40) {
            status = 'excessive speeding';
        } else {
            status = 'reckless driving';
        }
        return `The speed is ${overSpeed} km/h faster than the allowed speed of ${currSpeedLimit} - ${status}`;
    }
}
console.log(radar(40, 'city'));
console.log(radar(21, 'residential'));
console.log(radar(120, 'interstate'));
console.log(radar(200, 'motorway'));