import * as fastify from 'fastify';
import * as bcrypt from 'bcrypt';
import * as fst_jwt from 'fastify-jwt';
import * as mysql from 'mysql';
import * as cors from 'fastify-cors';
import { stringify } from 'querystring';

var app = fastify({ logger: true, ignoreTrailingSlash: true });
var register = app.register(fst_jwt, { secret: 'mysuperpassword' });
const saltRounds = 10;

var connection = mysql.createPool({
    connectionLimit: 10,
    host: 'localhost',
    user: 'root',
    password: 'Vmware1!',
    database: 'dbUsers',
    insecureAuth: true
});

let list: toDo[] = [];

app.post('/token', (request, reply) => {
    // some code
    let utente = request.body as user;

    let passwordHash = bcrypt.hashSync(utente.password, saltRounds);
    console.log('passwordHash: ' + passwordHash);

    connection.query("SELECT id,email,password FROM users WHERE username = ?", utente.username, (error, results, fields) => {
        app.log.info(results);
        app.log.info(fields);

        if (results.length > 0) {
            bcrypt.compare(utente.password, results[0].password).then(function (result) {
                if (result) {
                    var tempuser = {
                        id: results[0].id,
                        email: results[0].email
                    };
                    const token = app.jwt.sign({ payload: tempuser });
                    reply.send({ token });
                } else {
                    reply.status(401).send({
                        statusCode: 401,
                        error: "Unauthorized",
                        message: "Inavalid password."
                    });
                }
            });
        } else {
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


app.register(async function (x, opts) {
    x.addHook("onRequest", async (request, reply) => {
        try {
            await request.jwtVerify()
        } catch (err) {
            reply.send(err);
        }
    });

    x.get('/', async (request, reply) => {
        let tokenJwt: any = request.user;

        return {
            id: tokenJwt.payload.id,
            email: tokenJwt.payload.email
        }
    });

    x.get('/api/list', (request, reply) => {
        console.log("RICHIESTA GET!");

        reply.send(list);
    });

    x.post('/api/list', (request, reply) => {

        x.log.info("Richiesta effettuata");
        let thing = request.body as toDo;
        let tokenJwt: any = request.user;

        connection.query("SELECT username FROM users WHERE id = ?", tokenJwt.payload.id, (error, results, fields) => {
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

    
});

app.post('/register', (request, reply) => {
    let utente = request.body as user;
    utente.password = bcrypt.hashSync(utente.password, saltRounds);
    connection.query("INSERT INTO users SET ?", utente, (error, results, fields) => {
        app.log.info(results);
        app.log.info(fields);
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
    });

});

app.listen(3000, (err, address) => {
    if (err) throw err;
    app.log.info('server Listening on ${address}')
});

class user {
    constructor(
        public id: number,
        public username: string,
        public email: string,
        public password: string
    ) { }
}

class toDo {
    constructor(
        public description: string,
        public assignedTo: string,
        public status: string,
        public creationDate: Date
    ) { }
}