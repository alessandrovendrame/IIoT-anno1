using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Vendrame.ChatSignal.Data
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DbChatContext _dbChatContext;
        public RoomRepository(DbChatContext dbChatContext)
        {
            _dbChatContext = dbChatContext;
        }
        public int Count()
        {
            return _dbChatContext.Room.Count();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Room> GetAll()
        {
            return _dbChatContext.Room.OrderBy(r => r.Id).ToArray();
        }

        public Room GetById(int id)
        {
            return _dbChatContext.Room.FirstOrDefault(r => r.Id == id);
        }

        public void Insert(Room entity)
        {
            _dbChatContext.Room.Add(entity);
            _dbChatContext.SaveChanges();
        }

        public void Update(Room entity)
        {
            _dbChatContext.Update(entity);
            _dbChatContext.SaveChanges();
        }
    }
}
