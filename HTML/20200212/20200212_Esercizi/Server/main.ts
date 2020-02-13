import * as fastify from 'fastify';
import { REPL_MODE_SLOPPY } from 'repl';
import * as cors from 'fastify-cors';

var app = fastify({ logger: true });

let list: Product[] = [];
var list1: Product[] = [];

app.register(cors, {
    methods: "GET,POST"
});

app.get('/', (req, reply) => {
    reply.send("Ciao ITS");
});

app.get('/api/basket', (request, reply) => {
    console.log("RICHIESTA GET!");
    getTotalItems();
    console.log(list1);
    reply.send(list1);
});

app.post('/api/basket', (request, reply) => {

    app.log.info("Richiesta effettuata");
    let product = request.body as Product;

    console.log(product);

    list.push(new Product(product.nome, product.quantita));

    console.log(list);
});

app.listen(3000, (err, address) => {
    if (err) throw err;
    app.log.info('server Listening on ${address}')
});

function getTotalItems() {

    list1 = [];

    for (let i = 0; i < list.length; i++) {
        const item = list[i];

        var exist = false;

        for (let j = 0; j < list1.length; j++) {
            const element = list1[j];
            if (element.nome == item.nome) {
                exist = true;
                element.quantita += item.quantita;
            }
        }

        if (!exist)
            list1.push(new Product(item.nome, item.quantita));
    }
}

class Product {
    constructor(
        public nome: string,
        public quantita: number) { }
}