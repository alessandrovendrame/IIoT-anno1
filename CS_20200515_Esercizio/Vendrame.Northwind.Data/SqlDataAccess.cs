using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Maccagnan.Northwind.Models;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Maccagnan.Northwind.Data
{
    [Route("api/products")]
    [ApiController]
    class SqlDataAccess
    {
        private readonly string _connectionString;

        public SqlDataAccess()
        {
            this._connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DbEsercizio;Integrated Security=True;Pooling=False";
        }


        [HttpGet]
        public IEnumerable<Product> GetProduct()
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = "select ProductID, ProductName, Discontinued, UnitPrice from Products";
                return connection.Query<Product>(query);
            }
        }
        [HttpGet]
        public Product GetProduct(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = @"select ProductID, ProductName, Discontinued, UnitPrice from Products Where ProductId=@ProdId";

                return connection.QueryFirstOrDefault<Product>(query, new { ProdId = id });
            }
        }

        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = @"delete from Products where ProductId = @id";

                connection.Execute(query, new { id });
            }
        }


        [HttpPost]
        public void Inserisci(Product product)

        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = @"
insert into Products (ProductName, Discontinued, UnitPrice)
values (@ProductName, @UnitPrice,@Discontinued)";

                connection.Execute(query, product);
            }
        }
        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }

    }

