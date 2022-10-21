class LibraryCollection {
    constructor(capacity) {
        this.capacity = capacity;
        this.books = [];
    }
    addBook (bookName, bookAuthor){
        if(this.books.length + 1 > this.capacity){
            throw new Error("Not enough space in the collection.");
        }
        this.books.push({bookName, bookAuthor, payed: false});
        return `The ${bookName}, with an author ${bookAuthor}, collect.`
    }
    payBook( bookName ) {
        let findbook = this.books.find(n => n.bookName === bookName);
        if (!findbook) {
            throw new Error(`${bookName} is not in the collection.`);
        }
        if (findbook.payed) {
            throw new Error(`${bookName} has already been paid.`);
        }
        findbook.payed = true;
        return `${bookName} has been successfully paid.`
    }
    removeBook(bookName) {
        let findbook = this.books.find(n => n.bookName === bookName);
        if (!findbook) {
            throw new Error("The book, you're looking for, is not found.");
        }
        if (!findbook.payed) {
            throw new Error(`${bookName} need to be paid before removing from the collection.`);
        }
        this.books.filter((b) => b.bookName !== bookName);
        return `${bookName} remove from the collection.`
    }
    getStatistics(bookAuthor) {
        let result = [];
        if(bookAuthor == undefined){
            result = [`The book collection has ${ this.capacity - this.books.length } empty spots left.`];
            this.books.sort((a, b) => a.bookName.localeCompare(b.bookName))
            .map((b) => {result.push(`${b.bookName} == ${b.bookAuthor} - ${b.payed ? 'Has Paid' : 'Not Paid'}.`)});
        return result.join("\n");
        }
        let findAuthor = this.books.find(n => n.bookAuthor === bookAuthor);
        if(!findAuthor){
            throw new Error(`${bookAuthor} is not in the collection.`)
        }
        this.books.filter((b) => b.bookAuthor === bookAuthor)
        .map((b) => {result.push(`${b.bookName} == ${b.bookAuthor} - ${b.payed ? 'Has Paid' : 'Not Paid'}.`)});
        return result.join("\n");
    }
}

// const library = new LibraryCollection(2)
// console.log(library.addBook('In Search of Lost Time', 'Marcel Proust'));
// console.log(library.addBook('Don Quixote', 'Miguel de Cervantes'));
// console.log(library.addBook('Ulysses', 'James Joyce'));
// Output 1
// The In Search of Lost Time, with an author Marcel Proust, collect.
// The Don Quixote, with an author Miguel de Cervantes, collect.
// Not enough space in the collection.

// const library = new LibraryCollection(2)
// library.addBook('In Search of Lost Time', 'Marcel Proust');
// console.log(library.payBook('In Search of Lost Time'));
// console.log(library.payBook('Don Quixote'));
// Output 2
// In Search of Lost Time has been successfully paid.
// Don Quixote is not in the collection.

// Input 3
// const library = new LibraryCollection(2)
// library.addBook('In Search of Lost Time', 'Marcel Proust');
// library.addBook('Don Quixote', 'Miguel de Cervantes');
// library.payBook('Don Quixote');
// console.log(library.removeBook('Don Quixote'));
// console.log(library.removeBook('In Search of Lost Time'));
// Output 3
// Don Quixote remove from the collection.
// In Search of Lost Time need to be paid before removing from the collection.

// const library = new LibraryCollection(2)
// console.log(library.addBook('Don Quixote', 'Miguel de Cervantes'));
// console.log(library.getStatistics('Miguel de Cervantes'));

// Output 4
// The Don Quixote, with an author Miguel de Cervantes, collect.
// Don Quixote == Miguel de Cervantes - Not Paid.

// Input 5
// const library = new LibraryCollection(5)
// library.addBook('Don Quixote', 'Miguel de Cervantes');
// library.payBook('Don Quixote');
// library.addBook('In Search of Lost Time', 'Marcel Proust');
// library.addBook('Ulysses', 'James Joyce');
// console.log(library.getStatistics());

// Output 5
// The book collection has 2 empty spots left.
// Don Quixote == Miguel de Cervantes - Has Paid.
// In Search of Lost Time == Marcel Proust - Not Paid.
// Ulysses == James Joyce - Not Paid.
