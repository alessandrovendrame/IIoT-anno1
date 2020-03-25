//import * as io from "socket.io-client";

var socket = io.connect('http://localhost:3000');
var btnSend = document.getElementById("btnSend") as HTMLInputElement;
var txtMex = document.getElementById("txtMessaggio") as HTMLInputElement;

socket.on("message", function(message){
    alert('Il server dice: ' + message);
    console.log(message);
});

btnSend.addEventListener("click",() => {
    socket.emit('message', txtMex.value);
});

