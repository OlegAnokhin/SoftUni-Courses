function addItem() {
    let input = document.getElementById('newItemText').value   
    let list = document.getElementById('items');
    if(input.length <= 0){
        return;
    } 
    let liItem = document.createElement('li');
    liItem.textContent = input;
    document.getElementById('newItemText').value = '';
    let removeBtn = document.createElement('a');
    let btnText = document.createTextNode('[Delete]');
    removeBtn.appendChild(btnText);
    removeBtn.href = '#';
    removeBtn.addEventListener('click', deleteItem)
    liItem.appendChild(removeBtn);
    list.appendChild(liItem);
  
    function deleteItem(){
        liItem.remove();
    }
}