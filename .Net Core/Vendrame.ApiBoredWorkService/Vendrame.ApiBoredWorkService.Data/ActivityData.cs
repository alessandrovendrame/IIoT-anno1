using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Vendrame.ApiBoredWorkService.Model;

namespace Vendrame.ApiBoredWorkService.Data
{
    public class ActivityData : IActivityData
    {
        private readonly string _connectionString;
        public ActivityData()
        {
            this._connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BoredActivity;Integrated Security=True;Pooling=False";
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Activity Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Activity> GetAll()
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                string query = "select * from Activity";
                return connection.Query<Activity>(query);
            }
        }

        public void Insert(Activity a)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Activity(ActivityType, Type, CreationDate) VALUES (@ActivityType,@Type,@CreationDate)";

                connection.Execute(query, a);
            }
        }

        public void Update(Activity entity)
        {
            throw new NotImplementedException();
        }
    }
}
