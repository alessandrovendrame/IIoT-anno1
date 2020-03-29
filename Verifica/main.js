exports.handler = async (event) => {
    // TODO implement
    
    var mysql = require('mysql');

    var connection = mysql.createPool({
        host     : "iiot2020-vendrame-testfinale.c9nj1x2p6gk5.eu-west-1.rds.amazonaws.com",
        user     : "admin",
        password : "awstest2020!",
        database : "VerificaDB",
    });

    connection.connect(function(err) {
        if (err) {
            console.error('Database connection failed: ' + err.stack);
            return;
        }

        let n=event.Records[0].body;

        connection.query('insert into SQSlist(id,type,valore,ARN)VALUES(?,?,?,?)',[n.id,n.type,n.valore,n.arn], function (err, result, fields) { });

        console.log('Connected to database.');
    });

    connection.end();
    
    const response = {
        statusCode: 200,
        body: JSON.stringify('Hello from Lambda!'),
    };
    return response;
};