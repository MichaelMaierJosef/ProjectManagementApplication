// Java-Script für Projektauflistung

function editProject()
{
    // Selektierten Button bekommen
    var $radio = $('input[name=projectGroup]:checked');
    // Die id vom Projekt, das ausgewählt wurde
    var projectId = $radio.attr('id');
    //alert(projectId);
    

    // HTTP-Request erstellen und in die Action eines Controllers schicken
    var xhr = new XMLHttpRequest();
    // /controller/action
    xhr.open('POST', '/Project/setIdFromJs(projectId)');
    //xhr.send(projectId);
}