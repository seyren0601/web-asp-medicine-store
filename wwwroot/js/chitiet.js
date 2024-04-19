function OnClick_Minus(button) {
    var amount_element = $('#amount');
    var amount = parseInt(amount_element.text());
    if (amount == 1) {
        $.toast({
            heading: 'LỖI SỐ LƯỢNG',
            text: 'Số lượng phải lớn hơn 0',
            icon: 'warning',
            showHideTransition: 'fade',
            position: 'top-right'
        });
    }
    else {
        amount -= 1
        amount_element.text(amount);
    }   
}

function OnClick_Plus(button) {
    var amount_element = $('#amount');
    var amount = parseInt(amount_element.text());
    amount += 1
    amount_element.text(amount);
}

function OnClick_Them() {
    var cart_elem = $('#cart_amount');
    var MedID = $('#thuoc_id').text();
    var MedName = $('#thuoc_name').text();
    var userID = $("#UserID").text();
    var amount_element = $('#amount');
    var amount = parseInt(amount_element.text());

    if (cart_elem != null) { // Already logged in
        $.get("https://localhost:7191/cart_amount/" + userID + "/" + MedID, function (data, status) {
            var cart_amount = data;
            $.get("https://localhost:7191/get_stock/" + MedID, function (data, status) {
                var current_stock = parseInt(data);
                if (current_stock >= cart_amount + amount) {
                    $.ajax({
                        type: 'POST',
                        url: 'https://localhost:7191/add_cart',
                        data: JSON.stringify(
                            {
                                user_id: userID,
                                thuoc_id: MedID,
                                amount: amount
                            }
                        ),
                        success: function (data1) {
                            $.ajax({
                                type: 'GET',
                                url: 'https://localhost:7191/cart_amount/' + userID,
                                success: function (data2) {
                                    cart_elem.text(data2);
                                    $.toast({
                                        heading: 'THÊM THÀNH CÔNG VÀO GIỎ HÀNG',
                                        text: 'Thêm thành công ' + MedName + ' vào giỏ hàng<br>Số lượng hiện tại: ' + data1,
                                        icon: 'success',
                                        showHideTransition: 'fade',
                                        position: 'top-right'
                                    });
                                }
                            });
                        },
                        contentType: "application/json",
                        dataType: 'json'
                    });
                }
                else {
                    $.toast({
                        heading: 'THÊM THẤT BẠI',
                        text: 'Số lượng tồn kho không đủ',
                        icon: 'warning',
                        showHideTransition: 'fade',
                        position: 'top-right'
                    });
                }
            });
        });
    }
    else {
        window.location.href = "/Identity/Account/Login";
    }
}