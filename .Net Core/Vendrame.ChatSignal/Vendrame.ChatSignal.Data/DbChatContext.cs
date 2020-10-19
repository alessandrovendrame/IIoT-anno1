using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vendrame.ChatSignal.Data
{
    public class DbChatContext :DbContext
    {
        public DbChatContext(DbContextOptions<DbChatContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Messagge> Messagge { get; set; }

        public DbSet<Room> Room { get; set; }

    }
}
