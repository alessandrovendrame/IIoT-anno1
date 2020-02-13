"use strict";
exports.__esModule = true;
var fastify = require("fastify");
var cors = require("fastify-cors");
var app = fastify({ logger: true });
var list = [];
var list1 = [];
app.register(cors, {
    methods: "GET,POST"
});
app.get('/', function (req, reply) {
    reply.send("Ciao ITS");
});
app.get('/api/basket', function (request, reply) {
    console.log("RICHIESTA GET!");
    getTotalItems();
    console.log(list1);
    reply.send(list1);
});
app.post('/api/basket', function (request, reply) {
    app.log.info("Richiesta effettuata");
    var product = request.body;
    console.log(product);
    list.push(new Product(product.nome, product.quantita));
    console.log(list);
});
app.listen(3000, function (err, address) {
    if (err)
        throw err;
    app.log.info('server Listening on ${address}');
});
function getTotalItems() {
    list1 = [];
    for (var i = 0; i < list.length; i++) {
        var item = list[i];
        var exist = false;
        for (var j = 0; j < list1.length; j++) {
            var element = list1[j];
            if (element.nome == item.nome) {
                exist = true;
                element.quantita += item.quantita;
            }
        }
        if (!exist)
            list1.push(new Product(item.nome, item.quantita));
    }
}
var Product = /** @class */ (function () {
    function Product(nome, quantita) {
        this.nome = nome;
        this.quantita = quantita;
    }
    return Product;
}());
