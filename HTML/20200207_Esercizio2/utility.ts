import * as fs from 'fs';
import * as path from 'path';

const testFolder = '../../../../Scuola';

export function readConstDir(){
    fs.readdir(testFolder, (err, files) => {
        if(err){
            return console.error(err);
        }

        files.forEach(file => {
           console.log(file); 
        });
    });
}