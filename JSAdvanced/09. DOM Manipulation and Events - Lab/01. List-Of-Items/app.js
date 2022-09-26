function addItem() {
    let input = document.getElementById('newItemText').value
    let liItem = document.createElement('li');
    liItem.appendChild(document.createTextNode(input));
    document.getElementById('items').appendChild(liItem);
    document.getElementById('newItemText').value = '';
}