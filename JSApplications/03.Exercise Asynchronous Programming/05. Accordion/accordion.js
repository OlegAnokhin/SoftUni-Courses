async function solution() {
    let mainElement = document.getElementById('main');
    let respons = await fetch('http://localhost:3030/jsonstore/advanced/articles/list');
    let data = Object.values(await respons.json());

    data.forEach((article, i) => {
        let articleElement = document.createElement('div');
        articleElement.className = 'accordion';
        articleElement.innerHTML = `
                <div class="head">
                    <span>${article.title}</span>
                    <button class="button" id=${article._id}>More</button>
                </div>
                <div class="extra">`;
        let moreBtn = articleElement.querySelector('button');
        moreBtn.addEventListener('click', showMore);
        mainElement.appendChild(articleElement);
    });
}
async function showMore(e) {
    let currArticle = e.target.parentElement.parentElement;
    let id = e.target.id;
    let moreInfo = currArticle.querySelector('div.extra');

    let respons = await fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${id}`);
    let data = Object.values(await respons.json());
    moreInfo.innerHTML = `<p>${data[2]}</p>`;

    if (e.target.textContent == 'More') {
        e.target.textContent = 'Less';
        moreInfo.style.display = 'block';
    } else {
        e.target.textContent = 'More';
        moreInfo.style.display = 'none';
    }
}
solution();