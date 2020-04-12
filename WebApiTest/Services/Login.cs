using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTest
{
    public class Login
    {
        private string _Pwd = String.Empty;
        public string Usr_id { get; set; }
        public string Psw { set { _Pwd = value; } }
        public string Usr_Name { get; set;}

        public bool Validate() 
        {
            if (!(Usr_id == "Admin" && _Pwd == "Admin1*"))
            {
                return false;
            }
            return true;
        }                
       
    }
}
