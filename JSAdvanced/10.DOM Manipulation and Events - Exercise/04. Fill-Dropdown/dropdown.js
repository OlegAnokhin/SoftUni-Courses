function addItem() {
    let textField = document.getElementById('newItemText');
    let valueField = document.getElementById('newItemValue');
    let currText = textField.value;
    let currValue = valueField.value;
    let newOptionEl = document.createElement('option');
    newOptionEl.textContent = currText;
    newOptionEl.value = currValue;
    let appendEl = document.getElementById('menu');
    appendEl.appendChild(newOptionEl);
    textField.value = '';
    valueField.value = '';
}