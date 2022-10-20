class SmartHike {
    constructor(username) {
        this.username = username;
        this.goals = {};
        this.listOfHikes = [];
        this.resources = 100;
    }
    addGoal(peak, altitude) {
        if (this.goals[peak] == undefined) {
            this.goals[peak] = Number(altitude);
            return `You have successfully added a new goal - ${peak}`;
        } else {
            return `${peak} has already been added to your goals`;
        }
    }
    hike(peak, time, difficultyLevel) {
        if (this.goals[peak] == undefined) {
            throw new Error(`${peak} is not in your current goals`);
        }
        if (this.resources == 0) {
            throw new Error("You don't have enough resources to start the hike");
        }
        let diffRes = (this.resources - (Number(time) * 10));
        if (diffRes < 0) {
            return "You don't have enough resources to complete the hike";
        }
        this.resources -= (Number(time) * 10);
        this.listOfHikes.push({ peak, time, difficultyLevel });
        return `You hiked ${peak} peak for ${time} hours and you have ${this.resources}% resources left`;
    }
    rest(time) {
        let restTime = time * 10;
        this.resources += restTime
        if (this.resources > 100) {
            this.resources = 100;
            return `Your resources are fully recharged. Time for hiking!`
        }
        return `You have rested for ${time} hours and gained ${restTime}% resources`

    }
    showRecord(criteria) {
        let result = [];
        if (this.listOfHikes.length == 0) {
            return (`${this.username} has not done any hiking yet`);
        }
        if (criteria === "all") {
            result = ["All hiking records:"];
            this.listOfHikes.map((p) => result.push(`${this.username} hiked ${p.peak} for ${p.time} hours`));
            return result.join("\n");
        }
        if (criteria === "hard" || criteria === "easy") {
            let hikes = this.listOfHikes.filter((h) => h.difficultyLevel === criteria);
            let sortedlist = hikes.sort((a, b) => a.time - b.time);
            let bestHike = sortedlist[0];
            if (bestHike === undefined) {
                return `${this.username} has not done any ${criteria} hiking yet`;
            }
            return (`${this.username}'s best ${criteria} hike is ${bestHike.peak} peak, for ${bestHike.time} hours`);
        }
    } 
}

// const user = new SmartHike('Vili');
// console.log(user.addGoal('Musala', 2925));
// console.log(user.addGoal('Rui', 1706));
// console.log(user.addGoal('Musala', 2925));
// Output 1
// You have successfully added a new goal - Musala
// You have successfully added a new goal - Rui
// Musala has already been added to your goals

// const user = new SmartHike('Vili');
// console.log(user.addGoal('Musala', 2925));
// console.log(user.addGoal('Rui', 1706));
// console.log(user.addGoal('Everest', 7006));
// console.log(user.hike('Musala', 8, 'hard'));
// console.log(user.hike('Rui', 3, 'easy'));
// console.log(user.hike('Everest', 12, 'hard'));
// Output 2
// You have successfully added a new goal - Musala
// You have successfully added a new goal - Rui
// You hiked Musala peak for 8 hours and you have 20% resources left
// You don't have enough resources to complete the hike
// Uncaught Error: Everest is not in your current goals

// const user = new SmartHike('Vili');
// console.log(user.addGoal('Musala', 2925));
// console.log(user.hike('Musala', 8, 'hard'));
// console.log(user.rest(4));
// console.log(user.rest(5));
// Output 3
// You have successfully added a new goal - Musala
// You hiked Musala peak for 8 hours and you have 20% resources left 
// You have rested for 4 hours and gained 40% resources 
// Your resources are fully recharged. Time for hiking!


const user = new SmartHike('Vili');
console.log(user.showRecord('all'));
user.addGoal('Musala', 2925);
user.hike('Musala', 8, 'hard');
console.log(user.showRecord('easy'));
user.addGoal('Vihren', 2914);
user.hike('Vihren', 4, 'hard');
console.log(user.showRecord('hard'));
user.addGoal('Rui', 1706);
user.hike('Rui', 3, 'easy');
console.log(user.showRecord('all'));
// Output 5
// Vili has not done any hiking yet
// Vili has not done any easy hiking yet
// Vili's best hard hike is Musala peak, for 8 hours
// All hiking records:
// Vili hiked Musala for 8 hours
