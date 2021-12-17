using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Облікування_Мобільних_Пристроїв.Classes
{
    public class User
    {
        public string login, password;
        public int levelAcces;

        public User(string loginUser, string pass, int lvlAcc)
        {
            login = loginUser;
            password = pass;
            levelAcces = lvlAcc;
        }
    }
}
