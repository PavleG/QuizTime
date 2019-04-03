"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/quizHub").build();

document.getElementById("joinButton").disabled = true;

connection.start().then(function(){
    document.getElementById("joinButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("joinButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var pin = document.getElementById("pinInput").value;
    connection.invoke("JoinQuiz", user, pin).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

connection.on("Wait", function(){
    alert("Waiting for others to join");
});

connection.on("Removed", function(){
    alert("You have been removed from the quiz!");
});