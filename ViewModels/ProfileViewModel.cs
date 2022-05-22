using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystem
{
    public class ProfileViewModel
    {
        public Data.User AuthUser { get; set; }

        public ProfileViewModel(Data.User user)
        {
            AuthUser = user;
        }
    }
}
