function editElement(ref, match, replacer) {    
    let text = ref.textContent;
    let matcher = new RegExp(match, 'g');
    let editText = text.replace(matcher, replacer);
    ref.textContent = editText;
}