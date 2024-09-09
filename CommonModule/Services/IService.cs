using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonModule.Model;
using CommonModule.Services;

namespace CommonModule.Services
{
    public interface IService
    {
        List<Man> GetAllMenFS();
        List<User> GetAllUsersFS();
        List<Competition> GetAllCompetitionsFS();

        List<Man> findManFromSpecificCompetitionFS(string sample, string ageCategory);

        void registerMan(int id, int sample_id, string name, int age);

        User loginUser(string username, string password, CommonModules.Services.Observer client);

        void logoutUser(User user, CommonModules.Services.Observer client);
    }
}
