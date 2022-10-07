function tikets(array, criteria) {
    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = price;
            this.status = status;
        }
    }
    let tiketsArr = [];
    for (let line of array) {
        let [destination, price, status] = line.split('|');
        tiketsArr.push(new Ticket(destination, Number(price), status));
    }
    if(criteria == 'destination'){
        tiketsArr.sort((a,b) => a[criteria].localeCompare(b[criteria]));
    }else if(criteria == 'status'){
        tiketsArr.sort((a,b) => a[criteria].localeCompare(b[criteria]));
    }else{
        tiketsArr.sort((a,b) => a - b);
    }
    return tiketsArr;
}
tikets(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination'
);