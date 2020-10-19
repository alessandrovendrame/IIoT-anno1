using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vendrame.ChatSignal.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DbChatContext _dbChatContext;
        public UserRepository(DbChatContext dbChatContext)
        {
            _dbChatContext = dbChatContext;
        }
        public int Count()
        {
            return _dbChatContext.Users.Count();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _dbChatContext.Users.OrderBy(u => u.Name).ToArray();
        }

        public User GetById(int id)
        {
            return _dbChatContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public void Insert(User entity)
        {
            _dbChatContext.Users.Add(entity);
            _dbChatContext.SaveChanges();
        }

        public void Update(User entity)
        {
            _dbChatContext.Update(entity);
            _dbChatContext.SaveChanges();
        }
    }
}
