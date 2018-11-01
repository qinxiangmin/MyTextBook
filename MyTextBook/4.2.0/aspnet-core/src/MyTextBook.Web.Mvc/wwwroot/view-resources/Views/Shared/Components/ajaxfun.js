function RequestByPostMethod(RequestUrl, PostObject, Callback) {
    var obj = {
        type: "POST",
        url: RequestUrl,
        contenType: "application/json; character=utf-8",
        data: JSON.stringify(PostObject),
        dataType: "json",
        success: function (data) {
            Callback(data);
        },
        error: function (data) {
            //alert("服务器或网络故障");
        }
    };
    $.ajax(obj);
}

function GetQueryString(name) {
    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
    var r = window.location.search.substr(1).match(reg);
    if (r != null) return unescape(r[2]); return null;
}