function OnClick_Minus(button) {
    var element_main = $(button).closest('.main');
    var id = element_main.find('.id').text();
    var current_amount = parseInt(element_main.find('.amount').text());
    var userid = $('#userid').text();
    var cart_amount = parseInt($('#cart_amount').text());
    if (current_amount == 1) {
        var confirmed = window.confirm("Bạn có muốn xóa sản phẩm này không?")
        if (confirmed) {
            $.ajax({
                type: "DELETE",
                url: "https://localhost:7191/cart/delete?user_id=" + userid + "&thuoc_id=" + id,
                contentType: "application/json",
                dataType: 'json',
                success: function (data) {
                    var thuoc_deleted = data;
                    element_main.remove();
                    var dongia = thuoc_deleted.don_gia;
                    var tong_summary = parseInt($('#tong_summary').text());
                    $('#tong_summary').text((tong_summary - dongia) + " ₫");
                    var tong_tien = parseInt($('#tong_tien').text());
                    $('#tong_tien').text((tong_tien - dongia) + " ₫");
                    $('#cart_amount').text(cart_amount - 1);
                }
            })
        }
    }
    else{
        $.ajax({
            type: 'POST',
            url: 'https://localhost:7191/add_cart',
            data: JSON.stringify({
                user_id: userid,
                thuoc_id: id,
                amount: -1
            }),
            contentType: "application/json",
            dataType: 'json',
            success: function (medicine_amount) {
                element_main.find('.amount').text(medicine_amount);
                var tong_thuoc = element_main.find('.tong_thuoc');
                var old_sum = parseInt(tong_thuoc.text());
                var price = old_sum / current_amount;
                tong_thuoc.text((old_sum - price) + " ₫");
                var tong_summary = parseInt($('#tong_summary').text());
                $('#tong_summary').text((tong_summary - price) + " ₫");
                var tong_tien = parseInt($('#tong_tien').text());
                $('#tong_tien').text((tong_tien - price) + " ₫");
            }
        });
    }
}

function OnClick_Plus(button) {
    var element_main = $(button).closest('.main');
    var id = element_main.find('.id').text();
    var current_amount = parseInt(element_main.find('.amount').text());
    var userid = $('#userid').text();
    $.ajax({
        type: "GET",
        url: `https://localhost:7191/get_stock/${id}`,
        success: function (data) {
            var current_stock = parseInt(data);
            if (current_stock < current_amount + 1) {
                $.toast({
                    heading: 'LỖI THÊM SỐ LƯỢNG',
                    text: 'Số lượng tồn không đủ để đáp ứng yêu cầu',
                    icon: 'error',
                    showHideTransition: 'fade',
                    position: 'top-right'
                })
            }
            else {
                $.ajax({
                    type: 'POST',
                    url: 'https://localhost:7191/add_cart',
                    data: JSON.stringify({
                        user_id: userid,
                        thuoc_id: id,
                        amount: 1
                    }),
                    contentType: "application/json",
                    dataType: 'json',
                    success: function (medicine_amount) {
                        element_main.find('.amount').text(medicine_amount);
                        var tong_thuoc = element_main.find('.tong_thuoc');
                        var old_sum = parseInt(tong_thuoc.text());
                        var price = old_sum / current_amount;
                        tong_thuoc.text((old_sum + price) + " ₫");
                        var tong_summary = parseInt($('#tong_summary').text());
                        $('#tong_summary').text((tong_summary + price) + " ₫");
                        var tong_tien = parseInt($('#tong_tien').text());
                        $('#tong_tien').text((tong_tien + price) + " ₫");
                    }
                });
            }
        }
    })
}