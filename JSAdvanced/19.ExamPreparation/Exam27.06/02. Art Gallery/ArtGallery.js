class ArtGallery {
    constructor(creator) {
        this.creator = creator;
        this.possibleArticles = { "picture": 200, "photo": 50, "item": 250 };
        this.listOfArticles = [];
        this.guests = [];
    }
    addArticle(articleModel, articleName, quantity) {
        let currArticle = articleModel.toLowerCase();
        currArticle = this.possibleArticles[currArticle];
        articleModel = articleModel.toLowerCase()
        let findExistName = this.listOfArticles.find(n => n.articleName === articleName);

        if (currArticle == undefined) {
            throw new Error("This article model is not included in this gallery!");
        }
        if (findExistName) {
            if (findExistName.articleModel == articleModel) {
                findExistName.quantity += quantity
                return;
            }
        }
        this.listOfArticles.push({ articleModel, articleName, quantity });
        return `Successfully added article ${articleName} with a new quantity- ${quantity}.`
    }
    inviteGuest(guestName, personality) {
        let findGuestName = this.guests.find(n => n.guestName === guestName);
        let points = 50;
        if (findGuestName) {
            throw new Error(`${guestName} has already been invited.`);
        }
        if (personality == "Vip") {
            points = 500;
        } else if (personality == "Middle") {
            points = 250;
        }
        this.guests.push({ guestName, points, purchaseArticle: 0 });
        return `You have successfully invited ${guestName}!`;
    }
    buyArticle(articleModel, articleName, guestName) {
        let findExistName = this.listOfArticles.find(n => n.articleName === articleName);
        let currGuest = this.guests.find(n =>n.guestName === guestName);
        let currArticle = this.possibleArticles[articleModel];
        if (findExistName == undefined) {
            throw new Error('This article is not found.');
        }
        if (findExistName) {
            if (findExistName.articleModel != articleModel) {
                throw new Error('This article is not found.');
            }
        }
        if(findExistName.quantity <= 0){
            return `The ${articleName} is not available.`;
        }
        if(currGuest == undefined){
            return `This guest is not invited.`;
        }        
        if(currGuest.points < currArticle){
            return `You need to more points to purchase the article.`;
        }
        currGuest.points -= currArticle;
        findExistName.quantity--;
        currGuest.purchaseArticle++;
        return `${guestName} successfully purchased the article worth ${currArticle} points.`;
    }
    showGalleryInfo (criteria){
        if(criteria == "article"){
            let result = [`Articles information:`];
            this.listOfArticles.map(p => result.push(`${p.articleModel} - ${p.articleName} - ${p.quantity}`));        
            return result.join("\n");
        }else{
            let result = [`Guests information:`];
            this.guests.map(p => result.push(`${p.guestName} - ${p.purchaseArticle}`));        
            return result.join("\n");
        }
    }
}

// const artGallery = new ArtGallery('Curtis Mayfield');
// console.log(artGallery.addArticle('picture', 'Mona Liza', 3));   // Successfully added article Mona Liza with a new quantity- 3.
// console.log(artGallery.addArticle('Item', 'Ancient vase', 2));   // Successfully added article Ancient vase with a new quantity- 2.
// console.log(artGallery.addArticle('PICTURE', 'Mona Liza', 1));   // Successfully added article Mona Liza with a new quantity- 1.

// const artGallery = new ArtGallery('Curtis Mayfield');
// console.log(artGallery.inviteGuest('John', 'Vip')); // You have successfully invited John!
// console.log(artGallery.inviteGuest('Peter', 'Middle')); // You have successfully invited Peter!
// console.log(artGallery.inviteGuest('John', 'Middle')); // John has already been invited.

// const artGallery = new ArtGallery('Curtis Mayfield');
// artGallery.addArticle('picture', 'Mona Liza', 3);
// artGallery.addArticle('Item', 'Ancient vase', 2);
// artGallery.addArticle('picture', 'Mona Liza', 1);
// artGallery.inviteGuest('John', 'Vip');
// artGallery.inviteGuest('Peter', 'Middle');
// console.log(artGallery.buyArticle('picture', 'Mona Liza', 'John')); // John successfully purchased the article worth 200 points.
// console.log(artGallery.buyArticle('item', 'Ancient vase', 'Peter')); // Peter successfully purchased the article worth 250 points.
// console.log(artGallery.buyArticle('item', 'Mona Liza', 'John'));// This article is not found.

const artGallery = new ArtGallery('Curtis Mayfield'); 
artGallery.addArticle('picture', 'Mona Liza', 3);
artGallery.addArticle('Item', 'Ancient vase', 2);
artGallery.addArticle('picture', 'Mona Liza', 1);
artGallery.inviteGuest('John', 'Vip');
artGallery.inviteGuest('Peter', 'Middle');
artGallery.buyArticle('picture', 'Mona Liza', 'John');
artGallery.buyArticle('item', 'Ancient vase', 'Peter');
console.log(artGallery.showGalleryInfo('article'));
// Articles information:
//  picture - Mona Liza - 3
//  item - Ancient vase - 1
console.log(artGallery.showGalleryInfo('guest'));
//  Guests information:
//  John - 1
//  Peter - 1
