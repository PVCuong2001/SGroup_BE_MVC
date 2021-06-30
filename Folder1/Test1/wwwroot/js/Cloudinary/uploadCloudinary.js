$(function () {
    $('.cloudinary-fileupload').fileupload({
        dropZone: '#direct_upload',
        start: function () {
            $('.status_value').text('Starting direct upload...');
        },
        progress: function () {
            $('.status_value').text('Uploading...');
        },
    })
        .bind('fileuploaddone', function (e, data) {
            $('#image_url').val(data.result.url);
            console.log($('#image_url').val());
            $('.status_value').text('Idle');
            var info = $('<div class="uploaded_info"/>');
            $(info).append($('<div class="image"/>').append(
                $.cloudinary.image(data.result.public_id, {
                    format: data.result.format,
                    width: 150,
                    height: 150,
                    crop: "fill"
                })
            ));
            $('.uploaded_info_holder').append(info);
        })
        .bind('fileuploadfail', function (e, data) {
            $('.status_value').text('Upload error!');
        });
});