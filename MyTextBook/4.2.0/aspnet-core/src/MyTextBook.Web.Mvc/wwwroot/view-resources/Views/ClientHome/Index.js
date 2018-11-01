(function() {
    $(function() {

        var _studentService = abp.services.app.students;
        var _$modal = $('#StudentCreateModal');
        var _$form = _$modal.find('form');
  
        //刷新
        $('#RefreshButton').click(function () {
            refreshStudentList();
        });

        $('.delete-student').click(function () {
           
            var studentId = $(this).attr("data-student-id"); 
            var studentName = $(this).attr("data-student-name");
            deleteStudent(studentId, studentName);
        });

        $('.edit-student').click(function (e) {

            var studentId = $(this).attr("data-student-id");

            e.preventDefault();
           
            $.ajax({
                url: abp.appPath + 'Students/EditStudentModal?studentId=' + studentId,
                type: 'GET',
                contentType: 'application/html',
                success: function (content) {
                   
                    $('#StudentEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();
           
            if (!_$form.valid()) {
                return;
            }
            
            var student = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            

            abp.ui.setBusy(_$modal);
            _studentService.create(student).done(function () {
                _$modal.modal('hide');
                location.reload(true); //页面重新加载
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshStudentList() {
            location.reload(true); //页面重新加载
        }

        function deleteStudent(studentId, studentName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MyTextBook'), studentName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _coursesService.delete({
                            id: studentId
                        }).done(function () {
                            refreshStudentList();
                        });
                    }
                }
            );
        }
    });
})();