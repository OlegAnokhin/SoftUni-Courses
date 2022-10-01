function constrCrew(input) {
    let worker = input;
    if (worker.dizziness) {
        let needWater = worker.weight * worker.experience * 0.1;
        worker.levelOfHydrated += needWater;
        worker.dizziness = false;
    }
    return worker;
}
console.log(constrCrew(
    {
        weight: 80,
        experience: 1,
        levelOfHydrated: 0,
        dizziness: true
    }));
console.log(constrCrew(
    {
        weight: 120,
        experience: 20,        
        levelOfHydrated: 200,        
        dizziness: true
    }));
console.log(constrCrew(
    {
        weight: 95,
        experience: 3,        
        levelOfHydrated: 0,        
        dizziness: false
    }));