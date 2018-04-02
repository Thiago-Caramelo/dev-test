(function($, window, document) {

    function addMenuBurger(burgerType) {

    }

    function addBurger(burgerType) {
        debugger;
        var burger = {
            BurgerType : burgerType
        }

        if (burgerType === "XCustom") {
            burger.BurgerIngredients = [];

            $('input[data-ingredient-type]').each(function() {
                var ingredientType = $(this).attr("data-ingredient-type");
                var qty = $(this).val();
                burger.BurgerIngredients.push({IngredientType : ingredientType, IngredientQty : qty});
            });
        }

        $.ajax({
            type : "POST",
            url : "Order/Burger",
            data : JSON.stringify(burger),
            contentType : "application/json: charset=utf-8"
        })
        .done(function(response) {
            $("#cartPlaceHolder").html(response);
        })
        .fail(function(error) {
            alert('Ocorreu um erro inesperado. Tente novamente.');
            console.log(error);
        });
    }

    $( "button[data-buy-click]" ).click(function() {
        addBurger($(this).attr("data-buy-click"));
    });
}(window.jQuery, window, document));