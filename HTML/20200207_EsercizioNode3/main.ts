import * as _ from 'underscore';
import * as u from './utilities/utility';
import * as http from "http";

var file : string;
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