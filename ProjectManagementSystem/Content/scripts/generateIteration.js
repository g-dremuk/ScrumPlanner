$(document).ready(function () {
    $("#reset-add-task-container").hide();
   
    $("#btnGenerateIteration").click(function () {

        taskId = $("#AllProjects").val();
        $("#btnGenerateIteration").hide();
        $.ajax({
            url: '/Manager/GenerateIteration',
            type: "POST",
            data: { idProject: taskId },
            success: function (res) {
                $("#AllProjects").attr("disabled", true);
                $("#reset-add-task-container").show();
                $("#generateResult").html(res.Tasks);
            },
            error: function () {
                alert("error");
                $("#btnGenerateIteration").show();
            }
        });
    });



    $("#ResetAddTaskForm").click(function () {
        $("#reset-add-task-container").hide();
        $("#btnGenerateIteration").show();
        $("#AllProjects").attr("disabled", false);
        $("#AllProjects").val("");
    });
});