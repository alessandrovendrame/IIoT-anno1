"use strict";
exports.__esModule = true;
var fs = require("fs");
var testFolder = '../../../../Scuola';
function readConstDir() {
    fs.readdir(testFolder, function (err, files) {
        if (err) {
            return console.error(err);
        }
        files.forEach(function (file) {
            console.log(file);
        });
    });
}
exports.readConstDir = readConstDir;
