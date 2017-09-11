$("#addblogid").click(function (event) {
    console.log($("#form").serialize());
    var form = $("#form").serialize();
    $.ajax({
        url: "@Url.Action('AddBlog', 'UserData')", //'/UserData/AddBlog',
        type: "POST",
        data: form, //if you need to post Model data, use this
        success: (function (result) {
            $.ajax({
                url: "@Url.Action('PostTemplate', 'UserData')", //'/UserData/PostTemplate',//"@Url.Action('UserData/Post')",
                type: "GET",
                data: form, //if you need to post Model data, use this
                success: (function (result) {
                    console.log(result);
                    $("#partialprepend").html(result);
                })
            });
        })
    });
});

$('.tag').click(function (event) {
    var id = String(event.target.id);
    //console.log(id);
    $("#getpostbytagdiv").html("<i class=\"fa fa-circle-o-notch fa-spin\" style=\"font-size:24px\"></i>");
    $.ajax({
        url: '/Home/GetPostByTag/' + id,
        type: 'GET'
    }).done(function (result) {
        //console.log(result);
        $("#getpostbytagdiv").html(result);
    });
});

//var data = $("#form");
//$post('AddBlog', data.serialize())
//    .done(function () {
//        $post('Post', data.serialize())
//            .done(function (result) {
//                $("#partial").prepend(result);
//            });
//    });