// <reference path="../jquery-3.3.1.min.js" />

function removefile() {
    var fileName = $(this).attr("data-name");
    $.ajax({
        url: '/Student/Requests/Upload',
        data: JSON.stringify(fileName),
        dataType: 'json',
        type: 'POST',
        success: function (res) {
            if (res) {
                Messenger().post({
                    message: 'Xóa file thành công!',
                    type: 'success',
                    showCloseButton: true
                });
            }
            else {
                Messenger().post({
                    message: 'Xóa file thất bại!',
                    type: 'error',
                    showCloseButton: true
                });
            }
        }
    });
}

$('#btnUpload').on('click', function () {
    //Lấy ra files
    var file_data = $('#file').prop('files')[0];
    //lấy ra kiểu file
    var type = file_data.type;
    //Xét kiểu file được upload
    var match = ["application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document",];
    //kiểm tra kiểu file
    if (type === match[0] || type === match[1] || type === match[2]) {
        //khởi tạo đối tượng form data
        var form_data = new FormData();
        //thêm files vào trong form data
        form_data.append('Attach', file_data);
        //sử dụng ajax post
        $.ajax({
            url: '/Student/Requests/Upload', // gửi đến file upload.php
            dataType: 'text',
            cache: false,
            contentType: false,
            processData: false,
            data: form_data,
            type: 'post',
            success: function (res) {
                $('#isUpload').append(
                    '<div class="input-group">' +
                    '<a class="input-group-addon danger" data-name="' + file_data.name + '" onclick"RemoveFile()">' +
                    '<span class="arrow"></span>' +
                    '<i class="fa fa-trash"></i>' +
                    '</a>' +
                    '<input type="text" class="form-control" value=' + file_data.name + ' disabled>' +
                    '</div>' +
                    '<input type="hidden" name="AttachName" value="' + file_data.name + '"/>'
                );
                $('#file').val('');
            }
        });
    } else {
        $('#status').text('Chỉ được upload file PDF, DOC, DOCX');
        $('#file').val('');
    }
    return false;
});
