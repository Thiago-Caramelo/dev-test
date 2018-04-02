(function($, window, document) {

    function addBurger(burgerType) {
        
        var burger = {
            burgerType : burgerType,
            burgerIngredients : []
        }

        if (burgerType === "XCustom") {
            $('input[data-ingredient-type]').each(function() {
                var ingredientType = $(this).attr("data-ingredient-type");
                var qty = $(this).val();
                var qtyNumber = parseInt(qty);
                if (qtyNumber)
                {
                    burger.burgerIngredients.push({ingredientType : ingredientType, ingredientQty : qty, ingredientDescription : ''});
                }
            });
        }

        $.ajax({
            type : "POST",
            url : "Order/Burger",
            data : JSON.stringify(burger),
            contentType : "application/json"
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