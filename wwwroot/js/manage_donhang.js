var nextPage = 2;
var end_of_pages = false;
var scroll_handled = false;
var userID = $('#UserID').text();

$(window).scroll(function () {
    if ($(window).scrollTop() >= $(document).height() - $(window).height() - 10 && !end_of_pages && !scroll_handled) {
        scroll_handled = true;
        $.ajax({
            url: "/donhang/paged?user_id=" + userID + "&page=" + nextPage,
            type: "get",
            success: function (paged_list) {
                nextPage += 1;
                if (paged_list.length > 0) {
                    console.log(paged_list)
                    var table_body = $('#table_body');
                    $.each(paged_list, function (index, don_hang) {
                        var da_thanh_toan = don_hang['da_thanh_toan'];
                        var tr = $('<tr>')
                            .addClass('table-row')
                            .attr('data-bs-toggle', 'modal')
                            .attr('data-bs-target', '#DonHangModal')
                            .attr('data-id', don_hang['ma_don_hang'])
                        var td1 = $('<td>')
                            .addClass('ma_don_hang')
                            .text(don_hang['ma_don_hang'])
                        var date = new Date(don_hang['paymentDate']);
                        var td2 = $('<td>')
                            .addClass('ngay_thanh_toan')
                            .text(date.toLocaleDateString() + " " + date.toLocaleTimeString());
                        var td3 = $('<td>')
                            .addClass('ma_thanh_toan')
                            .text(don_hang['paymentID']);
                        var td4 = $('<td>')
                        if (da_thanh_toan) {
                            td4.addClass('trang_thai')
                                .addClass('bg-success')
                                .text('Đã thanh toán')
                        }
                        else {
                            td4.addClass('trang_thai')
                                .addClass('bg-danger')
                                .text('Thanh toán thất bại')
                        }
                        tr.append(td1);
                        tr.append(td2);
                        tr.append(td3);
                        tr.append(td4);
                        table_body.append(tr);
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

$('#DonHangModal').on('show.bs.modal', function (e) {
    var related = $(e.relatedTarget)
    var id = related.data('id')

    $('#id').val(id);
    var table_body = $('#body_modal');
    table_body.empty();
    $.ajax({
        url: "/donhang/" + id,
        type: "get",
        success: function (data) {
            var trangthai = data['da_thanh_toan'];
            if (trangthai == true) {
                $('#trangthai').text(" Đã thanh toán")
                $('#trangthai').css('color', 'green')
            }
            else {
                $('#trangthai').text(" Thanh toán lỗi")
                $('#trangthai').css('color', 'red')
            }
            $.ajax({
                url: "/chitiet_donhang/" + id,
                type: "get",
                success: function (chitiet_dh) {
                    $.each(chitiet_dh, function (index, value) {
                        var row = $('<tr>');
                        $.ajax({
                            url: "/thuoc/" + value['thuoc_id'],
                            type: "get",
                            success: function (thuoc) {
                                var td1 = $('<td>').text(thuoc['ten']);
                                row.append(td1);
                                var td2 = $('<td>').text(value['so_luong_mua']);
                                row.append(td2);
                                table_body.append(row);
                            }
                        });
                    });
                }
            });
        }
    });
})

function OnClick_XacNhan() {
    var element = $('#DonHangModal');
    var modal = bootstrap.Modal.getInstance(element);
    modal.hide();
}