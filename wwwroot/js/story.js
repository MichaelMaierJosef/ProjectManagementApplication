
function showDetail() {
    document.querySelector('.bg-modal').style.display = 'flex';
}


function hideDetail() {
    document.querySelector('.bg-modal').style.display = 'none';
}


function showDetailAdd() {
    document.querySelector('.add-modal').style.display = 'flex';
}

function hideDetailAdd() {
    document.querySelector('.add-modal').style.display = 'none';
}


// when file is inside the drag area
function dragEnter(current) {
    event.preventDefault();
    document.getElementById(current).style.border = '2px dashed #1683ff';
    document.getElementById(current).innerText = "Release to Upload";
}

// when file is leaves the drag area
function dragLeave(current) {
    event.preventDefault();
    document.getElementById(current).style.border = '2px solid #6f7275';
    document.getElementById(current).innerText = "Drag & Drop";
}

var idList = [];
var imgCount = 1;

// when file is dropped in the drag area
function dragDropped(current) {
    if (current == 0) {
        var dragArea = document.getElementById(1);
        let fileURL = document.getElementById("imgURLs").value;
            let imgTag = `<img class="usImage" src="${fileURL}">`
            dragArea.innerHTML = imgTag;
            document.getElementById(1).style.border = '2px solid #6f7275';
            if (idList.includes(1) == false && idList.length < 0) {
                idList.push(imgCount);
                imgCount++;
                var insertOption =
                    `<div id="${imgCount}" class="anhang" ondragleave="dragLeave(${imgCount})" ondrop="dragDropped(${imgCount})" ondragover="dragEnter(${imgCount})">
                <h3>Upload your Image</h3>
                <div id="drag-area" class="drag-area">
                    <div class="icon">
                        <i class="fas fa-images"></i>
                    </div>
                    <span id="text" class="header">Drag & Drop</span></br>
                <span class="support">Supports: JPEG, JPG, PNG</span>
            </div>
        </div>`;
                document.getElementById("imagecontainer").insertAdjacentHTML("afterbegin", insertOption);
                var wi = document.getElementById("imagecontainer").offsetWidth;
                var helpwi = parseInt(wi) + 300;
                document.getElementById("imagecontainer").style.width = helpwi + 'px';

            }
        
    }

    else {
        var dragArea = document.getElementById(current);
        event.preventDefault();
        file = event.dataTransfer.files[0];
        let fileType = file.type;
        let validExtensions = ['image/jpeg', "image/jpg", "image/PNG", "image/png", "image/JPG", "image/JPEG"];

        if (validExtensions.includes(fileType)) {
            let fileReader = new FileReader();
            fileReader.onload = () => {
                let fileURL = fileReader.result;
                //alert(fileURL);
                document.getElementById("invIMGid").innerText = fileURL;
                document.getElementById("imgURLs").value = fileURL;
                let imgTag = `<img class="usImage" src="${fileURL}">`
                dragArea.innerHTML = imgTag;
                document.getElementById(current).style.border = '2px solid #6f7275';
                if (idList.includes(current) == false && idList.length < 0) {
                    idList.push(imgCount);
                    imgCount++;
                    var insertOption =
                        `<div id="${imgCount}" class="anhang" ondragleave="dragLeave(${imgCount})" ondrop="dragDropped(${imgCount})" ondragover="dragEnter(${imgCount})">
                    <h3>Upload your Image</h3>
                    <div id="drag-area" class="drag-area">
                        <div class="icon">
                            <i class="fas fa-images"></i>
                        </div>
                        <span id="text" class="header">Drag & Drop</span></br>
                    <span class="support">Supports: JPEG, JPG, PNG</span>
                </div>
            </div>`;
                    document.getElementById("imagecontainer").insertAdjacentHTML("afterbegin", insertOption);
                    var wi = document.getElementById("imagecontainer").offsetWidth;
                    var helpwi = parseInt(wi) + 300;
                    document.getElementById("imagecontainer").style.width = helpwi + 'px';

                }
            };
            fileReader.readAsDataURL(file);
        } else {
            alert('This file is not an Image');
            document.getElementById(current).style.border = '2px solid #6f7275';
        }
    }
}

var usedIDs = [0,1,2,3];

function deleteUserStory() {

    var list = document.getElementById("listUl");

    for (var i = usedIDs.length -1 ; i >= 0; i--) {
        var cBox = document.getElementById("c" + usedIDs[i]).checked;
        if (cBox) {
            document.getElementById("dus" + usedIDs[i]).innerHTML = "";
            usedIDs.splice(usedIDs[i], 1);
        }
    }
}

// Functions to set the data, which will be displayed in an userstory
function showDetailMore(title, sid, desc, usname, imgurl, state, snumber) {
    // UserStory Popup
    document.getElementById("title").value = title;
    document.querySelector('.bg-modal').style.display = 'flex';
    $("#userStoryContent").val(desc);
    document.getElementById("usname").innerText = usname + ': US' + snumber;
    document.getElementById("usnameInp").value = usname;
    document.getElementById("storyId").value = sid;
    document.getElementById("storyState").value = state;
    document.getElementById("imgURLs").value = imgurl;
    document.getElementById("storyNumber").value = snumber;
    
    dragDropped(0);
}

function setTaskName(currentProId) {
    $(document).ready(function () {
        $.ajax({
            type: "POST",
            url: "/Task/SetTask",
            data: {
                "taskname": document.getElementById("newTaskInput").value,
                "storyID": document.getElementById("storyId").value,
                "projectID": currentProId
            },
            success: function (response) {
                $(response).each(function () {
                    //alert("Hello" + this.taskname);
                })
            },
            failure: function (response) {
                //alert(response.responseText);
            },
            error: function (response) {
                //alert(response.responseText);
            }
        });
    });
}

function loadTaskIndex() {
    $(document).ready(function () {
        $.ajax({
            type: "POST",
            url: "/Task/Index",
            data: {
                "userstoryid": document.getElementById("storyId").value
            },
            success: function (response) {
                $(response).each(function () {
                    //alert("Hello" + this.taskname);
                })
            },
            failure: function (response) {
                //alert(response.responseText);
            },
            error: function (response) {
                //alert(response.responseText);
            }
        });
    });
}
function filterlist() {
    var input, filter, li, a, i, txtValue;
    input = document.getElementById("keyWordInput");
    filter = input.value.toUpperCase();
    li = document.getElementsByTagName("li");
    for (i = 0; i < li.length; i++) {
        a = li[i].getElementsByTagName("a")[0];
        txtValue = a.innerText;
        if (txtValue.toUpperCase().indexOf(filter) > -1) {
            li[i].style.display = "";
        } else {
            li[i].style.display = "none";
        }
    }

    

}
