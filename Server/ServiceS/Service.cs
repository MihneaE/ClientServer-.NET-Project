using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonModule.Model;
using CommonModule.Repository;
using CommonModule.Services;

namespace Server.ServiceS
{
    public  class Service : IService
    {
        private InMemoryRepository inMemoryRepository;
        private DatabaseRepository databaseRepository;
        private readonly object syncRoot = new object(); 
        private Dictionary<string, CommonModules.Services.Observer> loggedWorkers = new Dictionary<string, CommonModules.Services.Observer>();

        public Service(InMemoryRepository inMemoryRepository, DatabaseRepository databaseRepository)
        {
            this.inMemoryRepository = inMemoryRepository;
            this.databaseRepository = databaseRepository;
        }

        public List<Man> GetAllMenFS()
        {
            return inMemoryRepository.GetAllMen();
        }

        public List<User> GetAllUsersFS()
        {
            return inMemoryRepository.GetAllUsers();
        }

        public List<Competition> GetAllCompetitionsFS()
        {
            return inMemoryRepository.GetAllCompetitions();
        }

        public List<Man> findManFromSpecificCompetitionFS(string sample, string ageCategory)
        {
            return inMemoryRepository.findManFromSpecificCompetition(sample, ageCategory);
        }

        public void registerMan(int id, int sample_id, string name, int age)
        {
            Man man = new Man(id, sample_id, name, age);

            inMemoryRepository.addMan(man);
            databaseRepository.AddMan(man);

        }

        public User loginUser(string username, string password, CommonModules.Services.Observer client)
        {
            lock (syncRoot) 
            {
                User foundUser = inMemoryRepository.LoginUser(username, password);

                Console.WriteLine(foundUser.ToString());


                if (foundUser != null)
                {
                    if (loggedWorkers.ContainsKey(foundUser.GetUsername())) 
                        throw new CommonModules.Services.ServiceException("User already logged in!");

                    loggedWorkers[foundUser.GetUsername()] = client;
                }
                else
                {
                    throw new CommonModules.Services.ServiceException("Authentication failed!");
                }

                return foundUser;
            }
        }

        public void logoutUser(User user, CommonModules.Services.Observer client)
        {
            lock (syncRoot) 
            {
                if (loggedWorkers.TryGetValue(user.GetUsername(), out CommonModules.Services.Observer localClient)) 
                {
                    loggedWorkers.Remove(user.GetUsername());
                }
                else
                {
                    throw new CommonModules.Services.ServiceException("User " + user.GetUsername() + " is not logged in!");
                }
            }
        }
    }
}
