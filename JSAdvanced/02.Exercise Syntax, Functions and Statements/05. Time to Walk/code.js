function timeToWalk(steps, footPrint, speed){
    let distanceInM = steps * footPrint;
    let speedInMInSec = speed / 3.6;
    let time = distanceInM / speedInMInSec;
    let rest = Math.floor(distanceInM / 500);

    let timeInMin = Math.floor(time / 60)
    let timeInSec = Number((time - (timeInMin * 60)).toFixed(0));
    let timeInH = Math.floor(time / 3600);
    timeInMin += rest;
    timeInH += Math.floor(timeInMin / 60);
    timeInMin = timeInMin % 60;
 
    let formH = timeInH < 10 ? `0${timeInH}` : `${timeInH}`;
    let formM = timeInMin < 10 ? `0${timeInMin}` : `${timeInMin}`;
    let formS = timeInSec < 10 ? `0${timeInSec}` : `${timeInSec}`;
    console.log(`${formH}:${formM}:${formS}`)
}
timeToWalk(4000, 0.60, 5);
timeToWalk(2564, 0.70, 5.5);
