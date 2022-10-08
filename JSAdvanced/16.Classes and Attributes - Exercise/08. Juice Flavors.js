function juice(arr) {
    let juices = {};
    let bottles = {};

    function createBottle(flavor) {
        if (juices[flavor] >= 1000) {
            if (!bottles.hasOwnProperty(flavor)) {
                bottles[flavor] = 0
            }
            let numOfBottles = Math.floor(juices[flavor] / 1000);
            bottles[flavor] += numOfBottles;
            juices[flavor] -= (numOfBottles * 1000);
        }
    }
    for (let juice of arr) {
        let [flavor, qty] = juice.split(' => ');
        if (!juices.hasOwnProperty(flavor)) {
            juices[flavor] = 0
        }
        juices[flavor] += Number(qty);
        createBottle(flavor)
    }
    for (let flavor in bottles) {
        console.log(flavor + ' => ' + bottles[flavor])
    }
}
juice(
    ['Orange => 2000',
        'Peach => 1432',
        'Banana => 450',
        'Peach => 600',
        'Strawberry => 549'
    ]);

juice(
    ['Kiwi => 234',
        'Pear => 2345',
        'Watermelon => 3456',
        'Kiwi => 4567',
        'Pear => 5678',
        'Watermelon => 6789'
    ]);