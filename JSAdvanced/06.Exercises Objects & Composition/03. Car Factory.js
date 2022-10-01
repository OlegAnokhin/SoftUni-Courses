function carFactory(input){
    let result = {};
    result.model = input.model;
    if (input.power <= 90){
        result.engine = {
            power: 90,
            volume: 1800
        }
    } else if (input.power <= 120){
        result.engine = {
            power: 120,
            volume: 2400
        }
    }else {
        result.engine = {
            power: 200,
            volume: 3500
        }
    }
    if (input.carriage === 'hatchback'){
        result.carriage = {
            type: 'hatchback',
            color: input.color
        }
    }else {
        result.carriage = {
            type: 'coupe',
            color: input.color
        }
    }
    let size = input.wheelsize % 2 === 0 ? input.wheelsize - 1 : input.wheelsize;
    result.wheels = new Array(4).fill(size);
   
    //console.table(result)
     return result;
}
console.log(carFactory(
{ model: 'VW Golf II',
  power: 90,
  color: 'blue',
  carriage: 'hatchback',
  wheelsize: 14 }));