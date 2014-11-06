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
            //指定選擇編輯資料的商品
            var psn = $('#product_sn').val();
            $('#Product option[value=' + psn +']').attr('selected', 'selected');
        }
    });
});