"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/quizHub").build();

connection.on("DisplayPlayerName", function (playerName) {
    var li = document.createElement("li");
    li.textContent = playerName;
    document.getElementById("playersList").appendChild(li);
});
connection.start().catch(function (err) {
    return console.error(err.toString());
})
// document.getElementById("startButton").addEventListener("click", function (event) {
//     var quizCode = 12345;
//     connection.invoke("AddToQuiz", quizCode).catch(function (err) {
//         return console.error(err.toString());
//     });
//     event.preventDefault();
// });

