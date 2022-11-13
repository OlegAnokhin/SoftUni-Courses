//let section = document.getElementById("home-page");
export async function showHomeView() {
    [...document.querySelectorAll('section')].forEach(s => s.style.display = 'none');
    document.getElementById("home-page").style.display = 'block';
}
// export function showHome(context) {
//     context.showSection(section);
// }