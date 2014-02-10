$(document).ready(function () {
    $("#edit-user-container").hide();
    $("#reset-user-container").hide();
    $("#btnSelectUser").show();

    $("#btnSelectUser").click(function () {

        $("#btnSelectUser").hide();
        $("#edit-user-container").show();
        $("#AllUsers").attr("disabled", true);
        $("#btnEditUser").show();
    });

    $("#btnEditUser").click(function () {

        $("#error-user-container").html("");
        var isSomeInvalideData = false;

        var userName = $("#AllUsers option:selected").text();
        var user = $("#AllUsers").val();
        var newPassword = $("#newPassword").val();
        var newRole = $("#newRole").val();

        if (newPassword.length < 6)
        {
            isSomeInvalideData = true;
            $("#error-user-container").html("<label class=\"text-error\">Password length must be greater then 5.</label>");
            alert(22);
        }

        if (isSomeInvalideData)
            return;

        $.ajax({
            url: '/Admin/EditUser',
            type: "POST",
            data: { userName: userName, newPassword: newPassword, newRole: newRole, id: user },
            success: function (results) {
                $("#newPassword").attr("disabled", true);
                $("#newRole").attr("disabled", true);
                $("#btnEditUser").hide();
                $("#reset-user-container").show();
            },
            error: function () {
                alert("error");
            },
            complete: function () {

            }
        });
    });

    $("#ResetUserForm").click(function () {
        $("#edit-user-container").hide();
        $("#reset-user-container").hide();
        $("#btnSelectUser").show();
        $("#AllUsers").attr("disabled", false);
        $("#newPassword").attr("disabled", false);
        $("#newRole").attr("disabled", false);
        $("#AllUsers").val("");
        $("#newPassword").val("");
        $("#newRole").val("");
    });
});