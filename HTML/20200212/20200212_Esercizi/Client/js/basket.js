var sel = document.getElementById("selType");
var txt = document.getElementById("txtQuantity");
var pnl = document.getElementById("pnlResults");

var btn = document.getElementById("btnADD");
var print = document.getElementById("btnSTAMPA");


//url web service
var url = 'http://127.0.0.1:3000/api/basket';

// send POST request
var start = function (e) {

    var v = { "nome": sel.value, "quantita": parseInt(txt.value) };

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
};

var getDati= function(e) {
    pnl.innerHTML="<br><br>";
    fetch(url).then(function (response) {
        return response.json();
    }).then(function (data) {
        for(let i=0 ; i<data.length ; i++)
        {
            console.log(data)
            pnl.innerHTML += data[i].nome + " " + data[i].quantita + "<br>";
        }
    });
};

btn.addEventListener("click", start);
print.addEventListener("click", getDati)




