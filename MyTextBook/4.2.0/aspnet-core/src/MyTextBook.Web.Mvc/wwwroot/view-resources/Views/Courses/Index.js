(function() {
    $(function() {

        var _coursesService = abp.services.app.courses;
        var _$modal = $('#CourseCreateModal');
        var _$form = _$modal.find('form');
  
        //刷新
        $('#RefreshButton').click(function () {
            refreshCourseList();
        });

        $('.delete-course').click(function () {
           
            var courseId = $(this).attr("data-course-id"); 
            var courseName = $(this).attr("data-course-name");
            deleteCourse(courseId, courseName);
        });

        $('.edit-course').click(function (e) {

            var courseId = $(this).attr("data-course-id");

            e.preventDefault();
           
            $.ajax({
                url: abp.appPath + 'Courses/EditCourseModal?courseId=' + courseId,
                type: 'GET',
                contentType: 'application/html',
                success: function (content) {
                   
                    $('#CourseEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }
            var coun = $("#createSeleCourseType").val();
            if (coun == 0) {
                $("#hao").html("课程分类不能为空");
                return;
            } else {
                $("#hao").html("");
            }
            var course = _$form.serializeFormToObject(); ////获取表单内容
            

            abp.ui.setBusy(_$modal);
            _coursesService.create(course).done(function () {
                _$modal.modal('hide');
                location.reload(true); //页面重新加载
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshCourseList() {
            location.reload(true); //页面重新加载
        }

        function deleteCourse(courseId, courseName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MyTextBook'), courseName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _coursesService.delete({
                            id: courseId
                        }).done(function () {
                            refreshCourseList();
                        });
                    }
                }
            );
        }
    });
})();