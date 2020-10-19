using Vendrame.ChatSignal.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Vendrame.ChatSignal.Data
{
    public interface IUserRepository : IRepository<User, int>
    {
    }
}
