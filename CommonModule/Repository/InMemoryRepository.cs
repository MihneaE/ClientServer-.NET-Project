using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommonModule.Model;

namespace CommonModule.Repository
{
    public class InMemoryRepository : IRepository
    {
        private List<Man> men;
        private List<User> users;
        private List<Competition> competitions;

        public InMemoryRepository(List<Man> men, List<User> users, List<Competition> competitions)
        {
            this.men = men;
            this.users = users;
            this.competitions = competitions;
        }

        public List<Man> GetAllMen() => men;
        public List<User> GetAllUsers() => users;
        public List<Competition> GetAllCompetitions() => competitions;

        public List<Man> findManFromSpecificCompetition(string sample, string ageCategory)
        {
            Competition foundCompetition = null;
            List<Man> manList = new List<Man>();

            foreach (Competition competition in competitions)
            {
                if (competition.sample.Equals(sample, StringComparison.Ordinal) &&
                    competition.ageCategory.Equals(ageCategory, StringComparison.Ordinal))
                {
                    foundCompetition = competition;
                    break;
                }
            }

            if (foundCompetition != null)
            {
                foreach (Man man in men)
                { 
                   
                    if (man.sample_id == foundCompetition.id)
                    {
                        manList.Add(man);
                    }
                }
            }

            return manList;
        }

        public User LoginUser(string username, string password)
        {
            User foundUser = new User();

            foreach (var user in users)
            {

                if (string.Equals(user.GetUsername(), username, StringComparison.OrdinalIgnoreCase) && user.GetPassword() == password)
                {
                    foundUser = user;
                    break;
                }
            }

            return foundUser;
        }

        public void addMan(Man man)
        {
            men.Add(man);
        }
    }
}
