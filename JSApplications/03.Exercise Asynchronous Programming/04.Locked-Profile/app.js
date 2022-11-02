async function lockedProfile() {
    let mainElement = document.getElementById('main');
    mainElement.innerHTML = '';
    let respons = await fetch('http://localhost:3030/jsonstore/advanced/profiles');
    let data = Object.values(await respons.json());
    data.forEach((user, i) => {
        let profileCard = document.createElement('div');
        profileCard.className = 'profile';
        let idNum = i + 1;
        profileCard.innerHTML = `<img src="./iconProfile2.png" class="userIcon" />
                                 <label>Lock</label>
                                 <input type="radio" name="user${idNum}Locked" value="lock" checked>
                                 <label>Unlock</label>
                                 <input type="radio" name="user${idNum}Locked" value="unlock"><br>
                                 <hr>
                                 <label>Username</label>
                                 <input type="text" name="user${idNum}Username" value="${user.username}" disabled readonly />
                                 <div id="user1HiddenFields" style="display:none">
                                     <hr>
                                     <label>Email:</label>
                                     <input type="email" name="user${idNum}Email" value="${user.email}" disabled readonly />
                                     <label>Age:</label>
                                     <input type="email" name="user${idNum}Age" value="${user.age}" disabled readonly />
                                 </div>
                                 <button>Show more</button>`;
        mainElement.appendChild(profileCard);
    });
    let btnsElements = document.querySelectorAll('div button');
    for(let i = 0; i < btnsElements.length; i++){
        let btn = btnsElements[i];
        let currProfile = btn.parentElement;
        let lockedProfile = currProfile.querySelector('input[value="lock"]');
        let hiddenInfo = currProfile.querySelector(`#user1HiddenFields`);
        btn.addEventListener('click', ()=>{
            if(!lockedProfile.checked && btn.textContent == 'Show more'){
                hiddenInfo.style.display = 'block';
                btn.textContent = 'Hide it';
            }else if(!lockedProfile.checked && btn.textContent == 'Hide it'){
                hiddenInfo.style.display = 'none';
                btn.textContent = 'Show more';
            }
        });
    }
}