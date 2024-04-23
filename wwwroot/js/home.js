var nextPage = 2;
var end_of_pages = false;
var scroll_handled = false;
var userID = $('#UserID').text();

$(window).scroll(function () {
    if ($(window).scrollTop() >= $(document).height() - $(window).height() - 10 && !end_of_pages && !scroll_handled) {
        scroll_handled = true;
        $.ajax({
            url: "/list_thuoc/?page=" + nextPage,
            type: "get",
            success: function (paged_list) {
                nextPage += 1;
                if (paged_list.length > 0) {
                    var cards = $('#cards');
                    $.each(paged_list, function (index, thuoc) {
                        $.ajax({
                            url: "/thuoc/image/" + thuoc['thuoc_id'],
                            type: "get",
                            success: function (imgURL) {
                                var div_col = $('<div>').addClass('col-mb-5');
                                var div_card = $('<div>')
                                    .addClass('card mx-auto mb-4 shadow-sm p-3 rounded')
                                var img = $('<img>')
                                    .attr('src', imgURL)
                                    .addClass('card-img-top')
                                    .attr('alt', 'hinh_thuoc')
                                var div_card_body = $('<div>')
                                    .addClass('card-body p-4')
                                var div_text_center = $('<div>')
                                    .addClass('text-center')
                                var div_ten = $('<div>')
                                    .addClass('MedName')
                                    .addClass('h5')
                                    .text(thuoc['ten'])
                                var gia_string = thuoc['don_gia'].toLocaleString();
                                var div_gia = $('<div>')
                                    .addClass('MedPrice')
                                    .text(gia_string + ' ₫')
                                var div_id = $('<div>')
                                    .addClass('MedID')
                                    .attr('style', 'display:none')
                                    .text(thuoc['thuoc_id'])
                                div_text_center.append(div_ten)
                                    .append(div_gia)
                                    .append(div_id)
                                div_card_body.append(div_text_center)
                                var div_footer = $('<div>')
                                    .addClass('card-footer p4 pt-0 border-top-0 bg-transparent')

                                var div_text_center1 = $('<div>')
                                    .addClass('text-center')
                                var a_them = $('<a>')
                                    .addClass('btn btn-outline-dark mt-auto btn_them')
                                    .text('Thêm vào giỏ hàng')
                                div_text_center1.append(a_them)
                                div_footer.append(div_text_center1)

                                div_text_center2 = $('<div>')
                                    .addClass('text-center')
                                var a_them = $('<a>')
                                    .addClass('btn btn-outline-primary my-3 btn_chitiet')
                                    .text('Chi tiết')
                                div_text_center2.append(a_them)
                                div_footer.append(div_text_center2)

                                div_card.append(img)
                                    .append(div_card_body)
                                    .append(div_footer)
                                div_col.append(div_card)
                                cards.append(div_col)
                            }
                        })
                    });
                }
                else {
                    end_of_pages = true;
                }
                scroll_handled = false;
            }
        })
    }
});

$(document).ready(function () {
    $('.btn_them').on("click", OnClick_Them);
    $('.btn_chitiet').on("click", OnClick_ChiTiet);
})

function OnClick_Them() {
    var cart_elem = $('#cart_amount');
    var MedID = $(this).closest('.card').find('.MedID').text();
    var MedName = $(this).closest('.card').find('.MedName').text();
    var userID = $("#UserID").text();

    if (cart_elem != null) { // Already logged in
        $.get("https://localhost:7191/cart_amount/" + userID + "/" + MedID, function (data, status) {
            var cart_amount = data;
            $.get("https://localhost:7191/get_stock/" + MedID, function (data, status) {
                var current_stock = parseInt(data);
                if (current_stock >= cart_amount + 1) {
                    $.ajax({
                        type: 'POST',
                        url: 'https://localhost:7191/add_cart',
                        data: JSON.stringify(
                            {
                                user_id: userID,
                                thuoc_id: MedID,
                                amount: 1
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

function OnClick_ChiTiet() {
    var MedID = $(this).closest('.card').find('.MedID').text();
    var image_Url = $(this).closest('.card').find('.card-img-top').attr('src');
    var url = "/Thuoc?thuoc_id=" + MedID + "&imageURL=" + image_Url;
    window.location.href = url;
}