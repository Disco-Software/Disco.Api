$(document).ready(function () {
    console.log("lol 1");
    $("#login-button").click(function () {
        console.log('lol 2');
        let data = $('.login-form').serialize();
        console.log(data);
        $.post('https://devdiscoapi.azurewebsites.net/api/admin/authentication/log-in', data,
            function (data, status) {
                if (status == 'success') {
                    if (data.user != null) {
                        $.post(`/admin/users/save?token=${data.accessToken}`, function (data, status) {
                            window.location.href = "/admin/users";
                        });
                    }
                }
                else if (status == "Unauthorized") {
                }
            })
    })
})
