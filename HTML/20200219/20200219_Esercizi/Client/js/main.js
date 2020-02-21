var pnlOut = document.getElementById("pnlOutput");
var btnSend = document.getElementById("btnSend");
var btnShow = document.getElementById("btnShow");
var btnShowAll = document.getElementById("btnShowAll");
var txtName = document.getElementById("txtName");
var txtLastName = document.getElementById("txtLastName");
var selClass = document.getElementById("selClass");
var selStudent = document.getElementById("selStudent");

var url = 'http://127.0.0.1:3000/students';

//btnSend.addEventListener("click",sendData);
//btnShowAll.addEventListener("click",getData);

document.addEventListener("DOMContentLoaded", function() {
    getPersone();
});

function sendData() {
    var v = { "firstname": txtName.value, "lastname": txtLastName.value, "class": selClass.value};

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
    
    setTimeout(function(){ getPersone(); }, 1000);
}

function getData() {
    console.log("Sono dentro")
    fetch(url).then(function (response) {
        return response.json();
    }).then(function (data) {
        pnlOut.innerHTML="";
        for (let i = 0; i < data.length; i++) {
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
            card_subtitle.setAttribute("style","color:white");

            var card_text = document.createElement("p");
            card_text.classList.add("card-text");

            var card_age = document.createElement("p");
            card_age.classList.add("card-text");

            var btnDel = document.createElement("input");
            btnDel.setAttribute("type", "submit");
            btnDel.classList.add("btn-primary");
            btnDel.value = "Elimina";

            if(data[i].class=="First")
            {
                card.classList.add("bg-success");
            }else if(data[i].class=="Second")
            {
                card.classList.add("bg-warning");
            }else if(data[i].class=="Third")
            {
                card.classList.add("bg-secondary");
            }

            btnDel.addEventListener("click",function(){
                
                var v = { "studentid": data[i].studentid };

                // request options
                var options = {
                    method: 'POST',
                    body: JSON.stringify(data[i].studentid),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                };
            
                fetch(url+"/delete", options).then(function (response) {
                    return response.json();
                }).then(function (data) {
                    alert(data.result);
                });

                setTimeout(function(){ getData(); }, 500);
            });

            card_title.innerHTML = "ID: " + data[i].studentid;
            card_text = data[i].firstname + " " + data[i].lastname;
            card_subtitle.innerHTML = "Class: " + data[i].class;
            card_age.innerHTML = "Age: " + data[i].age;

            card_body.append(card_text);
            card_body.append(card_age);
            card_body.append(card_subtitle);
            card_body.append(btnDel);

            card.append(card_title);
            card.append(card_body);

            pnlOut.append(card);
        }
    });
}

function getPersona()
{
    fetch(url+"/"+selStudent.value).then(function (response) {
        return response.json();
    }).then(function (data) {
        pnlOut.innerHTML="";
        for (let i = 0; i < data.length; i++) {
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

            var card_age = document.createElement("p");
            card_age.classList.add("card-text");

            var btnDel = document.createElement("input");
            btnDel.setAttribute("type", "submit");
            btnDel.classList.add("btn-primary");
            btnDel.value = "Elimina";

            btnDel.addEventListener("click",function(){
                
                var v = { "studentid": data[i].studentid };

                // request options
                var options = {
                    method: 'POST',
                    body: JSON.stringify(data[i].studentid),
                    headers: {
                        'Content-Type': 'application/json'
                    }
                };
            
                fetch(url+"/delete", options).then(function (response) {
                    return response.json();
                }).then(function (data) {
                    alert(data.result);
                });

                setTimeout(function(){ getData(); }, 500);
            });

            card_title.innerHTML = "ID: " + data[i].studentid;
            card_text = data[i].firstname + " " + data[i].lastname;
            card_subtitle.innerHTML = "Class: " + data[i].class;
            card_age.innerHTML = "Age: " + data[i].age;

            card_body.append(card_text);
            card_body.append(card_age);
            card_body.append(card_subtitle);
            card_body.append(btnDel);

            card.append(card_title);
            card.append(card_body);

            pnlOut.append(card);
        }
    });
}

function getPersone() {
    console.log("Sono dentro")
    fetch(url + "/classes").then(function (response) {
        return response.json();
    }).then(function (data) {
        selStudent.options.length = 0;
        for (let i = 0; i < data.length; i++) {
            console.log(data[i]);
            selStudent.options[selStudent.options.length] = new Option(data[i].class);
        }
    });
}