var common =
{
    getDate: function (date) {
        var y = date.getFullYear();
        var m = date.getMonth() + 1;
        var d = date.getDate();
        return y + "-" + (m < 10 ? ("0" + m) : m) + "-" + (d < 10 ? ("0" + d) : d);
    },
    deleteData: function (grid, url) {
        var rows = $('#' + grid).datagrid('getSelections');
        if (rows.length == 0) {
            $.messager.alert("消息", "请选择要删除的数据!", 'warning');
        }
        else {
            for (var i = 0; i < rows.length; i++) {
                var index = $('#' + grid).datagrid('getRowIndex', rows[i]);
                $.ajax({
                    type: 'POST',
                    url: url,
                    data: rows[i],
                    success: function () {
                        $.messager.alert("消息", "已成功删除" + rows.length + "条数据!");
                    }
                });
                $('#' + grid).datagrid('deleteRow', index);
            }
        }
    }
}


