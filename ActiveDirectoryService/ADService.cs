using System;
using System.Collections.Generic;

namespace ActiveDirectoryService
{
    public class ADService
    {
        public List<ADUser> _users;

        public ADService()
        {
            _users = new List<ADUser>()
            {
                new ADUser() { UserName="mterceros", Password="123456" },
                new ADUser() { UserName="ghamilton", Password="987654" },
                new ADUser() { UserName="rSmith", Password="asdfgh" }
            };
        }

        public bool IsUserValid(string userName, string password)
        {
            ADUser userFound = _users.Find(user => user.UserName == userName && user.Password == password);
            return userFound != null;
        }
    }

    /*
     * array.Function(element => element.attr1 == 1 );
     * 
     * var itemFound;
     * for (int index = 0; index < array.length; index++)
     * {
     *      if (array[index] == searchCriteria)
     *      {
     *          itemFound = array[index];
     *          break;
     *      }
     * }
     * 
     * foreach (var element in array)
     * {
     *      if (element == searchCriteria)
     *      {
     *          itemFound = element;
     *          break;
     *      }
     * }
     * 
     */
}
