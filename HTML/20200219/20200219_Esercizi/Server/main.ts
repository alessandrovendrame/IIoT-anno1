import * as fastify from 'fastify';
import * as cors from 'fastify-cors';
import * as mysql from 'mysql';
import { request } from 'http';

var connection = mysql.createPool({
    connectionLimit: 10,
    host: 'localhost',
    user: 'root',
    password: 'Vmware1!',
    database: 'school',
    insecureAuth : true
});

var app = fastify({ logger: true });
app.register(cors);

app.get("/students", (request, reply) => {
    connection.query("select studentid,firstname, lastname, class,age from students", (error, results, fields) => {
        app.log.info(results);
        app.log.info(fields);
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
        reply.send(results);
    });
});

app.get('/students/classes',(request, reply) => {
    console.log("RICHIESTA CLASSI!");
    connection.query("select distinct class from students", (error, results, fields) => {
        app.log.info(results);
        app.log.info(fields);
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
        reply.send(results);
    });
    
});

app.get('/students/:class' , (request,reply) => {
    var classe = request.params.class;

    connection.query("select studentid,firstname,lastname,class,age from students where class = ?",classe, (error, results, fields) => {
        app.log.info(results);
        app.log.info(fields);
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
        reply.send(results);
    });

});

app.listen(3000, (err, address) => {
    if (err) throw err
    app.log.info('server listening on' + address)
});

app.post('/students', (request, reply) => {

    app.log.info("Richiesta effettuata");
    let studente = request.body;

    connection.query("INSERT INTO students SET ?" , studente, (error, results, fields) => {
        app.log.info(results);
        app.log.info(fields);
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
    });
});

app.post("/students/delete", (request, reply) => {

    let id_studente = request.body;

    console.log(id_studente);

    connection.query("DELETE FROM students WHERE studentid = ?" , id_studente, (error, results, fields) => {
        app.log.info(results);
        app.log.info(fields);
        if (error) {
            reply.status(500).send({ error: error.message });
            return;
        }
    });
});
