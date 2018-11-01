(function () {
	$(function () {

        var _studentBookService = abp.services.app.studentBook;
        var _$modal = $('#StudentBookCreateModal');
		var _$form = _$modal.find('form');
		_$form.validate({
        }); 
        
        $("#fashu").click(function (e) {
			e.preventDefault();            
			if (!_$form.valid()) {
				return;
			}

			var role = _$form.serializeFormToObject(); //获取表单内容
            role.StudentId = [];
            var _$studentsCheckboxes = $("input[name='student']:checked");
            if (_$studentsCheckboxes) {
                if (_$studentsCheckboxes.length == 0) {
                   // return;
                }
                for (var studentsIndex = 0; studentsIndex < _$studentsCheckboxes.length; studentsIndex++) {
                    var _$studentsCheckbox = $(_$studentsCheckboxes[studentsIndex]);
                    role.StudentId.push(_$studentsCheckbox.val());
				}
			}

			abp.ui.setBusy(_$modal);
            _studentBookService.create(role).done(function () {				
                window.location.href = "/Orders/Index";
			}).always(function () {
				abp.ui.clearBusy(_$modal);
			});
		});		
	});
})();