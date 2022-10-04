function notify(message) {
  let getDiv = document.getElementById("notification");
  getDiv.innerText = message;
  getDiv.style.display = "block";
  getDiv.addEventListener("click", toggleDisplStyle)

  function toggleDisplStyle(e) {
    e.target.style.display = "none"
  }
}