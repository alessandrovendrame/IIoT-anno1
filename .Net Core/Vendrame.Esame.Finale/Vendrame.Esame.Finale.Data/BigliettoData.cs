using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using Vendrame.Esame.Finale.Models;
using System.Data.SqlClient;

namespace Vendrame.Esame.Finale.Data
{
    public class BigliettoData : IBigliettoData
    {
        private readonly string _connectionString;
        public BigliettoData()
        {
            this._connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB;Initial Catalog=bigliettiSupermercato;Integrated Security=True;Pooling=False";
        }
        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Biglietto Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Biglietto> GetAll(string sigla)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                var query = "select * from Biglietti where SectionCode=@idSezione AND ServingDate IS NULL";
                return connection.Query<Biglietto>(query, new { idSezione = sigla } );
            }
        }

        public void Insert(Biglietto entity)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = "insert into Biglietti(SectionCode, IndexCode, CreationDate) values (@SectionCode, @IndexCode, @CreationDate)";
                connection.Execute(query, entity);
            }
        }
        public void Update(int id)
        {
            var serving = DateTime.Now;
            using (var connection = new SqlConnection(_connectionString))
            {
                const string query = "update Biglietti set ServingDate = @ServingDate where Id = @Id";
                connection.Execute(query, new { ServingDate = serving, Id = id});
            }
        }
    }
}
