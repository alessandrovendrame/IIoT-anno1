var pnlOut = document.getElementById("pnlOutput");
var btnSend = document.getElementById("btnSend");
var btnShow = document.getElementById("btnShow");
var btnShowAll = document.getElementById("btnShowAll");
var txtDesc = document.getElementById("txtDesc");
var txtAssigned = document.getElementById("txtAssignedTo");
var selStatus = document.getElementById("selStatus");
var selAssigned = document.getElementById("selAssigned");

var url = 'http://127.0.0.1:3000/api/list';

//btnSend.addEventListener("click",sendData);
//btnShowAll.addEventListener("click",getData);

document.addEventListener("DOMContentLoaded", function() {
    getPersone();
});

function sendData() {
    var v = { "description": txtDesc.value, "assignedTo": txtAssigned.value, "status": selStatus.value, "creationDate": new Date() };

    // request options
    var options = {
        method: 'POST',
        body: JSON.stringify(v),
        headers: {
            'Content-Type': 'application/json'
        }
    };

    fetch(url, options).then(function (response) {
        return response.json();
    }).then(function (data) {
        alert(data.result);
    });
    
    setTimeout(function(){ getPersone(); }, 1000)
}

function getData() {
    console.log("Sono dentro")
    fetch(url).then(function (response) {
        return response.json();
    }).then(function (data) {
        pnlOut.innerHTML="";
        for (let i = 0; i < data.length; i++) {
            console.log(data);
            var card = document.createElement("div");
            card.classList.add("card");
            card.classList.add("col-2");
            card.classList.add("m-3");
            card.setAttribute("style", "padding-right:0 ; padding-left:0" );

            var card_body = document.createElement("div");
            card_body.classList.add("card-body");

            var card_title = document.createElement("div");
            card_title.classList.add("card-header");

            var card_subtitle = document.createElement("h6");
            card_subtitle.classList.add("card-subtitle");
            card_subtitle.classList.add("mb-2");
            card_subtitle.classList.add("text-muted");

            var card_text = document.createElement("p");
            card_text.classList.add("card-text");

            var card_status = document.createElement("h6");
            card_status.classList.add("card-subtitle");
            card_status.classList.add("mb-2");
            card_status.classList.add("text-muted");

            card_text.innerHTML = data[i].description;
            card_title.innerHTML = data[i].assignedTo;
            card_subtitle.innerHTML = data[i].creationDate;
            card_status.innerHTML = "Stato: " + data[i].status;

            card_body.append(card_subtitle);
            card_body.append(card_text);
            card_body.append(card_status);

            card.append(card_title);
            card.append(card_body);

            pnlOut.append(card);
        }
    });
}

function getPersona()
{
    fetch(url+"/"+selAssigned.value).then(function (response) {
        return response.json();
    }).then(function (data) {
        pnlOut.innerHTML="";
        for (let i = 0; i < data.length; i++) {
            console.log(data);
            var card = document.createElement("div");
            card.classList.add("card");
            card.classList.add("col-2");
            card.classList.add("m-3");
            card.setAttribute("style", "padding-right:0 ; padding-left:0" );

            var card_body = document.createElement("div");
            card_body.classList.add("card-body");

            var card_title = document.createElement("div");
            card_title.classList.add("card-header");

            var card_subtitle = document.createElement("h6");
            card_subtitle.classList.add("card-subtitle");
            card_subtitle.classList.add("mb-2");
            card_subtitle.classList.add("text-muted");

            var card_text = document.createElement("p");
            card_text.classList.add("card-text");

            var card_status = document.createElement("h6");
            card_status.classList.add("card-subtitle");
            card_status.classList.add("mb-2");
            card_status.classList.add("text-muted");

            card_text.innerHTML = data[i].description;
            card_title.innerHTML = data[i].assignedTo;
            card_subtitle.innerHTML = data[i].creationDate;
            card_status.innerHTML = "Stato: " + data[i].status;

            card_body.append(card_subtitle);
            card_body.append(card_text);
            card_body.append(card_status);

            card.append(card_title);
            card.append(card_body);

            pnlOut.append(card); 
        }
    });
}

function getPersone() {
    console.log("Sono dentro")
    fetch(url + "/persone").then(function (response) {
        return response.json();
    }).then(function (data) {
        selAssigned.options.length = 0;
        for (let i = 0; i < data.length; i++) {
            console.log(data);
            selAssigned.options[selAssigned.options.length] = new Option(data[i]);
        }
    });
}

/*function printData(data)
{
    var card = document.createElement("div");
    card.classList.add("card");
    card.classList.add("col-3");

    var card_body = document.createElement("div");
    card_body.classList.add("card-body");

    var card_title = document.createElement("h5");
    card_title.classList.add("card-title");

    var card_subtitle = document.createElement("h6");
    card_subtitle.classList.add("card-subtitle");
    card_subtitle.classList.add("mb-2");
    card_subtitle.classList.add("text-muted");

    var card_text = document.createElement("p");
    card_text.classList.add("card-text");

    var card_status = document.createElement("h6");
    card_status.classList.add("card-subtitle");
    card_status.classList.add("mb-2");
    card_status.classList.add("text-muted");

    card_text.innerHTML=data.description;
    card_title.innerHTML=data.assignedTo;
    card_subtitle.innerHTML=data.creationDate;
    card_status.innerHTML = "Stato: " + data.status;

    card_body.append(card_title);
    card_body.append(card_subtitle);
    card_body.append(card_text);
    card_body.append(card_status);

    card.append(card_body);

    pnlOut.append(card);
}*/
