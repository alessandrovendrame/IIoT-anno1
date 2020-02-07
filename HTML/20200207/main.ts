/*var num1 = 12;
var num2 = 34;

var result = num1+num2;

console.log(result);*/

import * as _ from 'underscore';
import * as u from './utility';
import * as http from "http";

var list = ["ciao", "its" , "alessandro", "vendrame"]

var listOrdered = _.sortBy(list, x => x);

listOrdered.forEach(s => {
    console.log(s);
});

console.log(u.add(3,7));

//====================================

http.createServer((req,res)=>{
    if(req.url=="/api"){
        res.writeHead(200, "application/json")
        res.end(JSON.stringify(list));
    }else{
        res.writeHead(200,"text/plain");
        res.end("Ciao ITS");
    }
    console.log("url: " + req.url);
}).listen(5000);

