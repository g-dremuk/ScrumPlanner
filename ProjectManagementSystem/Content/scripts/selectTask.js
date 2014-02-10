$(document).ready(function () {
    var taskId;
    $("#reset-container").hide();
    
    $("#btnSelect").click(function () {

        taskId = $("#AllTasks").val();
        $("#btnSelect").hide();
        $.ajax({
            url: '/Programmer/SelectTask',
            type: "POST",
            data: { id: taskId },
            success: function (results) {
                
                $("#AllTasks").attr("disabled", true);
                $("#reset-container").show();
            },
            error: function () {
                alert("error");
                $("#btnSelect").show();
            }
        });
    });

    

    $("#ResetForm").click(function () {
        $("#reset-container").hide();
        $("#btnSelect").show();
        $("#AllTasks").attr("disabled", false);
        $("#AllTasks").val("");
        var options = document.getElementById("AllTasks").children;
        if (options.length > 0) {
            for (var i = 0; i < options.length; i++) {
                if (options[i].getAttribute("value") == taskId) {
                    document.getElementById("AllTasks").removeChild(options[i]);
                    break;
                }
            }
        }
    });
});