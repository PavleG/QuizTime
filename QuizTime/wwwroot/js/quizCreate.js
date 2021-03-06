$("#submitButton").closest("form").submit(function() {
    var table = $("#resultTable");
    var rowNum = parseInt($("#table-row-num").val(), 10);
    var resultHtml = '';

    for(var i = 0 ; i < rowNum ; i++) {
        resultHtml += ["<tr>", 
         "<td>", 
          (i+1),
         "</td>",
         '<td><input type="name" asp-for="QuestionFormulation" placeholder="Unesi pitanje"></td>',
         '<td><input type="name" asp-for="CorrectAnswer" placeholder="Unesi tacan odgovor"></td>',
         '<td><input type="name" asp-for="WrongAnswer" placeholder="Unesi pogresan odgovor"></td>',
         '</tr>'].join("\n");
         }  

    table.html(resultHtml);
    return false; 
});