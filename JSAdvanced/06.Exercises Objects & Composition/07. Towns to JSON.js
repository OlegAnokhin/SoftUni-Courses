function toJson(input) {
    let result = [];
    let [town, lati, long] = input[0].slice(2, -2).split(' | ');
    for(let i = 1; i < input.length; i ++){
        let [townName, latitude, longitude] = input[i].slice(2, -2).split(' | ');
        result.push({
            [town]: townName,
            [lati]: Number(latitude).toFixed(2),
            [long]: Number(longitude).toFixed(2)
        })
    }
    console.log(JSON.stringify(result, function(k,v){
        if(k == 'Latitude'){
            return Number(v);
        }else if(k == 'Longitude'){
            return Number(v);
        }else{
            return v;
        }
    }));
}

toJson(
    ['| Town | Latitude | Longitude |',
     '| Sofia | 42.696552 | 23.32601 |',
     '| Beijing | 39.913818 | 116.363625 |']);