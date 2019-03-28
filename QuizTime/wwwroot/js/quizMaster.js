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



function openTab(evt, tabName) {
    // Declare all variables
    var i, tabcontent, tablinks;
  
    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
      tabcontent[i].style.display = "none";
    }
  
    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
      tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
  
    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
  }
