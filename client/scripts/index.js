var mySong = {};
function handleOnLoad() {
    populateList();
}

function handleOnChange(){
    const selectedId = document.getElementById("selectListBox").value;
    songList.forEach((song)=>{
        if(song.songID == selectedId){
            mySong = song;
        }
    });

    populateForm();
}

function handleEditClick(){
    makeEditable();
    hideButtons();
    var buttonHtml = "<button class=\"btn btn-primary btn-lg\" onclick=\"handleEditSave("+mySong.songID+")\">Save</button>";
    buttonHtml += "<button class=\"btn btn-warning btn-lg btn-cancel\" onclick=\"handleCancelSave()\">Cancel</button>";
    document.getElementById("saveButton").innerHTML = buttonHtml;
    document.getElementById("saveButton").style.display = "inline-block";
}

function handleNewClick(){
    makeEditable();
    hideButtons();
    blankFields();
    var buttonHtml = "<button class=\"btn btn-primary btn-lg\" onclick=\"handleNewSave("+mySong.songID+")\">Save</button>";
    buttonHtml += "<button class=\"btn btn-warning btn-lg btn-cancel\" onclick=\"handleCancelSave()\">Cancel</button>";
    document.getElementById("saveButton").innerHTML = buttonHtml;
    document.getElementById("saveButton").style.display = "inline-block";
}


function handleDeleteClick(){
    deleteSong();
}

function handleCancelSave(){
    populateForm();
    makeReadOnly();
    showButtons();
}

function handleEditSave(id){
    putSong(id);
    makeReadOnly();
    showButtons();
}

function handleNewSave(){
    postSong();
    makeReadOnly();
    showButtons();
    blankFields();
}



function populateForm(){
    document.getElementById("songTitle").value = mySong.songTitle;
}

function hideButtons(){
    document.getElementById("newButton").style.display = "none";
    document.getElementById("editButton").style.display = "none";
    document.getElementById("deleteButton").style.display = "none";
}

function showButtons(){
    document.getElementById("newButton").style.display = "inline-block";
    document.getElementById("editButton").style.display = "inline-block";
    document.getElementById("deleteButton").style.display = "inline-block";
    document.getElementById("saveButton").style.display = "none";
}

function makeEditable(){
    document.getElementById("songTitle").readOnly=false;
}

function blankFields(){
    document.getElementById("songTitle").value="";
}

function makeReadOnly(){
    document.getElementById("songTitle").readOnly=true;
}