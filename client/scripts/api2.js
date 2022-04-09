const baseUrl = "https://localhost:5001/api/songs";
var songList = [];
var mySong = {};

function populateList() {
    const allSongsApiUrl = baseUrl;
    fetch(allSongsApiUrl).then(function(response) {
        return response.json();
    }).then(function(json) {
        songList = json;
        let html = `<div class="row">`;
        //let html = "<select class = \"listBox\" onChange = \"handleOnChange()\" id = \"selectListBox\" name = \"list_box\" size=5 width = \"100%\">";
        //let html = '<div class="card col-md-4 bg-dark text-white"><img src="./images/music.jpeg" class="card-img" alt="..."><div class="card-img-overlay"><h5 class="card-title">'+song.songTitle+'</h5><button id='+song.songID+' class="unliked-button" onclick="likeSongs(id)">🍆💦</button><button id='+song.songID+' onclick="deleteSongs(id)">🗑️</button></div></div>';
        json.forEach((song) => {
            console.log(song.songTitle)
            // html += `<div class="m-1">`
            if(song.favorited == "y"){
                html += `<div class="card col-md-4 bg-dark text-white">`;
                html += `<img src="./images/music.jpeg" class="card-img" alt="...">`;
                html += `<div class="card-img-overlay">`;
                html += `<h5 class="card-title">`+song.songTitle+`</h5>`;
                html += `<button id=`+song.songID+` class="liked-button" onclick="unlikeSongs(id)">❤️</button><button id=`+song.songID+` onclick="deleteSong(id)">🚽</button>`;
                html += `</div>`;
                // html += `</div>`;
                html += `</div>`;
            }
            if(song.favorited == "n"){
                html += `<div class="card col-md-4 bg-dark text-white">`;
                html += `<img src="./images/music.jpeg" class="card-img" alt="...">`;
                html += `<div class="card-img-overlay">`;
                html += `<h5 class="card-title">`+song.songTitle+`</h5>`;
                html += `<button id=`+song.songID+` class="unliked-button" onclick="likeSongs(id)">♡</button><button id=` + song.songID + ` onclick="deleteSong(id)">🚽</button>`;
                html += `</div>`;
                // html += `</div>`;
                html += `</div>`;
            }
        });

        html += '</div>'

        // if (html === ``) {
        //     html = "No songs found :("
        // }
        document.getElementById("cards").innerHTML = html;
    }).catch(function(error) {
        console.log(error);
    });
}

function deleteSong(id){
    const deleteSongApiUrl = baseUrl + "/" + id;
    fetch(deleteSongApiUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type": 'application/json',
        }
    })
    .then((response)=>{
        populateList();
    });
}

function postSong(){
    const postSongApiUrl = baseUrl;
    const sendSong = {
        songTitle: document.getElementById("title").value,
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
        //mySong = sendSong;
        populateList();
        blankFields();
    });
}