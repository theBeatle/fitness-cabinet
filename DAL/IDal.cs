using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;


namespace Dal
{
    interface IDal
    {
        bool DBUserSaveCredentials(string login, string password, string firstName, string lastName, string email, string sex, string phone, string isDeleted, string isBanned);
        bool IsUserNameInDb(string loginOrEmail);
        bool IsUserNameInDb(string loginOrEmail, string password);
    }
}
