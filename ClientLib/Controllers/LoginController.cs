using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Controllers
{
     public class LoginController
    {
        public static int IsLoginDataValid(string cnp, string password)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.IsClientLoginValid(cnp, password);
            }
        }
    }
}
