function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);
   let result = [];
   function onClick () {
      let input = JSON.parse(document.getElementById("inputs").children[1].value);
      let bestRestPar = document.getElementById("bestRestaurant").children[2];
      let bestResWork = document.getElementById("workers").children[2];
      for (let data of input) {
         let[name, workerList] = data.split(" - ");
         if(!result.find(e=> e.name === name)){
            result.push({
               name,
               avgSalary : 0,
               bestSalary : 0,
               sumSalary : 0,
               workerList :[]
            });
            let currRest = result.find(e=>e.name === name);
            workerList = workerList && workerList.split(", ");
            for (let currWorker of workerList) {
               updeteRest(currRest, currWorker)
            }

         }
      }
      let bestRest = result.sort((a,b) => b.avgSalary - a.avgSalary)[0];
      bestRestPar.textContent = `Name: ${bestRest.name} Average Salary: ${bestRest.avgSalary.toFixed(2)} Best Salary: ${bestRest.bestSalary.toFixed(2)}`
      let sortListOfWorker = bestRest.workerList.sort((a,b) => b.salary - a.salary);
      let buff = "";
      for(let worker of sortListOfWorker){
         buff += `Name: ${worker.name} With Salary: ${worker.salary}`
      }
      bestResWork.textContent += buff;
   }
   function updeteRest(obj, worker){
      let [name, salary] = worker.split(" ");
      salary = Number(salary);
      obj.sumSalary += salary;
      if(obj.bestSalary < salary){
         obj.bestSalary = salary;
      }
      obj.workerList.push({
         name,
         salary
      });
      obj.avgSalary = obj.sumSalary / obj.workerList.length;
   }
}