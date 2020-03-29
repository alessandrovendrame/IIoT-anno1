import * as fastify from "fastify";
import * as staticFile from "fastify-static";
import * as pointOfView from "point-of-view";
import * as path from "path";
import * as mysql from 'mysql';

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

app.register(
    require("fastify-formbody")
);
  
  // app.register(staticFile, {
  //     root: path.join(__dirname, '/css'),
  //     prefix: '/css/',
  // });
  // gestione cartella css
app.register((instance, opts, next) => {
    instance.register(staticFile, {
      root: path.join(__dirname, 'css'),
      prefix: '/css/'
    })
    next();
  });
  
  // gestione cartella js
app.register((instance, opts, next) => {
    instance.register(staticFile, {
      root: path.join(__dirname, 'js'),
      prefix: '/js/'
    });
    next();
  });
  
app.get('/', (req, reply) => {
    connection.query("SELECT * FROM users", (error, results, fields) => {
        let risultati = {
            list : results
        }
        reply.view('/templates/index.ejs', risultati);
    });        
});
  
app.get('/items/:username', (req, reply) => {
    let username = req.params.username;
    connection.query("SELECT * FROM users WHERE username = ?", username , (error, results, fields) => {
    reply.view('/templates/details.ejs', results[0]);
    });
});

app.get("/items/register", (req,reply) => {
    reply.view("/templates/register.ejs");
});

app.post("/items/register/insert", (req, reply) =>{
    let data = req.body as User;
    console.log("CIAO,SONO ENTRATO" + data)
    console.log("CIAO MI CHIAMO MARIO "+ data.username + " " + data.email + " " + data.password);
    connection.query("INSERT INTO users SET ?",data, (error, results, fields) => {
        if (error) {
            reply.status(500).send({ error: error.message });
        }
        reply.send(results)
    });
});
  
app.listen(3000, (err, address) => {
      if (err) throw err
      app.log.info(`server listening on ${address}`)
    });

class User{
    public username : string;
    public email: string;
    public password: string;
}