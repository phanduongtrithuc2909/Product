$(document).ready(function () {
    $('body').on('click', '.btnAddtocard', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quantity = 1;
        var tQuantity = $('#quantity_value').text();
        if (tQuantity != '') {
            quantity = parseInt(tQuantity);
        }

        alert(id + "  " + quantity);

        $.ajax({
            URL: '/shoppingcart/addtocart',
            TYPE: 'Post',
            DATA: { id: id, quantity: quantity },
            SUCCESS: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.Count);
                    alert(rs.msg);
                }
            }
        });

    });
});