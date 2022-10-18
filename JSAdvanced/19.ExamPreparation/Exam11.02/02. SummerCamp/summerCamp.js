class SummerCamp {
    constructor(organizer, location) {
        this.organizer = organizer;
        this.location = location;
        this.priceForTheCamp = { "child": 150, "student": 300, "collegian": 500 };
        this.listOfParticipants = [];
    }
    registerParticipant(name, condition, money) {
        let currPrice = this.priceForTheCamp[condition];
        let findExistName = this.listOfParticipants.find(n => n.name === name);
        if (currPrice == undefined) {
            throw new Error("Unsuccessful registration at the camp.");
        }
        if (findExistName) {
            return `The ${name} is already registered at the camp.`;
        }
        if (money < currPrice) {
            return `The money is not enough to pay the stay at the camp.`;
        }
        this.listOfParticipants.push({ name, condition, power: 100, wins: 0 });
        return `The ${name} was successfully registered.`
    }
    unregisterParticipant(name) {
        let findName = this.listOfParticipants.find(n => n.name === name);
        if (!findName) {
            throw new Error(`The ${name} is not registered in the camp.`);
        }
        this.listOfParticipants = this.listOfParticipants.filter(n => n.name !== name);
        return `The ${name} removed successfully.`;
    }
    timeToPlay(typeOfGame, participant1, participant2) {
        if (typeOfGame == "WaterBalloonFights") {
            let playerOne = this.listOfParticipants.find(n => n.name === participant1);
            let playerTwo = this.listOfParticipants.find(n => n.name === participant2);
            if(!playerOne || !playerTwo) {
                throw new Error(`Invalid entered name/s.`);
            }
            if (playerOne.condition != playerTwo.condition) {
                throw new Error(`Choose players with equal condition.`);
            }
            if(playerOne.power > playerTwo.power) {
                playerOne.wins++;
                return `The ${playerOne.name} is winner in the game ${typeOfGame}.`;
            }
            if(playerOne.power < playerTwo.power) {
                playerTwo.wins++;
                return `The ${playerTwo.name} is winner in the game ${typeOfGame}.`;
            }
            return `There is no winner.`;
        }
        if (typeOfGame == "Battleship") {
            let player = this.listOfParticipants.find(n => n.name === participant1);
            if(!player) {
                throw new Error(`Invalid entered name/s.`);
            }
            player.power += 20;
            return `The ${player.name} successfully completed the game ${typeOfGame}.`;
        }
    }
    toString() {
        let result = [`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`];
        this.listOfParticipants.sort((a,b) => b.wins - a.wins)
        .map(p => result.push(`${p.name} - ${p.condition} - ${p.power} - ${p.wins}`));        
        return result.join("\n");
    }
}

const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
//console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Sara Dickinson"));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp.toString());
