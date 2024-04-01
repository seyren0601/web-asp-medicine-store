$(document).ready(function () {
    $('.btn').on("click", OnClick_Them);
})

function OnClick_Them() {
    var cart_amount = $('#cart_amount');
    var current_cart_amount = cart_amount.text();
    var MedID = $(this).closest('.card').find('.MedID').text();
    var userID = $("#UserID").text();

    if (cart_amount != null) { // Already logged in
        var current_count = parseInt(cart_amount.innerHTML);
        $.get("https://localhost:7191/get_stock/" + MedID, function (data, status){
            var current_stock = parseInt(data);
            if(current_stock >= 1) {
                $.ajax({
                    type: 'POST',
                    url: 'https://localhost:7191/add_cart',
                    data: JSON.stringify(
                        {
                            user_id: userID,
                            thuoc_id: MedID,
                            amount:1
                        }
                    ), // or JSON.stringify ({name: 'jonas'}),
                    success: function (data) { cart_amount.text(parseInt(current_cart_amount) + 1) },
                    contentType: "application/json",
                    dataType: 'json'
                });
            }
        });
    }
    else {
        window.location.href = "/Identity/Account/Login";
    }
}