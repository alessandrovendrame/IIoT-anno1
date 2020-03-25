"use strict";
exports.__esModule = true;
var fastify = require("fastify");
var socket = require("socket.io");
var app = fastify({ logger: true });
var io = socket.listen(app.server);
io.sockets.on('connection', function (socket) {
    console.log('Nuovo visitatore connesso!');
    socket.emit('message', 'Sei collegato con il server!');
    socket.on('message', function (message) {
        console.log('Un utente ha scritto: ' + message);
        socket.broadcast.emit('message', message);
    });
});
app.listen(3000, function (err, address) {
    if (err)
        throw err;
    app.log.info('server listening on' + address);
});
