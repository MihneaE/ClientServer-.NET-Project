using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonModule.Model;
using CommonModule.Services;

namespace CommonModule.Repository
{
    internal interface IRepository
    {
        List<Man> GetAllMen();
        List<User> GetAllUsers();
        List<Competition> GetAllCompetitions();

        List<Man> findManFromSpecificCompetition(string sample, string ageCategory);

        void addMan(Man man);

        User LoginUser(string username, string password);

    }
}
