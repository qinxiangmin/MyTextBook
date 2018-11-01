(function() {
    $(function() {

        var _courseTypesService = abp.services.app.courseTypes;
        var _$modal = $('#CourseTypeCreateModal');
        var _$form = _$modal.find('form');
  
        //刷新
        $('#RefreshButton').click(function () {
            refreshCourseTypeList();
        });

        $('.delete-courseType').click(function () {
            
            var courseTypeId = $(this).attr("data-courseType-id"); 
            var courseTypeName = $(this).attr("data-courseType-name");
            deleteCourseType(courseTypeId, courseTypeName);
        });

        $('.edit-courseType').click(function (e) {
           
            var courseTypeId = $(this).attr("data-courseType-id");

            e.preventDefault();
           
            $.ajax({
                url: abp.appPath + 'CourseTypes/EditCourseTypeModal?courseTypeId=' + courseTypeId,
                type: 'GET',
                contentType: 'application/html',
                success: function (content) {
                   
                    $('#CourseTypeEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var courseType = _$form.serializeFormToObject(); ////获取表单内容
            

            abp.ui.setBusy(_$modal);
            _courseTypesService.create(courseType).done(function () {
                _$modal.modal('hide');
                location.reload(true); //页面重新加载
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshCourseTypeList() {
            location.reload(true); //页面重新加载
        }

        function deleteCourseType(courseTypeId, courseTypeName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MyTextBook'), courseTypeName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _courseTypesService.delete({
                            id: courseTypeId
                        }).done(function () {
                            refreshCourseTypeList();
                        });
                    }
                }
            );
        }
    });
})();