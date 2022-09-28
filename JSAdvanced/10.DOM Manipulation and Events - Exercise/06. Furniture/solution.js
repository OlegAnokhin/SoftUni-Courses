function solve() {
  let buttons = document.querySelectorAll("button");
  buttons[0].addEventListener("click", generate);
  buttons[1].addEventListener("click", buy);

  function generate() {
    let currItems = JSON.parse(document.querySelectorAll("textarea")[0].value);
    let tableBody = document.getElementsByTagName("tbody")[0];
    for (let item of currItems) {
      let tableRow = document.createElement("tr");
      tableRow.innerHTML = `<td><img src="${item.img}"</td>`+
                            `<td><p>${item.name}</p></td>`+
                            `<td><p>${item.price}</p></td>`+
                            `<td><p>${item.decFactory}</p></td>`+
                            `<td><input type="checkbox"></td>`;
      tableBody.appendChild(tableRow)
    }
  }
  function buy() {
    let resultArea = document.querySelectorAll("textarea")[1];
    let table = Array.from(document.querySelectorAll("tbody tr"));
    let result = [];
    for (let el of table) {
      if (el.querySelector("input[type=checkbox] : checked")) {
        let tableData = Array.from(el.querySelectorAll("td"));
        let info = {
          name: tableData[1].children[0].textContent,
          price: tableData[2].children[0].textContent,
          decorationFactor: tableData[3].children[0].textContent
        }
        result.push(info)
      }
    }
    let names = "";
    let totalPrice = 0;
    let avrDecor = 0;
    for(let i = 0; i < result.length; i ++){
      let item = result[i];
      let separ = i == result.length -1 ? "" : ", ";
      names += item.name + separ,
      totalPrice += Number(item.price),
      avrDecor += Number(item.decorationFactor)
    }
    avrDecor /= result.length;
    resultArea = `Bought furniture: ${names}\nTotal price: ${totalPrice.toFixed(2)}\n"Average decoration factor: ${avrDecor.toFixed(2)}`;
  }
}
