function solve() {
  let input = document.getElementById("text").value;
  let convention = document.getElementById("naming-convention").value;
  let textArr = input.split(" ");
  let result = "";
  switch (convention){
    case "Pascal Case":
      textArr.forEach((e,i) => {        
          e = e.toLowerCase();        
        result += e[0].toUpperCase() + e.substring(1);
      });
      break;
    case "Camel Case":
      textArr.forEach((e,i) => {
        if (i === 0){
          return result +=e.toLowerCase();
        }
        return result += e[0].toUpperCase() + e.substring(1).toLowerCase()
      });
      break;
      default : result = "Error!"
  }
  document.getElementById("result").textContent = result;
}