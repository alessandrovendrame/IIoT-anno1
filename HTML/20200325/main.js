"use strict";
exports.__esModule = true;
var fastify = require("fastify");
var staticFile = require("fastify-static");
var pointOfView = require("point-of-view");
var path = require("path");
var mysql = require("mysql");
var app = fastify({
    logger: true
});
var connection = mysql.createPool({
    connectionLimit: 10,
    host: 'localhost',
    user: 'root',
    password: 'Vmware1!',
    database: 'dbUsers',
    insecureAuth: true
});
app.register(pointOfView, {
    engine: {
        ejs: require('ejs')
    }
});
app.register(require("fastify-formbody"));
// app.register(staticFile, {
//     root: path.join(__dirname, '/css'),
//     prefix: '/css/',
// });
// gestione cartella css
app.register(function (instance, opts, next) {
    instance.register(staticFile, {
        root: path.join(__dirname, 'css'),
        prefix: '/css/'
    });
    next();
});
// gestione cartella js
app.register(function (instance, opts, next) {
    instance.register(staticFile, {
        root: path.join(__dirname, 'js'),
        prefix: '/js/'
    });
    next();
});
app.get('/', function (req, reply) {
    connection.query("SELECT * FROM users", function (error, results, fields) {
        var risultati = {
            list: results
        };
        reply.view('/templates/index.ejs', risultati);
    });
});
app.get('/items/:username', function (req, reply) {
    var username = req.params.username;
    connection.query("SELECT * FROM users WHERE username = ?", username, function (error, results, fields) {
        reply.view('/templates/details.ejs', results[0]);
    });
});
app.get("/items/register", function (req, reply) {
    reply.view("/templates/register.ejs");
});
app.post("/items/register/insert", function (req, reply) {
    var data = req.body;
    console.log("CIAO,SONO ENTRATO" + data);
    console.log("CIAO MI CHIAMO MARIO " + data.username + " " + data.email + " " + data.password);
    connection.query("INSERT INTO users SET ?", data, function (error, results, fields) {
        if (error) {
            reply.status(500).send({ error: error.message });
        }
        reply.send(results);
    });
});
app.listen(3000, function (err, address) {
    if (err)
        throw err;
    app.log.info("server listening on " + address);
});
var User = /** @class */ (function () {
    function User() {
    }
    return User;
}());
