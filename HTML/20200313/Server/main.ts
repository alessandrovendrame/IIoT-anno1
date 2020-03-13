import * as fastify from 'fastify';
import * as cors from 'fastify-cors';
import * as mysql from 'mysql';
import * as bcrypt from 'bcrypt';
import * as jwt from 'fastify-jwt';
import * as swagger from 'fastify-swagger';
import * as staticFile from 'fastify-static';
import path = require('path');

const saltRounds = 10;

var connection = mysql.createPool({
    connectionLimit: 10,
    host: 'localhost',
    user: 'root',
    password: 'Vmware1!',
    database: 'dbusers',
    insecureAuth: true
});

var app = fastify({ logger: true });
app.register(jwt, {
    secret: 'supersecret'
})
app.register(swagger, {
    routePrefix: '/documentation',
    swagger: {
        info: {
            title: 'Test swagger',
            description: 'testing the fastify swagger api',
            version: '0.1.0'
        },
        externalDocs: {
            url: 'https://swagger.io',
            description: 'Find more info here'
        },
        host: 'localhost:3000',
        schemes: ['http'],
        consumes: ['application/json'],
        produces: ['application/json']
    },
    exposeRoute: true
})

app.post('/token', (request, reply) => {
    // some code
    let utente = request.body as user;

    let passwordHash = bcrypt.hashSync(utente.password, saltRounds);
    console.log('passwordHash: ' + passwordHash);
    connection.query("select ID,username,password,email from users where username= ?", utente.username, (error, results, fields) => {
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
        else if (results.length > 0) {
            bcrypt.compare(utente.password, results[0].password, (err, result) => {
                if (result) {
                    var user = {

                        username: results[0].username,
                        id: results[0].ID
            
                    };
                    console.log("L'id è: " + results[0].ID);
                    const token = app.jwt.sign({ payload: user });
                    reply.send({ token });

                }
                else {
                    reply.status(401).send({
                        statusCode: 401,
                        error: "Unauthorized",
                        message: "Inavalid  password."
                    });
                }
            })
            //  reply.status(204).send();


        }
        else {
            reply.status(401).send({
                statusCode: 401,
                error: "Unauthorized",
                message: "Inavalid  Username."
            })
        };
    })

})

app.get('/verify', function (request, reply) {
    request.jwtVerify(function (err, decoded) {
        return reply.send(err || decoded)
    })
});


app.register(async function (x, opts) {

    x.addHook("onRequest", async (request, reply) => {
        try {
            await request.jwtVerify()
        } catch (err) {
            reply.send(err)
        }
    });

    x.get('/', async (request, reply) => {
        let tokenJwt: any = request.user;

        return {
            user: tokenJwt.payload.username,
            id: tokenJwt.payload.id
        }
    });
    x.get('/items', (request, reply) => {
        connection.query("select * from todo", (error, results, fields) => {
            if (error) {
                reply.status(500).send({ error: error.message });
                return;
            }
            reply.send(results);
        })
    })
    const bodyItemJsonSchema = {
        type: 'object',
        required: ['description', 'state'],
        properties: {
            description: { type: 'string' },
            state: { type: 'string' },
            date: { type: 'string' },
        }
    }

    x.post('/items', { schema: { body: bodyItemJsonSchema } }, (request, reply) => {
        let Data = request.body as ToDo;
        let tokenJwt: any = request.user;
        console.log(Data);
        console.log(tokenJwt.payload.id);
        var data = new Date();
        var gg,mm,aaaa;
        gg=data.getDate() + "-";
        mm=data.getMonth() + 1 + "-";
        aaaa= data.getFullYear();
        var today= gg+mm+aaaa;
        connection.query("insert into todo(assignedTo,description,state,date) values(?,?,?,?)", [tokenJwt.payload.id, Data.description, Data.state, today], (err, result, fields) => { reply.status(204); });
        reply.send();

    });
    x.get("/items/:author", {
        schema: {
            params: {
                author: { type: 'string', minLength: 3 }
            }
        }
    }, (request, reply) => {
        connection.query("select todo.* from todo,users where assignedTo=ID AND users.username=?", request.params.author, (error, results, fields) => {
            if (error) {
                reply.status(500).send({ error: error.message });
                return;
            }
            reply.send(results);
        })

    });
});


app.post('/register', (request, reply) => {
    let utente = request.body as user;
    utente.password = bcrypt.hashSync(utente.password, saltRounds);
    connection.query("insert into users set ?", utente, (error, results, fields) => {
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
        reply.status(204).send();
    })
});




app.register(staticFile, {
    root: path.join(__dirname, '../client'),
    prefix: '/app/', // optional: default '/'
});

app.listen(3000, (err, address) => {
    if (err) throw err
    app.log.info('server listening on' + address)
});
class user {
    constructor(
        public username: string,
        public password: string,
        public email: string
    ) { }
}
class ToDo {
    constructor(
        public description: string,
        public state: string,
        public date: Date) {

    }
}



