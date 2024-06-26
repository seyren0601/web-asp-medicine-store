﻿var thuoc_found = []

$(document).ready(function ()
{
    $('#ChonThuoc').on('change', OnChange_ChonThuoc);
})

function OnClick_Tim() {
    var tenthuoc_query;
    var tenhoatchat_query;
    if ($('input[name="SearchOptions"]:checked').val() == "tenthuoc") {
        tenthuoc_query = $('#search').val();
    }
    else {
        tenhoatchat_query = $('#search').val();
    }
    $.ajax({
        url: "https://localhost:7191/find_thuoc",
        type: "GET",
        data: {
            tenthuoc: tenthuoc_query,
            tenhoatchat: tenhoatchat_query
        },
        success: function (response) {
            var listThuoc = $('#ChonThuoc');
            listThuoc.empty();
            thuoc_found = response
            $.each(response, function (i, elem) {
                let option = $('<option>');
                option.attr("value", elem["id"]);
                option.text(elem["teN_THUOC"]);
                listThuoc.append(option);
            });
        }
    });
}

function OnChange_ChonThuoc() {
    var value = $(this).val();
    var thuoc = thuoc_found.find(x => x.id == value);
    let thongtin = $('#thongtinthuoc');
    thongtin.empty();
    let out = $('<pre>');
    out.text("id: " + thuoc.id + "\nTên thuốc: " + thuoc.teN_THUOC + "\nHoạt chất: " + thuoc.hoaT_CHAT);
    thongtin.append(out);
    $('#input_id').val("" + thuoc.id);
    $('#input_hoatchat').val("" + thuoc.hoaT_CHAT);
    $('#input_tenthuoc').val("" + thuoc.teN_THUOC);
    $('#Input_DonGia').removeAttr('disabled');
    $('#Input_SoLuong').removeAttr('disabled');
}