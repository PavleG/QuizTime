"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/quizHub").build();

connection.start().then(function(){
    var pin = document.getElementById("quizID").value;
    connection.invoke("AddToQuizGroup", pin.toString()).catch(function (err) {
        return console.error(err.toString());
    })
});
connection.on("AppendNameToListOfPlayers", function (user) {
    var li = document.createElement("li");
    li.textContent = user;
    li.id = "li"+user;
    // var button = document.createElement("button");
    // button.id = user;
    // button.textContent = "Remove";
    // button.addEventListener("click", function(event){
    //     var pin = document.getElementById("quizID").value;
    //     var id = this.id;
    //     connection.invoke("RemoveFromQuiz", id, pin).catch(function (err) {
    //         return console.error(err.toString());
    //     });
    //     var parent = document.getElementById("playerList");
    //     var child = document.getElementById("li"+id);
    //     parent.removeChild(child);
    //     event.preventDefault();
    // });
    
    li.appendChild(button);
    document.getElementById("playerList").appendChild(li);
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
