"use strict";

// write JS code here.

let entry = [
        {nameEntry: "Lars", tlfEntry: "94678245", emailEntry: "Lars@gmail.com"},
        {nameEntry: "Tore", tlfEntry: "97953485", emailEntry: "Tore@gmail.com"},
        {nameEntry: "Mari", tlfEntry: "92468956", emailEntry: "Mari@gmail.com"}
];


function showentry() {
    let openentry = document.getElementById("add_entry");
    openentry.style.display = "block";
}

function closeentry() {
    let closeentry = document.getElementById("add_entry");
    closeentry.style.display = "none";
}

function showeditentry() {
    let openentry = document.getElementById("edit_entry");
    openentry.style.display = "block";
}

function closeeditentry() {
    let closeentry = document.getElementById("edit_entry");
    closeentry.style.display = "none";
}

function showsettings() {
    let openentry = document.getElementById("settings");
    openentry.style.display = "block";
}

function closesettings() {
    let closeentry = document.getElementById("settings");
    closeentry.style.display = "none";
}

function AddEntry() {
    let name = document.getElementById("addname").value;
    let tlf = document.getElementById("addtel").value;
    let email = document.getElementById("addemail").value;
    
    let person = {nameEntry: name, tlfEntry: tlf, emailEntry: email};

    entry.push(person);

    // sett inn filter

    printme();
}

let showid = document.getElementById("show");

function printme() {
    showid.innerHTML = "";

    for(let i = 0; i < entry.length; i++) {

        let tableEl = document.createElement("table");
        let trEl1 = document.createElement("tr");
        let tdName = document.createElement("td");
        let trEl2 = document.createElement("tr");
        let tdTlf = document.createElement("td");
        let tdDeleteButton = document.createElement("td");

        let trEl3 = document.createElement("tr");
        let tdEmail = document.createElement("td");

        tdName.innerHTML = "<h2>" + entry[i].nameEntry + "</h2>";
        tdTlf.innerHTML = entry[i].tlfEntry
        tdDeleteButton.innerHTML = "<button id='delete_entry' type='button' onclick='DeleteEntry(" + i + ")'><i class='material-icons' style='color: black; font-size: 20px'>delete</i></button>";
        tdEmail.innerHTML = "<a href='mailto:" + entry[i].emailEntry + "'>" + entry[i].emailEntry + "</a>";

        tdName.classList = searchname;
        tdTlf.classList = searchtlf;
        tdEmail.classList = searchemail;

        trEl1.appendChild(tdName);
        trEl2.appendChild(tdTlf);
        trEl2.appendChild(tdDeleteButton);
        trEl3.appendChild(tdEmail);

        tableEl.appendChild(trEl1);
        tableEl.appendChild(trEl2);
        tableEl.appendChild(trEl3);

        tableEl.id = i;

        showid.appendChild(tableEl);
    }
       /*
        showid.innerHTML +=
            "<table id='" + i + "'>" +
            "<tr>"
                + "<td class='searchname'><h2>" + entry[i].nameEntry + "</h2></td>"
            + "</tr>"

            + "<tr>"
                + "<td class='searchtlf'>" + entry[i].tlfEntry + "</td>"
                + "<td><button id='delete_entry' type='button' onclick='DeleteEntry(" + i + ")'><i class='material-icons' style='color: black; font-size: 20px'>delete</i></button></td>"
            + "</tr>"

            + "<tr>"
                + "<td class='searchemail'><a href='mailto:" + entry[i].emailEntry + "'>" + entry[i].emailEntry + "</a></td>"
            + "</tr>"
            + "</table>";

    */
}

function DeleteEntry(entry) {
    var result = window.confirm("You are about to delete a contact, do you want too procede?")
    if (result===true) {
        var id = document.getElementById(entry)
        id.parentNode.removeChild(id);
    }
}

function searchcontact() {
	let input = document.getElementById('search').value
	let x = document.getElementsByClassName('searchname');
    let y = document.getElementsByClassName('searchtlf');
    let z = document.getElementsByClassName('searchemail');
	
	for (let i = 0; i < x.length; i++) {
		if (!x[i].innerHTML.includes(input)) {
			x[i].parentNode.parentNode.style.display="none";
            x[i].parentNode.parentNode.parentNode.style.display="border: none;";
		}
		else {
			x[i].parentNode.parentNode.style.display="";				
		}
	}

    for (let i = 0; i < y.length; i++) {
		if (!y[i].innerHTML.includes(input)) {
			y[i].parentNode.parentNode.style.display="none";
            y[i].parentNode.parentNode.parentNode.style.display="border: none";
		}
		else {
			y[i].parentNode.parentNode.style.display="";				
		}
	}

    for (let i = 0; i < z.length; i++) {
		if (!z[i].innerHTML.includes(input)) {
			z[i].parentNode.parentNode.style.display="none";
            z[i].parentNode.parentNode.parentNode.style.display="border: none";
		}
		else {
			z[i].parentNode.parentNode.style.display="";				
		}
	}

}

function setting() {
    let table = document.getElementById("entrys");
    let ff = document.getElementById("font");
    table.style.fontFamily = ff.value;

    let fs = document.getElementById("size");
    table.style.fontSize = fs.value;

    let bc = document.getElementById("color");
    table.style.backgroundColor = bc.value;
}