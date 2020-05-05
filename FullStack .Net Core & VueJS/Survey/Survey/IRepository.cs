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
        string GetUser(int id);
        IEnumerable<string> GetQuestions();
        Int32? SaveQuestion(Poll poll);
        Int32? SaveAnswer(Poll poll, Int32 question);
    }
}
