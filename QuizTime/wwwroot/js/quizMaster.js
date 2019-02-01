"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/quizHub").build();

connection.on("DisplayPlayerName", function (playerName) {
    // var div = document.createElement("div");
    // var name = document.createElement("span");
    // name.textContent = playerName;
    // var btn = document.createElement("button");
    // btn.textContent = "Remove";
    // div.appendChild(name);
    // div.appendChild(btn);
    // document.getElementById("playersList").appendChild(div);
        $.ajax({
            url: '/Quiz/DisplayPlayer',
            data: {'name': playerName},
            success: function (response){
                $("#players").html(response);
            },
            error: function () {
                alert("error occured");
            }
        });
});
connection.start().catch(function (err) {
    return console.error(err.toString());
})
document.getElementById("startButton").addEventListener("click", function (event) {
    var quizCode = 12345;
    connection.invoke("AddToQuiz", quizCode.toString).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

