"use strict";
exports.__esModule = true;
var fastify = require("fastify");
var cors = require("fastify-cors");
var app = fastify({ logger: true });
var list = [];
var list1 = [];
app.register(cors, {
    methods: "GET,POST"
});
app.get('/', function (req, reply) {
    reply.send("Ciao ITS");
});
app.get('/api/list', function (request, reply) {
    console.log("RICHIESTA GET!");
    reply.send(list);
});
app.get('/api/list/persone', function (request, reply) {
    console.log("RICHIESTA PERSONE!");
    getTotalItems();
    reply.send(list1);
});
app.get('/api/list/:assignedTo', function (request, reply) {
    var list2 = [];
    var assigned = request.params.assignedTo;
    for (var i = 0; i < list.length; i++) {
        if (list[i].assignedTo == assigned) {
            list2.push(list[i]);
        }
    }
    reply.send(list2);
});
app.post('/api/list', function (request, reply) {
    app.log.info("Richiesta effettuata");
    var thing = request.body;
    console.log(thing);
    list.push(new toDo(thing.description, thing.assignedTo, thing.status, thing.creationDate));
    console.log(list);
});
app.listen(3000, function (err, address) {
    if (err)
        throw err;
    app.log.info('server Listening on ${address}');
});
var toDo = /** @class */ (function () {
    function toDo(description, assignedTo, status, creationDate) {
        this.description = description;
        this.assignedTo = assignedTo;
        this.status = status;
        this.creationDate = creationDate;
    }
    return toDo;
}());
function getTotalItems() {
    list1 = [];
    for (var i = 0; i < list.length; i++) {
        var item = list[i];
        var exist = false;
        for (var j = 0; j < list1.length; j++) {
            var element = list1[j];
            if (element == item.assignedTo) {
                exist = true;
            }
        }
        if (!exist)
            list1.push(item.assignedTo);
    }
}
