function OnClick_Edit() {
    var confirmed = window.confirm("Bạn có muốn lưu thay đổi không?")
    if (confirmed) {
        var url = "https://localhost:7191/edit"
        var thuoc = {
            thuoc_id: $('#id').val(),
            so_luong_ton: parseInt($('#soluong').val()),
            don_gia: parseInt($('#dongia').val())
        }

        var row = $('.thuoc_id:contains('+thuoc.thuoc_id+')').closest('.table-row')

        var datajson = JSON.stringify(thuoc)
        $.ajax({
            url: url,
            type: "PUT",
            data: datajson,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                $.toast({
                    heading: 'SỬA THÀNH CÔNG',
                    icon: 'success',
                    position: 'top-right'
                });
                var element = $('#editModal');
                var modal = bootstrap.Modal.getInstance(element);
                modal.hide();
                row.find('.thuoc_so_luong_ton').text(thuoc.so_luong_ton)
                row.find('.thuoc_don_gia').text(thuoc.don_gia)
            },
            error: function () {
                $.toast({
                    heading: 'SỬA THẤT BẠI',
                    icon: 'error',
                    position: 'top-right'
                });
            }
        })
    }
}

function OnClick_Delete(button) {
    var confirmed = window.confirm("Bạn có muốn xóa không?")
    if (confirmed) {
        var thuoc_id = $(button).closest('.table-row').find('.thuoc_id').text();
        console.log(thuoc_id)
        $.ajax({
            url: "https://localhost:7191/delete/" + thuoc_id,
            type: "DELETE",
            success: function () {
                $.toast({
                    heading: 'XÓA THÀNH CÔNG',
                    icon: 'success',
                    position: 'top-right'
                });
                var row = $('.thuoc_id:contains(' + thuoc_id + ')').closest('.table-row')
                row.remove()
            },
            error: function () {
                $.toast({
                    heading: 'XÓA THẤT BẠI',
                    icon: 'error',
                    position: 'top-right'
                });
            }
        })
    }
}

$('#editModal').on('show.bs.modal', function (e) {
    var related = $(e.relatedTarget)
    var id = related.data('id')
    var ten = related.data('ten')
    var hoatchat = related.data('hoatchat')
    var soluong = related.data('soluong')
    var dongia = related.data('dongia')

    $('#id').val(id)
    $('#ten').val(ten)
    $('#hoatchat').val(hoatchat)
    $('#soluong').val(soluong)
    $('#dongia').val(dongia)
})