(function() {
    $(function () {
        
        var _TDepartmentService = abp.services.app.tDepartments;
        var _$modal = $('#TDepartmentCreateModal');
        var _$form = _$modal.find('form');
  
        //刷新
        $('#RefreshButton').click(function () {
            refreshTDepartment();
        });

        $('.delete-tDepartment').click(function () {
            
            var tDepartmentid = $(this).attr("data-tDepartment-id");
            var tDepartmentName = $(this).attr("data-tDepartment-name");
                deleteTDepartment(tDepartmentid, tDepartmentName);
            
        });

        $('.edit-tDepartment').click(function (e) {
            
            var tDepartmentId = $(this).attr("data-tDepartment-id");

            e.preventDefault();            
            $.ajax({
                url: abp.appPath + 'TDepartments/EditTDepartmentModalAsync?tDepartmentId=' + tDepartmentId,
                type: 'GET',
                contentType: 'application/html',
                success: function (content) {
                   
                    $('#TDepartmentEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });
       
        _$form.find('button[type="submit"]').click(function (e) {            
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }
           

            var tDepartment = _$form.serializeFormToObject(); //获取表单内容
           
            
            abp.ui.setBusy(_$modal);
            _TDepartmentService.create(tDepartment).done(function () {
               
                _$modal.modal('hide');
                location.reload(true); //页面重新加载
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        //第一个文本框获得焦点
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshTDepartment() {
            location.reload(true); //页面重新加载
        }

        function deleteTDepartment(tDepartmentid, tDepartmentName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MyTextBook'), tDepartmentName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _TDepartmentService.delete({
                            id: tDepartmentid
                        }).done(function () {
                            refreshTDepartment();
                        });
                    }
                }
            );
        }
    });
})();