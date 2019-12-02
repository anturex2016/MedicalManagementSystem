using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalManagementApp.Model
{
    class LogIn
    {
        public int LoginId { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string Password { get; set; }

        public string Type { get; set; }

        public bool LoginCheck()
        {
            return false;
        }

        public bool Logout()
        {
            return false;
        }
    }
}
