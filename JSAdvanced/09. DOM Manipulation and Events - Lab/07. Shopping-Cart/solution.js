function solve() {
   let shoppingcart = document.getElementsByClassName('shopping-cart')[0];
   let result = document.getElementsByTagName('textarea')[0];
   let products = [];
   let totalPrice = 0;
   let checkoutDone = false;
   shoppingcart.addEventListener('click', function (event) {
      if (event.target.nodeName !== 'BUTTON') {
         return
      }
      if (checkoutDone) {
         return
      }
      let btn = event.target;
      if (Array.from(btn.classList).indexOf('add-product') >= 0) {
         let productEl = event.target.parentElement.parentElement;
         let name = productEl.querySelectorAll('.product-title')[0].textContent;
         let price = productEl.querySelectorAll('.product-line-price')[0].textContent;
         result.textContent += `Added ${name} for ${price} to the cart.\n`;
         if (products.indexOf(name) < 0) {
            products.push(name);            
         } 
         totalPrice += Number(price);
      }else if (Array.from(btn.classList).indexOf('checkout') >= 0) {
         let list = products.join(', ');
         result.textContent += `You bought ${list} for ${totalPrice.toFixed(2)}.`;
         checkoutDone = true;
      }
   });
}