function solve(){
    let fighter = (name) => {
        let state = {
            name,
            health: 100,
            stamina: 100
        }
        return Object.assign(state, canFight(state));
    }
    let mage = (name) => {
        let state = {
            name,
            health: 100,
            mana: 100
        }
        return Object.assign(state, canCast(state));
    }
    let canFight = (state) => ({
        fight: () => {
            state.stamina--;
            console.log(`${state.name} slashes at the foe!`);
        }
    })
    let canCast = (state) => ({
        cast: (spell) => {
            state.mana--;
            console.log(`${state.name} cast ${spell}`);
        }
    })
    return {mage: mage, fighter: fighter};
}
let create = solve();
const scorcher = create.mage("Scorcher");
scorcher.cast("fireball")
scorcher.cast("thunder")
scorcher.cast("light")
const scorcher2 = create.fighter("Scorcher 2");
scorcher2.fight()
console.log(scorcher2.stamina);
console.log(scorcher.mana);