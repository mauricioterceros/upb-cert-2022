using Logic.Entities;
using System.Collections.Generic;

namespace Logic.Managers
{
    public class UserManager
    {
        public List<User> GetUsers()
        {
            List<User> retrievedUsers = new List<User>();
            retrievedUsers.Add(new User() { Name = "mterceros", Password = "123" });
            retrievedUsers.Add(new User() { Name = "asmith", Password = "123" });
            retrievedUsers.Add(new User() { Name = "dwaters", Password = "123" });

            return retrievedUsers;
        }
    }
}

