$(function () {
    $.post('/Products/GetProductData/', function (data) {

        //有取得商品資料
        if (data && data.length > 0) {
            $.each(data, function (i, item) {
                var option = document.createElement('option');
                $(option).val(item.SN);
                $(option).text(item.Name);
                $('#Product').append(option);
            });
        }
    });
});