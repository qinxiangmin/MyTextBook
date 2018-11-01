(function ($) {   
    var _majorService = abp.services.app.majors;
    var _$modal = $('#MajorEditModal');
    var _$form = $('form[name=MajorEditForm]');

    function save() {

        if (!_$form.valid()) {
            return;
        }
        var coun = $("#EditSeleTDepartment").val();
        if (coun == 0) {
            $("#Edithao").html("部门不能为空");
            return;
        } else {
            $("#Edithao").html("");
        }
        var major = _$form.serializeFormToObject(); //获取表单内容
     
        abp.ui.setBusy(_$form);
        _majorService.update(major).done(function () {
            _$modal.modal('hide');
            location.reload(true); //表单重新加载
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    }

    //保存按钮点击触发
    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    //回车键按下触发
    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    $.AdminBSB.input.activate(_$form);

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);