import * as fs from 'fs';
import * as path from 'path';

const testFolder = '../../../../Scuola';

var contenitore : string;

export function readConstDir(){
    fs.readdir(testFolder, (err, files) => {
        if(err){
            return console.error(err);
        }

        files.forEach(file => {
           contenitore += file + " ";
        });

        return contenitore;
    });
}

export function getContenitore()
{
    readConstDir();
    console.log(contenitore);
    return contenitore;
}