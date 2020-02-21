"use strict";
exports.__esModule = true;
var fastify = require("fastify");
var cors = require("fastify-cors");
var mysql = require("mysql");
var connection = mysql.createPool({
    connectionLimit: 10,
    host: 'localhost',
    user: 'root',
    password: 'Vmware1!',
    database: 'school',
    insecureAuth: true
});
var app = fastify({ logger: true });
app.register(cors);
app.get("/students", function (request, reply) {
    connection.query("select studentid,firstname, lastname, class,age from students", function (error, results, fields) {
        app.log.info(results);
        app.log.info(fields);
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
        reply.send(results);
    });
});
app.get('/students/classes', function (request, reply) {
    console.log("RICHIESTA CLASSI!");
    connection.query("select distinct class from students", function (error, results, fields) {
        app.log.info(results);
        app.log.info(fields);
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
        reply.send(results);
    });
});
app.get('/students/:class', function (request, reply) {
    var classe = request.params["class"];
    connection.query("select studentid,firstname,lastname,class,age from students where class = ?", classe, function (error, results, fields) {
        app.log.info(results);
        app.log.info(fields);
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
        reply.send(results);
    });
});
app.listen(3000, function (err, address) {
    if (err)
        throw err;
    app.log.info('server listening on' + address);
});
app.post('/students', function (request, reply) {
    app.log.info("Richiesta effettuata");
    var studente = request.body;
    connection.query("INSERT INTO students SET ?", studente, function (error, results, fields) {
        app.log.info(results);
        app.log.info(fields);
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
    });
});
app.post("/students/delete", function (request, reply) {
    var id_studente = request.body;
    console.log(id_studente);
    connection.query("DELETE FROM students WHERE studentid = ?", id_studente, function (error, results, fields) {
        app.log.info(results);
        app.log.info(fields);
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
    });
});
