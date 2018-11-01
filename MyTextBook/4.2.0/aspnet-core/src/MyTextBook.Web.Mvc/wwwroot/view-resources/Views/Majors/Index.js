(function() {
    $(function() {

        var _majorsService = abp.services.app.majors;
        var _$modal = $('#MajorCreateModal');
        var _$form = _$modal.find('form');
  
        //刷新
        $('#RefreshButton').click(function () {
            refreshMajorList();
        });

        $('.delete-major').click(function () {
            
            var majorId = $(this).attr("data-major-id"); 
            var majorName = $(this).attr("data-major-name");
            deleteMajor(majorId, majorName);
        });

        $('.edit-major').click(function (e) {
           
            var majorId = $(this).attr("data-major-id");

            e.preventDefault();
           
            $.ajax({
                url: abp.appPath + 'Majors/EditMajorModal?majorId=' + majorId,
                type: 'GET',
                contentType: 'application/html',
                success: function (content) {
                   
                    $('#MajorEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();            
            if (!_$form.valid()) {
                return;
            }
            var coun = $("#createTDepartment").val();
            if (coun == 0) {
                $("#hao").html("部门不能为空");
                return;
            } else {
                $("#hao").html("");
            }
            var major = _$form.serializeFormToObject(); ////获取表单内容
            

            abp.ui.setBusy(_$modal);
            _majorsService.create(major).done(function () {
                _$modal.modal('hide');
                location.reload(true); //页面重新加载
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshMajorList() {
            location.reload(true); //页面重新加载
        }

        function deleteMajor(majorId, majorName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MyTextBook'), majorName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _majorsService.delete({
                            id: majorId
                        }).done(function () {
                            refreshMajorList();
                        });
                    }
                }
            );
        }
    });
})();