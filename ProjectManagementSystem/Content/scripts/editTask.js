$(document).ready(function () {
    $("#edit-task-container").hide();
    $("#reset-task-container").hide();
    $("#btnSelectTask").show();

    $("#btnSelectTask").click(function () {

        $("#btnSelectTask").hide();
        $("#edit-task-container").show();
        $("#AllTasks").attr("disabled", true);
        $("#btnEditTask").show();
    });

    $("#btnEditTask").click(function () {

        var isSomeInvalideData = false;

        var taskName = $("#AllTasks option:selected").text();
        var taskId = $("#AllTasks").val();
        var newDescription = $("#newDescription").val();
        var newProfit = $("#newProfit").val();
        var newTime = $("#newTime").val();

        if ((newProfit / newProfit) ? false : true)
        {
            $("#newProfit").val("Value must be a number!");
            isSomeInvalideData = true;
        }
        if (newProfit <= 0)
        {
            $("#newProfit").val("Value must be greater than zero!");
            isSomeInvalideData = true;
        }

        if ((newTime / newTime) ? false : true) {
            $("#newTime").val("Value must be a number!");
            isSomeInvalideData = true;
        }
        if (newTime <= 0) {
            $("#newTime").val("Value must be greater than zero!");
            isSomeInvalideData = true;
        }

        if (isSomeInvalideData)
            return;

        $.ajax({
            url: '/Admin/EditTask',
            type: "POST",
            data: { name: taskName, description: newDescription, profit: newProfit, time: newTime, id: taskId },
            success: function (results) {
                $("#newDescription").attr("disabled", true);
                $("#newProfit").attr("disabled", true);
                $("#newTime").attr("disabled", true);
                $("#btnEditTask").hide();
                $("#reset-task-container").show();
            },
            error: function () {
                alert("error");
            },
            complete: function () {
                alert(newDescripton);
            }
        });
    });

    $("#ResetTaskForm").click(function () {
        $("#edit-task-container").hide();
        $("#reset-task-container").hide();
        $("#btnSelectTask").show();
        $("#AllTasks").attr("disabled", false);
        $("#newDescription").attr("disabled", false);
        $("#newProfit").attr("disabled", false);
        $("#newTime").attr("disabled", false);
        $("#AllTasks").val("");
        $("#newDescription").val("");
        $("#newProfit").val("");
        $("#newTime").val("");
    });
});