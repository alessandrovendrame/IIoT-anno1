"use strict";
/*---------Collegarsi ad un API con servizio SOPA/REST--------

    JSON:

    Tipi di dato:
        -Stringa
        -Numerico
        -Data
        -Boolean
    
    Sul tipo Data, consiglio di scambiare dae in formato ISO8601
        -Scambiare integer(come epoch) è di difficile lettura

    
    API REST:
        è un architettura software per i sistemi distrubutori come il World Wide Web
        è anche uno dei principali autori delle specifiche dell' http, termine ampiamente usato nella
        comunità dell'internet

        REST non è uno standard

        




---------------------------------------------------------------*/
exports.__esModule = true;
var fastify = require("fastify");
var cors = require("fastify-cors");
var app = fastify({ logger: true });
app.register(cors, {
    origin: "localhost:5000",
    methods: "GET,POST"
});
app.get('/', function (req, reply) {
    reply.send("Ciao ITS");
});
app.get('/api/products', function (request, reply) {
    var list = [];
    list.push(new Product(1, 'Prodotto 1'));
    list.push(new Product(2, 'Prodotto 2'));
    reply.send(list);
});
app.get('/api/products/:id', function (request, reply) {
    var productID = request.params.id;
    reply.send(new Product(productID, 'Prodotto ' + productID));
});
app.post('/api/products', function (request, reply) {
    var product = request.body;
    reply.send({
        result: true,
        productId: product.id,
        productName: product.name
    });
});
app.listen(3000, function (err, address) {
    if (err)
        throw err;
    app.log.info('server Listening on ${address}');
});
var Product = /** @class */ (function () {
    function Product(id, name) {
        this.id = id;
        this.name = name;
    }
    return Product;
}());
