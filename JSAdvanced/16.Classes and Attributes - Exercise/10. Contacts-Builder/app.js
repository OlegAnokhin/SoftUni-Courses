class Contact {
    constructor(firstname, lastname, phone, email) {
        this.firstname = firstname;
        this.lastname = lastname;
        this.phone = phone;
        this.email = email;
        this._online = false;
        this.el = document.createElement('article');
    }
    get online() {
        return this._online;
    }
    set online(value) {
        this._online = value;
        if (this.title) {
            if (value === true) {
                this.title.classList.add('online');
            } else {
                this.title.classList.remove('online');
            }
        }
    }
    getContent() {
        return `<div class="title">${this.firstname} ${this.lastname}<button>&#8505 </button></div>
                <div class="info" style="display: none;">
                    <span>&phone; ${this.phone}</span>
                    <span>&#9993; ${this.email}</span>
                </div>`
    }
    render(id) {
        let parent = document.getElementById(id);
        this.el.innerHTML = this.getContent();
        let title = this.el.querySelector('.title');
        this.title = title;
        if (this.online) {
            this.title.classList.add('online');
        }
        parent.appendChild(this.el);
        let button = this.el.querySelector('button');
        let info = this.el.querySelector('.info');
        button.addEventListener('click', (e) => {
            info.style.display == 'none' ?
                info.style.display = 'block' :
                info.style.display = 'none';
        })
    }
}
let contacts = [
    new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
    new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
    new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
];
contacts.forEach(c => c.render('main'));
setTimeout(() => contacts[0].online = true, 2000);
setTimeout(() => contacts[1].online = true, 2000);
setTimeout(() => contacts[2].online = true, 2000);
setTimeout(() => contacts[0].online = false, 2000);