$(document).ready(function () {

    $("#content-iter-curr-iteration-container").hide();
    $("#content-result-curr-iteration-container").html("");
    
    $("#btnCurrIter").click(function () {

        projectId = $("#AllProjects").val();
        $("#btnCurrIter").hide();
        $("#AllProjects").attr("disabled", true);
        $.ajax({
            url: '/Manager/ShowCurrentIterationForProject',
            type: "POST",
            data: { projectId: projectId },
            success: function (results) {

                if (results.numberOfIterations > 0) {
                    $("#AllIterations").html(results.Iterations);
                    $("#content-iter-curr-iteration-container").show();
                    $("#btnGetIterTasks").show();
                    $("#AllIterations").attr("disabled", false);
                } else {
                    $("#content-iter-curr-iteration-container").html("No iterations in current project.");
                    $("#btnCurrIter").show();
                }
            },
            error: function () {
                alert("Some server's errors. Please try later.");
                $("#btnCurrIter").show();
            }
        });
    });

    $("#btnGetIterTasks").click(function () {

        projectId = $("#AllProjects").val();
        iterNumber = $("#AllIterations").val();

        $("#btnCurrIter").hide();
        $.ajax({
            url: '/Manager/ShowCurrentTasksForIteration',
            type: "POST",
            data: { projectId: projectId, iterNumber: iterNumber},
            success: function (results) {
                $("#btnCurrIter").show();
                $("#AllProjects").attr("disabled", false);
                if (results.numberOfTasks > 0) {
                    $("#content-result-curr-iteration-container").html(results.Iterations);
                    $("#btnGetIterTasks").hide();
                    $("#AllIterations").attr("disabled", true);
                } else {
                    $("#content-result-curr-iteration-container").html("No iterations in current project.");
                }
            },
            error: function () {
                alert("Some server's errors. Please try later.");
                $("#btnCurrIter").show();
            }
        });
    });

});