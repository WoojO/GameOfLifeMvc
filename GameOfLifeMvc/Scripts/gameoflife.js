﻿function sendDataToServer() {
    var dataToSend = $('#gameDataInput').val();
    var jqxhr = $.post("/api/newGeneration", { InputData: dataToSend }, function (data) {
        $('#gameDataOutput').val(data);
    })
    .fail(function (data) {
        alert("error: " + data);
    })
}

function showError(msg) {
    alert(msg);
}

$(document).ready(function () {
    $('#sendDataBtn').click(sendDataToServer);
});