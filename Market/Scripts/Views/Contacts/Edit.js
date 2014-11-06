$(function () {
    $.post('/Contacts/GetCustomerData/', function (data) {

        //有取得客戶資料
        if (data && data.length > 0) {
            $.each(data, function (i, item) {
                var option = document.createElement('option');
                $(option).val(item.SN);
                $(option).text(item.Name);
                $('#Customer').append(option);
            });
            //指定選擇編輯資料的客戶
            var csn = $('#customer_sn').val();
            $('#Customer option[value=' + csn + ']').attr('selected', 'selected');
        }
    });
});