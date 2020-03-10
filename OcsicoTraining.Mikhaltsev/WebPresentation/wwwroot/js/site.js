// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function changeCountOfItem($container, changeCountFn) {
   var $quantity = $container.find('.quantity-value');
   var $weight = $container.find('.weight');
   var $price = $container.find('.price');
   var $total = $container.find('.total-price');

   var quantity = +$quantity.val();
   var weight = +$weight.val();
   var price = +$price.val();

   quantity = changeCountFn(quantity);

   var total = quantity * weight * price / 1000;

   $quantity.val(quantity);
   $total.text(total);
   $total.val(total);
}

function decrementItem(quantity) {
   if (quantity > 2) {
      quantity = quantity - 1;
   } else {
      quantity = 1;
   }
   return quantity;
}

function incrementItem(quantity) {
   if (quantity < 5) {
      quantity = quantity + 1;
   } else {
      quantity = 5;
   }
   return quantity;
}

function calculatePrice() {
   var finalPrice = 0;

   $("div.total-price").each(function () {
      finalPrice += parseFloat($(this).html());
   });

   $('.final-price').text(finalPrice);
}

$(document).ready(function () {
   calculatePrice();

   $('.minus-btn').on('click', function () {
      changeCountOfItem($(this).closest('.basket-item'), decrementItem);
      calculatePrice();
   });

   $('.plus-btn').on('click', function () {
      changeCountOfItem($(this).closest('.basket-item'), incrementItem);
      calculatePrice();
   });
});
