function printDeckOfCards(cards) {

    let result =[];
    for(let currCard of cards){
        let face = currCard.slice(0,-1);
        let suit = currCard.slice(-1);
        try {
            card = createCard(face, suit);
            result.push(card);
        } catch (error) {
            result = ['Invalid card: ' + currCard];
        }
    }
    console.log(result.join(' '));
    function createCard(face, suit) {
        let faces = ['2', '3', '4', '5', '6', '7', '8', '9', '10', 'J', 'Q', 'K', 'A'];
        let suits = ['S', 'H', 'D', 'C'];
        if (faces.indexOf(face.toString()) === -1) {
            throw new Error('Invalid card: ' + face);
        }
        if (suits.indexOf(suit.toString()) === -1) {
            throw new Error('Invalid card: ' + suit);
        }
        switch (suit) {
            case 'S': suit = '\u2660'; break;
            case 'H': suit = '\u2665'; break;
            case 'D': suit = '\u2666'; break;
            case 'C': suit = '\u2663'; break;
        }
        return {
            face: face,
            suit: suit,
            toString() {
                return this.face + this.suit
            }
        }
    }
}
// printDeckOfCards(['AS', '10D', 'KH', '2C']);
// printDeckOfCards(['5S', '3D', 'QD', '1C']);
printDeckOfCards(['5X', '3D', 'QD', '1X']);