"use strict";
exports.__esModule = true;
var fs = require("fs");
var testFolder = '../../../../Scuola';
var contenitore;
function readConstDir() {
    fs.readdir(testFolder, function (err, files) {
        if (err) {
            return console.error(err);
        }
        files.forEach(function (file) {
            contenitore += file + " ";
        });
        return contenitore;
    });
}
exports.readConstDir = readConstDir;
function getContenitore() {
    readConstDir();
    console.log(contenitore);
    return contenitore;
}
exports.getContenitore = getContenitore;
