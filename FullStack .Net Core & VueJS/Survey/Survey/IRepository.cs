using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Models;

namespace Survey
{
    public interface IRepository
    {
        IEnumerable<User> GetUsers();
    }
}
