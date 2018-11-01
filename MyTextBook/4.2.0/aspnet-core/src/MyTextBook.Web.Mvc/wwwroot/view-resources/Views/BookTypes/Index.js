(function() {
    $(function() {

        var _bookTypeService = abp.services.app.bookTypes;
        var _$modal = $('#BookTypeCreateModal');
        var _$form = _$modal.find('form');
  
        //刷新
        $('#RefreshButton').click(function () {
            refreshUserList();
        });

        $('.delete-bookType').click(function () {
            
            var bookTypeId = $(this).attr("data-bookType-id");           
            deleteUser(bookTypeId);
        });

        $('.edit-bookType').click(function (e) {
           
            var bookTypeId = $(this).attr("data-bookType-id");

            e.preventDefault();
           
            $.ajax({
                url: abp.appPath + 'BookTypes/EditBookTypeModal?bookTypeId=' + bookTypeId,
                type: 'GET',
                contentType: 'application/html',
                success: function (content) {
                   
                    $('#BookTypeEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }

            var booktype = _$form.serializeFormToObject(); //serializeFormToObject is defined in main.js
            

            abp.ui.setBusy(_$modal);
            _bookTypeService.create(booktype).done(function () {
                _$modal.modal('hide');
                location.reload(true); //页面重新加载
            }).always(function () {
                abp.ui.clearBusy(_$modal);
            });
        });
        
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshUserList() {
            location.reload(true); //页面重新加载
        }

        function deleteUser(userId, userName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MyTextBook'), userName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _bookTypeService.delete({
                            id: userId
                        }).done(function () {
                            refreshUserList();
                        });
                    }
                }
            );
        }
    });
})();