function search() {
   let townsList = Array.from(document.querySelectorAll("ul li"));
   let searchText = document.getElementById("searchText").value;
   let count = 0;
   for (let item of townsList) {
      let text = item.textContent;
      if(text.includes(searchText)){
         item.style.textDecoration = "underline";
         item.style.fontWeight = "bold";
         count++;
      } else{
         item.style.textDecoration = "none";
         item.style.fontWeight = "normal";
      }
   }
   document.getElementById("result").innerText = `${count} matches found`;
}