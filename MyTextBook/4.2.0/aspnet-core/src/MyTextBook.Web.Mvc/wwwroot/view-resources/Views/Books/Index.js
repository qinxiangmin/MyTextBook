(function() {
    $(function() {

        var _bookTypeService = abp.services.app.books;
        var _$modal = $('#BookCreateModal');
        var _$form = _$modal.find('form');
  
        //刷新
        $('#RefreshButton').click(function () {
            refreshUserList();
        });

        $('.delete-book').click(function () {
            
            var bookId = $(this).attr("data-book-id");
            
            deleteBook(bookId);
            
        });

        $('.edit-book').click(function (e) {
            
            var bookId = $(this).attr("data-book-id");

            e.preventDefault();
           
            $.ajax({
                url: abp.appPath + 'Books/EditBookModalAsync?bookId=' + bookId,
                type: 'GET',
                contentType: 'application/html',
                success: function (content) {                   
                    $('#BookEditModal div.modal-content').html(content);
                },
                error: function (e) { }
            });
        });

        _$form.find('button[type="submit"]').click(function (e) {
            e.preventDefault();

            if (!_$form.valid()) {
                return;
            }
            var coun = $("#createSeleBookType").val();
            if (coun == 0) {
                $("#hao").html("图书分类不能为空");
                return;
            } else {
                $("#hao").html("");
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
        //第一个文本框获得焦点
        _$modal.on('shown.bs.modal', function () {
            _$modal.find('input:not([type=hidden]):first').focus();
        });

        function refreshBookList() {
            location.reload(true); //页面重新加载
        }

        function deleteBook(bookId, userName) {
            abp.message.confirm(
                abp.utils.formatString(abp.localization.localize('AreYouSureWantToDelete', 'MyTextBook'), userName),
                function (isConfirmed) {
                    if (isConfirmed) {
                        _bookTypeService.delete({
                            id: bookId
                        }).done(function () {
                            refreshBookList();
                        });
                    }
                }
            );
        }
    });
})();