function success($element) {
   var $menu = $element.closest('.menu-item');
   var $quantity = $menu.find('#Quantity');
   var $weight = $menu.find('#Weight');

   $quantity.val(0);
   $weight.val(0);

   alert("Товар добавлен");
}
