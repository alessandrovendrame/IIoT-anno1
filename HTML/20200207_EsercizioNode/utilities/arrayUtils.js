"use strict";
exports.__esModule = true;
var _ = require("underscore");
function getList(count) {
    var list = [];
    for (var i = 0; i < count; i++) {
        list[i] = i + 1;
    }
    return list;
}
exports.getList = getList;
function taken(l, num) {
    var list = [];
    for (var index = 0; index < num; index++) {
        list[index] = l[index];
    }
    return list;
}
exports.taken = taken;
function sortReverse(l) {
    var aux = _.sortBy(l, function (x) { return x; });
    var array = [];
    var j = 0;
    for (var i = l.length - 1; i > -1; i--) {
        array[j] = aux[i];
        j++;
    }
    return array;
}
exports.sortReverse = sortReverse;
function getEven(l) {
    var aux = [];
    var j = 0;
    for (var i = 0; i < l.length; i++) {
        if (i % 2 == 0) {
            aux[j] = l[i];
            j++;
        }
    }
    return aux;
}
exports.getEven = getEven;
