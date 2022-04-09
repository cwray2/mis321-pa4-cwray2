var mySong = {};
function findSongs(){
    var url = "https://www.songsterr.com/a/ra/songs.json?pattern="
    let searchString = document.getElementById("searchSong").value;

    url += searchString;

    console.log(searchString)

    fetch(url).then(function(response) {
		console.log(response);
		return response.json();
	}).then(function(json) {
        console.log(json)
        let html = ``;
		json.forEach((song) => {
            console.log(song.title)
            html += `<div class="card col-md-4 bg-dark text-white">`;
			html += `<img src="./images/music.jpeg" class="card-img" alt="...">`;
			html += `<div class="card-img-overlay">`;
			html += `<h5 class="card-title">`+song.title+`</h5>`;
            html += `</div>`;
            html += `</div>`;
		});
		
        if(html === ``){
            html = "No Songs found :("
        }
		document.getElementById("searchSongs").innerHTML = html;

	}).catch(function(error) {
		console.log(error);
	})
}

function blankFields(){
    document.getElementById("title").value="";
}

function likeSongs(id){

    var targetButton = document.getElementById(id);
    console.log(targetButton.outerHTML);
    var html = '<button id='+id+' class="liked-button" onclick="unlikeSongs(id)">❤️</button>' //changing like button
    targetButton.outerHTML = html;
    fetch(baseUrl + '/' + id, {
    method: "PUT",
    headers: {
        "Accept": 'application/json',
        "Content-Type": 'application/json',
        },
    });
}

function unlikeSongs(id){
    console.log(id);
    var targetButton = document.getElementById(id);
    console.log(targetButton.outerHTML);
    var html = '<button id='+id+' class="unliked-button" onclick="likeSongs(id)">♡</button>' //changing like button
    targetButton.outerHTML = html;
    fetch(baseUrl + '/' + id, {
    method: "PUT",
    headers: {  
        "Accept": 'application/json',
        "Content-Type": 'application/json',
        },
    });
}

function handleAddClick(){
    document.getElementById("add").value;
    postSong();
    blankFields();
}