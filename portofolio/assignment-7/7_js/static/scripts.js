/**
 * Assignment 7
 */

/** Load the list of albums */
async function listAlbums() {
    // TODO make an AJAX request to /albums
    // then populate the "albums_list" list with the results
    let reply = await fetch("/albums")
    if (reply.status == 200) {
        let album = await reply.json();
        console.log(album);
        let listeAlbum = document.getElementById("albums_list");
        for (let i of album) {
            let aEl = document.createElement("a");
            let liEl = document.createElement("li");
            liEl.innerHTML = i.Artist;
            aEl.id = parseInt(i.albumNr);
            aEl.href = "#";
            aEl.onclick = function () {
                showAlbum(parseInt(i.albumNr), i.bilde)
            };
            aEl.append(liEl);
            listeAlbum.append(aEl);
        }
    }
}

/** Show details of a given album */
async function showAlbum(album_id, imgSrc) {
    // TODO make an AJAX request to /albuminfo with the selected album_id as parameter (i.e., /albuminfo?album_id=xxx),
    // then show the album cover in the "album_cover" div and display the tracks in a table inside the "album_songs" div
    let reply = await fetch("/albuminfo?album_id=" + album_id);
    if (reply.status == 200){
        let track = await reply.json();

        console.log(track);

        var songs = document.getElementById("album_songs");
        var cover = document.getElementById("album_cover");

        songs.innerHTML = "";
        cover.innerHTML = "";

        let imgEl = document.createElement("img");
        imgEl.src = "../static/images/" + imgSrc;

        cover.appendChild(imgEl);

        let table = document.createElement("table");
        let tHead = document.createElement("thead");
        let tBody = document.createElement("tbody");

        let tr = document.createElement("tr");
        let songNrTitle = document.createElement("th");
        let titleTitle = document.createElement("th");
        let durationTitle = document.createElement("th");

        songNrTitle.innerHTML = "No.";
        titleTitle.innerHTML = "Title";
        durationTitle.innerHTML = "Length";

        tr.appendChild(songNrTitle);
        tr.appendChild(titleTitle);
        tr.appendChild(durationTitle);
        console.log(tr);
        tHead.appendChild(tr);


        let sec = 0;
        let min = 0;
        let n = 1;

        for (let obj of track){
            console.log(obj);

            let tr2 = document.createElement("tr");
            let songNr = document.createElement("td");
            let title = document.createElement("td");
            let duration = document.createElement("th");

            songNr.innerHTML = n;
            title.innerHTML = obj.song;
            duration.innerHTML = obj.durationSong;

            tr2.appendChild(songNr);
            tr2.appendChild(title);
            tr2.appendChild(duration);
            tBody.appendChild(tr2);

            let timeCalc = (obj.durationSong || '').split(':');
            min += parseInt(timeCalc[0]);
            sec += parseInt(timeCalc[1]);

            if (sec > 60) {
                console.log("runde " + n)
                console.log("sec: "+sec);
                console.log("min: "+min);

                let antallMin = (sec/60);
                console.log("antallMin " + antallMin);
                antallMin = Math.floor(antallMin);
                console.log("antallMin " + antallMin);
                min += antallMin;
                sec -= 60 * antallMin;

                console.log("sec: "+sec);
                console.log("min: "+min);
            }

            n++;
        }


        let tr3 = document.createElement("tr");
        let durationBot = document.createElement("th");
        let space = document.createElement("th");
        let durationCalc = document.createElement("th");

        durationBot.innerHTML = "Total length:";
        space.innerHTML = "";
        durationCalc.innerHTML = min + ":" + sec;

        tr3.appendChild(durationBot);
        tr3.appendChild(space);
        tr3.appendChild(durationCalc);
        tBody.appendChild(tr3);

        table.appendChild(tBody);
        table.appendChild(tHead);

        console.log(tBody);
        console.log(tHead);
        console.log(table);

        songs.appendChild(table);
    }

}