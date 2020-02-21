"use strict";
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
var __generator = (this && this.__generator) || function (thisArg, body) {
    var _ = { label: 0, sent: function() { if (t[0] & 1) throw t[1]; return t[1]; }, trys: [], ops: [] }, f, y, t, g;
    return g = { next: verb(0), "throw": verb(1), "return": verb(2) }, typeof Symbol === "function" && (g[Symbol.iterator] = function() { return this; }), g;
    function verb(n) { return function (v) { return step([n, v]); }; }
    function step(op) {
        if (f) throw new TypeError("Generator is already executing.");
        while (_) try {
            if (f = 1, y && (t = op[0] & 2 ? y["return"] : op[0] ? y["throw"] || ((t = y["return"]) && t.call(y), 0) : y.next) && !(t = t.call(y, op[1])).done) return t;
            if (y = 0, t) op = [op[0] & 2, t.value];
            switch (op[0]) {
                case 0: case 1: t = op; break;
                case 4: _.label++; return { value: op[1], done: false };
                case 5: _.label++; y = op[1]; op = [0]; continue;
                case 7: op = _.ops.pop(); _.trys.pop(); continue;
                default:
                    if (!(t = _.trys, t = t.length > 0 && t[t.length - 1]) && (op[0] === 6 || op[0] === 2)) { _ = 0; continue; }
                    if (op[0] === 3 && (!t || (op[1] > t[0] && op[1] < t[3]))) { _.label = op[1]; break; }
                    if (op[0] === 6 && _.label < t[1]) { _.label = t[1]; t = op; break; }
                    if (t && _.label < t[2]) { _.label = t[2]; _.ops.push(op); break; }
                    if (t[2]) _.ops.pop();
                    _.trys.pop(); continue;
            }
            op = body.call(thisArg, _);
        } catch (e) { op = [6, e]; y = 0; } finally { f = t = 0; }
        if (op[0] & 5) throw op[1]; return { value: op[0] ? op[1] : void 0, done: true };
    }
};
exports.__esModule = true;
var fastify = require("fastify");
var bcrypt = require("bcrypt");
var fst_jwt = require("fastify-jwt");
var mysql = require("mysql");
var app = fastify({ logger: true, ignoreTrailingSlash: true });
var register = app.register(fst_jwt, { secret: 'mysuperpassword' });
var saltRounds = 10;
var connection = mysql.createPool({
    connectionLimit: 10,
    host: 'localhost',
    user: 'root',
    password: 'Vmware1!',
    database: 'dbUsers',
    insecureAuth: true
});
var list = [];
app.post('/token', function (request, reply) {
    // some code
    var utente = request.body;
    var passwordHash = bcrypt.hashSync(utente.password, saltRounds);
    console.log('passwordHash: ' + passwordHash);
    connection.query("SELECT id,email,password FROM users WHERE username = ?", utente.username, function (error, results, fields) {
        app.log.info(results);
        app.log.info(fields);
        if (results.length > 0) {
            bcrypt.compare(utente.password, results[0].password).then(function (result) {
                if (result) {
                    var tempuser = {
                        id: results[0].id,
                        email: results[0].email
                    };
                    var token = app.jwt.sign({ payload: tempuser });
                    reply.send({ token: token });
                }
                else {
                    reply.status(401).send({
                        statusCode: 401,
                        error: "Unauthorized",
                        message: "Inavalid password."
                    });
                }
            });
        }
        else {
            reply.status(401).send({
                statusCode: 401,
                error: "Unauthorized",
                message: "Inavalid username."
            });
        }
    });
});
/*app.get('/verify', function (request, reply) {
    request.jwtVerify(function (err, decoded) {
        return reply.send(err || decoded)
    })
});*/
app.register(function (x, opts) {
    return __awaiter(this, void 0, void 0, function () {
        var _this = this;
        return __generator(this, function (_a) {
            x.addHook("onRequest", function (request, reply) { return __awaiter(_this, void 0, void 0, function () {
                var err_1;
                return __generator(this, function (_a) {
                    switch (_a.label) {
                        case 0:
                            _a.trys.push([0, 2, , 3]);
                            return [4 /*yield*/, request.jwtVerify()];
                        case 1:
                            _a.sent();
                            return [3 /*break*/, 3];
                        case 2:
                            err_1 = _a.sent();
                            reply.send(err_1);
                            return [3 /*break*/, 3];
                        case 3: return [2 /*return*/];
                    }
                });
            }); });
            x.get('/', function (request, reply) { return __awaiter(_this, void 0, void 0, function () {
                var tokenJwt;
                return __generator(this, function (_a) {
                    tokenJwt = request.user;
                    return [2 /*return*/, {
                            id: tokenJwt.payload.id,
                            email: tokenJwt.payload.email
                        }];
                });
            }); });
            x.get('/api/list', function (request, reply) {
                console.log("RICHIESTA GET!");
                reply.send(list);
            });
            x.post('/api/list', function (request, reply) {
                x.log.info("Richiesta effettuata");
                var thing = request.body;
                var tokenJwt = request.user;
                connection.query("SELECT username FROM users WHERE id = ?", tokenJwt.payload.id, function (error, results, fields) {
                    app.log.info(results);
                    app.log.info(fields);
                    if (results.length > 0) {
                        console.log(thing);
                        list.push(new toDo(thing.description, results[0].username, thing.status, new Date));
                        console.log(list);
                        reply.send();
                    }
                });
            });
            return [2 /*return*/];
        });
    });
});
app.post('/register', function (request, reply) {
    var utente = request.body;
    utente.password = bcrypt.hashSync(utente.password, saltRounds);
    connection.query("INSERT INTO users SET ?", utente, function (error, results, fields) {
        app.log.info(results);
        app.log.info(fields);
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
    });
});
app.listen(3000, function (err, address) {
    if (err)
        throw err;
    app.log.info('server Listening on ${address}');
});
var user = /** @class */ (function () {
    function user(id, username, email, password) {
        this.id = id;
        this.username = username;
        this.email = email;
        this.password = password;
    }
    return user;
}());
var toDo = /** @class */ (function () {
    function toDo(description, assignedTo, status, creationDate) {
        this.description = description;
        this.assignedTo = assignedTo;
        this.status = status;
        this.creationDate = creationDate;
    }
    return toDo;
}());
