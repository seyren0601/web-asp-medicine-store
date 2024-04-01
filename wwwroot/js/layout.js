$(document).ready(function () {
    UpdateCart_Load();
})

function UpdateCart_Load() {
    var cart_amount = $('#cart_amount');
    var user_id = $('#UserID').text();
    $.ajax({
        type: 'GET',
        url: 'https://localhost:7191/cart_amount/' + user_id,
        success: function (data) { cart_amount.text(data) }
    });
}