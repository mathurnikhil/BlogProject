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

$('.deletepostclass').click(function (event) {
    var id = $(event.target).attr('data-id');
    console.log(id);
    $("#confirmdelete").attr('data-id', id);
});

$('#confirmdelete').click(function (event) {
    var id = $(event.target).attr('data-id');
    console.log(id);
    $.ajax({
        url: '/UserData/DeleteBlog/' + id,
        type: 'DELETE'
    })
})