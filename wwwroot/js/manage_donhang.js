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