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

        public static bool IsOperatorDataValid()
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.IsOperatorLoginValid();
            }
        }

        public static bool IsVerificationRequestValid(string password)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.IsVerificationRequestValid(password);
            }
        }
    }
}
