using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vendrame.ChatSignal.Data
{
    public class MessageRepository : IMessageRepository
    {
        private readonly DbChatContext _dbChatContext;
        public MessageRepository(DbChatContext dbChatContext)
        {
            _dbChatContext = dbChatContext;
        }
        public int Count()
        {
            return _dbChatContext.Messagge.Count();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Messagge> GetAll()
        {
            return _dbChatContext.Messagge.OrderBy(m => m.Id).ToArray();
        }

        public Messagge GetById(int id)
        {
            return _dbChatContext.Messagge.FirstOrDefault(m => m.Id == id);
        }

        public void Insert(Messagge entity)
        {
            _dbChatContext.Messagge.Add(entity);
            _dbChatContext.SaveChanges();
        }

        public void Update(Messagge entity)
        {
            _dbChatContext.Update(entity);
            _dbChatContext.SaveChanges();
        }
    }
}
