using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Controllers
{
    public class ClientController
    {
        public static Client GetClient(int clientId)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.GetClient(clientId);
            }
        }
    }
}
