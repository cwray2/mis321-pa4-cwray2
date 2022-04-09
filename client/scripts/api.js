const baseUrl = "https://localhost:5001/api/songs";
var songList = [];
var mySong = {};

function populateList() {
    const allSongsApiUrl = baseUrl;
    fetch(allSongsApiUrl).then(function(response) {
        return response.json();
    }).then(function(json) {
        songList = json;
        //let html = "<select class = \"listBox\" onChange = \"handleOnChange()\" id = \"selectListBox\" name = \"list_box\" size=5 width = \"100%\">";
        let html = '<div class="card col-md-4 bg-dark text-white"><img src="./images/music.jpeg" class="card-img" alt="..."><div class="card-img-overlay"><h5 class="card-title">'+song.songTitle+'</h5><button id='+song.songID+' class="unliked-button" onclick="likeSongs(id)">🍆💦</button><button id='+song.songID+' onclick="deleteSongs(id)">🗑️</button></div></div>';
        json.forEach((song) => {
            html += "<option value = " + song.songID + ">" + song.songTitle + "</option>";
        })
        html += "</select>";
        document.getElementById("listBox").innerHTML = html;
    }).catch(function(error) {
        console.log(error);
    });
}

function putSong(id){
    const putSongApiUrl = baseUrl + "/" + id;
    const sendSong = {
        id: id,
        title: document.getElementById("songTitle").value,
    }
    fetch(putSongApiUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(sendSong)
    })
    .then((response)=>{
        mySong = sendSong;
        populateList();
        populateForm();
    });
}

function postSong(){
    const postSongApiUrl = baseUrl;
    const sendSong = {
        songTitle: document.getElementById("songTitle").value,
    }
    fetch(postSongApiUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        },
        body: JSON.stringify(sendSong)
    })
    .then((response)=>{
        mySong = sendSong;
        populateList();
        blankFields();
    });
}

function deleteSong(){
    const deleteSongApiUrl = baseUrl + "/" + mySong.songID;
    fetch(deleteSongApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        }
    })
    .then((response)=>{
        blankFields();
        populateList();
    });
}