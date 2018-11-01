(function() {
    $(function() {

        var _studentClassService = abp.services.app.studentClasses;
        var _$modal = $('#StudentClassCreateModal');
        var _$form = _$modal.find('form');
  
        //刷新
        $('#RefreshButton').click(function () {
            refreshStudentClassList();
        });

        $('.delete-studentClass').click(function () {
            
            var studentClassId = $(this).attr("data-studentClass-id"); 
            var studentClassName = $(this).attr("data-studentClass-name");
            deleteStudentClass(studentClassId, studentClassName);
        });

        $('.edit-studentClass').click(function (e) {
            
            var studentClassId = $(this).attr("data-studentClass-id");

            e.preventDefault();
           
            $.ajax({
                url: abp.appPath + 'StudentClasses/EditStudentClassModal?studentClassId=' + studentClassId,
                type: 'GET',
                contentType: 'application/html',
                success: function (content) {
                   
                    $('#StudentClassEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();            
            if (!_$form.valid()) {
                return;
            } 
            var coun = $("#createSeleMajor").val();
            if (coun == 0) {
                $("#hao").html("专业不能为空");
                return;
            } else {
                $("#hao").html("");
            }
            var coun1 = $("#createSeleGrade").val();
            if (coun1 == 0) {
                $("#hao1").html("年级不能为空");
                return;
            } else {
                $("#hao1").html("");
            }

            var major = _$form.serializeFormToObject(); //获取表单内容
            

            abp.ui.setBusy(_$modal);
            _studentClassService.create(major).done(function () {
                _$modal.modal('hide');
                location.reload(true); //页面重新加载
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshStudentClassList() {
            location.reload(true); //页面重新加载
        }

        function deleteStudentClass(studentClassId, studentClassName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MyTextBook'), studentClassName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _studentClassService.delete({
                            id: studentClassId
                        }).done(function () {
                            refreshStudentClassList();
                        });
                    }
                }
            );
        }
    });
})();