using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientLib.Operator.Controllers
{
    public class EditSecurityController
    {
        public static bool UpdateClient(Client client)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                if (CanUpdateClient(client))
                {
                    return service.UpdateClient(client);
                }
            }
            return false;
        }

        private static bool CanUpdateClient(Client client)
        {
            //TODO: Check First Name
            int countFirstName= client.FirstName.Count(x => Char.IsDigit(x));
            if (countFirstName != 0)
                return false;

            //TODO: Check Last Name
            int countLastName = client.LastName.Count(x => Char.IsDigit(x));
            if (countLastName != 0)
                return false;

            //TODO: Check CNP
            int countCnp = client.CNP.Count(x => Char.IsDigit(x));
            if (countCnp != 13)
                return false;

            //TODO: Check Phone
            int countPhone = client.Phone.Count(x => Char.IsDigit(x));
            if (countPhone != 10)
                return false;

            return true;
        }
    }
}
