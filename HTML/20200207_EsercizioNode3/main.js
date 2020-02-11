"use strict";
exports.__esModule = true;
var u = require("./utilities/utility");
var file;
file += u.readConstDir();
console.log(file);
//====================================
/*http.createServer((req,res)=>{
    if(req.url=="/api"){
        res.writeHead(200, "application/json")
        res.end(JSON.stringify(file));
    }else{
        res.writeHead(200,"text/plain");
        res.end(JSON.stringify(file));
    }
    console.log("url: " + req.url);
}).listen(5000);*/ 
