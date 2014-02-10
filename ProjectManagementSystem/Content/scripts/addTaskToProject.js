$(document).ready(function () {

    $("#reset-add-task-container").hide();

    $("#btnAddTask").click(function () {

        var isSomeInvalideData = false;

        var projectId = $("#AllProjects").val();
        var taskName = $("#Name").val();
        var taskDescription = $("#Description").val();
        var taskProfit = $("#Profit").val();
        var taskTime = $("#Time").val();

        if ((taskProfit / taskProfit) ? false : true) {
            $("#Profit").val("Value must be a number!");
            isSomeInvalideData = true;
        }
        if (taskProfit <= 0) {
            $("#Profit").val("Value must be greater than zero!");
            isSomeInvalideData = true;
        }

        if ((taskTime / taskTime) ? false : true) {
            $("#Time").val("Value must be a number!");
            isSomeInvalideData = true;
        }
        if (taskTime <= 0) {
            $("#Time").val("Value must be greater than zero!");
            isSomeInvalideData = true;
        }

        if (isSomeInvalideData)
            return;

        $("#btnAddTask").hide();
        $("#AllProjects").attr("disabled", true);
        $("#Name").attr("disabled", true);
        $("#Description").attr("disabled", true);
        $("#Profit").attr("disabled", true);
        $("#Time").attr("disabled", true);
        $.ajax({
            url: '/Manager/AddNewTaskToProject',
            type: "POST",
            data: { idProject: projectId,  name:taskName, description:taskDescription, profit:taskProfit, time:taskTime },
            success: function (results) {

                $("#AllProjects").attr("disabled", true);
                $("#reset-add-task-container").show();
            },
            error: function () {
                alert("error");
                $("#btnAddTask").show();
            }
        });
    });



    $("#ResetAddTaskForm").click(function () {
        $("#reset-add-task-container").hide();
        $("#btnAddTask").show();
        $("#AllProjects").attr("disabled", false);
        $("#Name").attr("disabled", false);
        $("#Description").attr("disabled", false);
        $("#Profit").attr("disabled", false);
        $("#Time").attr("disabled", false);
        $("#AllProjects").val("");
        $("#Name").val("");
        $("#Description").val("");
        $("#Profit").val("");
        $("#Time").val("");
    });
});