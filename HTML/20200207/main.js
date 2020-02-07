"use strict";
/*var num1 = 12;
var num2 = 34;

var result = num1+num2;

console.log(result);*/
exports.__esModule = true;
var _ = require("underscore");
var u = require("./utility");
var http = require("http");
var list = ["ciao", "its", "alessandro", "vendrame"];
var listOrdered = _.sortBy(list, function (x) { return x; });
listOrdered.forEach(function (s) {
    console.log(s);
});
console.log(u.add(3, 7));
//====================================
http.createServer(function (req, res) {
    if (req.url == "/api") {
        res.writeHead(200, "application/json");
        res.end(JSON.stringify(list));
    }
    else {
        res.writeHead(200, "text/plain");
        res.end("Ciao ITS programma di Vendrame");
    }
    console.log("url: " + req.url);
}).listen(5000);
