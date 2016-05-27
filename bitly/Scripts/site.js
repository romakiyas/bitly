function minifyUrl() {
    var url = $('#iUrl').val();
    if (isURL(url)) {
        $.post('/home/minify', { url: url },
            function (data) {
                $('#result').html(data);
                $('#iResultUrl').select();
            });
    } else
        $('#iUrl').popover('show');
}

function copyToClipboard() {
    $('#iResultUrl').select();
    document.execCommand("copy");
    $('#btnCopy').addClass('btn-success');
    $('#btnCopy').html('Скопировано!');
}

function deleteUrl(id) {
    $.get('/home/remove', { id: id },
            function () {
                $('#urlRow'+id).remove();
            });
}

function isURL(str) {
    var urlRegex = '^(http[s]?:\\/\\/(www\\.)?|ftp:\\/\\/(www\\.)?|www\\.){1}([0-9A-Za-zА-Яа-я-\\.@:%_\+~#=]+)+((\\.([a-zA-Z]{2,3})|(рф))+)(/(.)*)?(\\?(.)*)?';
    var url = new RegExp(urlRegex, 'i');
    return str.length < 2083 && url.test(str);
}