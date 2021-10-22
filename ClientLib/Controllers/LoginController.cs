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
