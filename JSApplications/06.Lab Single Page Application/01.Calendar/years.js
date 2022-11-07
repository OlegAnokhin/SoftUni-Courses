
export async function showYearsView(){
    [...document.querySelectorAll('section')].forEach(s=>s.style.display = 'none');
    document.getElementById('years').style.display = 'block';
}

function showselectedYear(e){
    let yearsEl = document.querySelectorAll('.days');
    yearsEl.addEve
    e.target
}