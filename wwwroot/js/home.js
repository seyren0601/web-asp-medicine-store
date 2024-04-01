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
                    ),
                    success: function (data) {
                        $.ajax({
                            type: 'GET',
                            url: 'https://localhost:7191/cart_amount/' + userID,
                            success: function (data) {
                                console.log(data);
                                cart_amount.text(data);
                                $.toast({
                                    heading: 'THÊM THÀNH CÔNG VÀO GIỎ HÀNG',
                                    text: 'Thêm thành công ' + MedID + ' vào giỏ hàng<br>Số lượng hiện tại: ' + data,
                                    icon: 'success',
                                    showHideTransition: 'fade',
                                    position:'top-right'
                                });
                            }
                        });
                    },
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

function UpdateCart(userID, cart_amount) {
    
}