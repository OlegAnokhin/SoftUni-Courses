function deleteByEmail() {
    let input = document.querySelector('input[name="email"]');
    let emails = Array.from(document.querySelectorAll('tr td'));
    let result = document.getElementById('result');
    let currElement = emails.find(el=>el.textContent == input.value);
    if(currElement){
        currElement.parentNode.remove();
        result.textContent = 'Deleted';
    }else{
        result.textContent = 'Not found.'
    }
    input.value = '';
}