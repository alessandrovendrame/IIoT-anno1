import * as fastify from 'fastify';
import { REPL_MODE_SLOPPY } from 'repl';
import * as cors from 'fastify-cors';

var app = fastify({ logger: true });

let list: toDo[] = [];
let list1 = [];

app.register(cors, {
    methods: "GET,POST"
});

app.get('/', (req, reply) => {
    reply.send("Ciao ITS");
});

app.get('/api/list', (request, reply) => {
    console.log("RICHIESTA GET!");
    
    reply.send(list);
});

app.get('/api/list/persone',(request, reply) => {
    console.log("RICHIESTA PERSONE!");
    
    getTotalItems();

    reply.send(list1);
});

app.get('/api/list/:assignedTo',(request, reply) => {
    
    var list2 = [];

    let assigned = request.params.assignedTo;

    for (let i = 0 ; i<list.length; i++)
    {
        if(list[i].assignedTo==assigned)
        {
            list2.push(list[i]);
        }
    }

    reply.send(list2);
});

app.post('/api/list', (request, reply) => {

    app.log.info("Richiesta effettuata");
    let thing = request.body as toDo;

    console.log(thing);

    list.push(new toDo(thing.description,thing.assignedTo,thing.status,thing.creationDate));

    console.log(list);
});

app.listen(3000, (err, address) => {
    if (err) throw err;
    app.log.info('server Listening on ${address}')
});

class toDo {
    constructor(
        public description: string,
        public assignedTo: string,
        public status: string,
        public creationDate: Date
        ) { }
}

function getTotalItems() {

    list1 = [];

    for (let i = 0; i < list.length; i++) {
        const item = list[i];

        var exist = false;

        for (let j = 0; j < list1.length; j++) {
            const element = list1[j];
            if (element == item.assignedTo) {
                exist = true;
            }
        }

        if (!exist)
            list1.push(item.assignedTo);
    }
}