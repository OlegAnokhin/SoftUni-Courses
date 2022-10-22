class footballTeam {
    constructor(clubName, country) {
        this.clubName = clubName;
        this.country = country;
        this.invitedPlayers = [];
    }
    newAdditions(footballPlayers) {
        footballPlayers.forEach(player => {
            let [name, age, plValue] = player.split("/");
            age = Number(age);
            plValue = Number(plValue);
            let currPlayer = this.invitedPlayers.find(pl => pl.name === name);
            if (!currPlayer) {
                this.invitedPlayers.push({name, age, plValue})
            } else if (currPlayer.plValue < plValue) {
                currPlayer.plValue = plValue;
            }
            else if (currPlayer.plValue > plValue) {
                return;
            }
        })
        let result = [];
        this.invitedPlayers.forEach(player => result.push(player.name));
        return `You successfully invite ${result.join(", ")}.`;
    }
    signContract(selectedPlayer) {
        let [name, playerOffer] = selectedPlayer.split("/");
        let currPlayer = this.invitedPlayers.find(pl => pl.name === name);
        if (!currPlayer) {
            throw new Error(`${name} is not invited to the selection list!`)
        }
        if (currPlayer.plValue > playerOffer) {
            let priceDifference = Number(currPlayer.plValue) - Number(playerOffer);
            throw new Error(`The manager's offer is not enough to sign a contract with ${name}, ${priceDifference} million more are needed to sign the contract!`);
        }        
        currPlayer.plValue = "Bought";
        return `Congratulations! You sign a contract with ${name} for ${playerOffer} million dollars.`;
    }
    ageLimit(name, age){
        age = Number(age);
        let currPlayer = this.invitedPlayers.find(pl => pl.name === name);
        if (!currPlayer) {
            throw new Error(`${name} is not invited to the selection list!`);
        }
        if(currPlayer.age < age){
            let ageDifference = age - Number(currPlayer.age);
            if(ageDifference < 5){
                return `${name} will sign a contract for ${ageDifference} years with ${this.clubName} in ${this.country}!`;
            }
            else if (ageDifference > 5){
                return `${name} will sign a full 5 years contract for ${this.clubName} in ${this.country}!`;
            }
        }
        else if (currPlayer.age >= age){
            return `${name} is above age limit!`;
        }
    }
    transferWindowResult(){
        let result = ["Players list:"];
        this.invitedPlayers.sort((a, b) => a.name.localeCompare(b.name))
            .map((pl) => {result.push(`Player ${pl.name}-${pl.plValue}`)});
        return result.join("\n");
    }
}

// // Input 1
// let f0Team = new footballTeam("Barcelona", "Spain");
// console.log(f0Team.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
// // Output 1
// // You successfully invite Kylian Mbappé, Lionel Messi, Pau Torres.

// // Input 2
// let fTeam = new footballTeam("Barcelona", "Spain");
// console.log(fTeam.newAdditions(["Kylian Mbappé/23/160", "Lionel Messi/35/50", "Pau Torres/25/52"]));
// console.log(fTeam.signContract("Lionel Messi/60"));
// console.log(fTeam.signContract("Kylian Mbappé/240"));
// console.log(fTeam.signContract("Barbukov/10"));
// // Output 2
// // You successfully invite Kylian Mbappé, Lionel Messi, Pau Torres.
// // Congratulations! You sign a contract with Lionel Messi for 60 million dollars.
// // Congratulations! You sign a contract with Kylian Mbappé for 240 million dollars. 
// // Uncaught Error: Barbukov is not invited to the selection list!

// // Input 3
let fTeam = new footballTeam("Barcelona", "Spain");
console.log(fTeam.newAdditions(["Kylian Mbappé/23/160","Kylian Mbappé/23/60", "Lionel Messi/35/50", "Pau Torres/25/52"]));
console.log(fTeam.ageLimit("Lionel Messi", 33 ));
console.log(fTeam.ageLimit("Kylian Mbappé", 30));
console.log(fTeam.ageLimit("Pau Torres", 26));
console.log(fTeam.signContract("Kylian Mbappé/40"));
// // Output 3
// // You successfully invite Kylian Mbappé, Lionel Messi, Pau Torres.
// // Lionel Messi is above age limit!
// // Kylian Mbappé will sign a full 5 years contract for Barcelona in Spain!
// // Pau Torres will sign a contract for 1 years with Barcelona in Spain!
// // Congratulations! You sign a contract with Kylian Mbappé for 240 million dollars.

// // Input 4
// let fTeam = new footballTeam("Barcelona", "Spain");
// console.log(fTeam.newAdditions(["Kylian Mbappé/23/160","Kylian Mbappé/23/60", "Lionel Messi/35/50", "Pau Torres/25/52"]));
// console.log(fTeam.signContract("Kylian Mbappé/240"));
// console.log(fTeam.ageLimit("Kylian Mbappé", 30));
// console.log(fTeam.transferWindowResult());
// // Output 4
// // You successfully invite Kylian Mbappé, Lionel Messi, Pau Torres.
// // Congratulations! You sign a contract with Kylian Mbappé for 240 million dollars. 
// // Kylian Mbappé will sign a full 5 years contract for Barcelona in Spain!
// // Players list:
// // Player Kylian Mbappé-Bought
// // Player Lionel Messi-50
// // Player Pau Torres-52
