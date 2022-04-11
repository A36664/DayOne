var CartController = function () {
    this.initialize = function () {
        registerEvents();
    }

   
    function registerEvents() {
        $('body').on('click', '.updatecartitem', function (e) {
            e.preventDefault();
            var bookid = $(this).attr("data-bookId");
            var quantity = $("#quantity-" + bookid).val();
            updateCart(bookid, quantity);
        });

        //$(".updatecartitem").click(function (event) {
        //    event.preventDefault();
        //    var bookid = $(this).attr("data-productid");
        //    var quantity = $("#quantity-" + productid).val();
        //    updateCart(bookid, quantity);
          
        //});

      
    }

    function updateCart(id, quantity) {
        $.ajax({
            type: "POST",
            url: '/Cart/UpdateCart',
            data: {
                bookId: id,
                quantity: quantity
            },
            success: function (res) {
                //$('#lbl_number_items_header').text(res.length);
                //loadData();
            },
            error: function (err) {
                console.log(err);
            }
        });
    }

   
   
}