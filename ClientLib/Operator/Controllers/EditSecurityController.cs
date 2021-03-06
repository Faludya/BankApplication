using ClientLib.Controllers;
using Database;
using System;
using System.Linq;
using System.Text;

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

        public static bool UpdateAccount(Account account)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                if (CanUpdateAccount(account))
                {
                    return service.UpdateAccount(account);
                }
            }
            return false;
        }

        public static bool UpdateAccountOffer(AccountOffer accountOffer)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                if (CanUpdateAccountOffer(accountOffer))
                {
                    return service.UpdateAccountOffer(accountOffer);
                }
            }
            return false;
        }

        public static bool UpdateTranzaction(Tranzaction tranzaction)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                if (CanUpdateTranzaction(ref tranzaction))
                {
                    return service.UpdateTranzaction(tranzaction);
                }
            }
            return false;
        }


        public static bool RemoveClient(Client client)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.RemoveClient(client);
            }
        }

        public static bool RemoveAccount(Account account)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.RemoveAccount(account);
            }
        }

        public static bool RemoveAccountOffer(AccountOffer accountOffer)
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                return service.RemoveAccountOffer(accountOffer);
            }
        }

        public static bool CanUpdateClient(Client client)
        {
            try
            {
                //TODO: Check First Name
                int countFirstName = client.FirstName.Count(x => Char.IsDigit(x));
                if (countFirstName != 0 || client.FirstName == "")
                    return false;

                //TODO: Check Last Name
                int countLastName = client.LastName.Count(x => Char.IsDigit(x));
                if (countLastName != 0 || client.LastName == "")
                    return false;

                //TODO: Check CNP
                int countCnp = client.CNP.Count(x => Char.IsDigit(x));
                if (countCnp != 13)
                    return false;

                //TODO: Check Phone
                int countPhone = client.Phone.Count(x => Char.IsDigit(x));
                if (countPhone != 10)
                    return false;

                //Check Address
                if (client.Address == "")
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CanUpdateAccount(Account account)
        {
            try
            {
                if (account.IBAN.Length != 24)
                    return false;

                if (account.Currency != "RON" && account.Currency != "EURO")
                    return false;

                if (!int.TryParse(account.ID_Client.ToString(), out int resultClient))
                    return false;

                if (!int.TryParse(account.ID_Offer.ToString(), out int resultOffer))
                    return false;

                decimal resultTotal;
                if (!(decimal.TryParse(account.Total.ToString(), out resultTotal)))
                    return false;

                if (account.Total < 0)
                    return false;

                return true;
            }
            catch(Exception)
            {
                return false;
            }
          
        }

        public static bool CanUpdateAccountOffer(AccountOffer accountOffer)
        {
            try
            {
                if (accountOffer.Name == null || accountOffer.Name == "")
                    return false;

                int countName = accountOffer.Name.Count(x => Char.IsDigit(x));
                if (countName != 0)
                    return false;

                if (!decimal.TryParse(accountOffer.DepositCommission.ToString(), out decimal resultDeposit))
                    return false;

                if (!decimal.TryParse(accountOffer.WithdrawCommission.ToString(), out decimal resultWithdraw))
                    return false;

                if (!decimal.TryParse(accountOffer.WithdrawFixTax.ToString(), out decimal resultTax))
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CanUpdateTranzaction(ref Tranzaction tranzaction)
        {
            if (tranzaction.Account.IBAN == tranzaction.Account1.IBAN)
                return false;

            if (tranzaction.Account.Total < tranzaction.Ammount)
                return false;

            decimal convertedTotal = AccountsController.ConvertCurrency(tranzaction.Ammount, tranzaction.Account.Currency, tranzaction.Account1.Currency);
            
            tranzaction.Account.Total -= tranzaction.Ammount;
            tranzaction.Account1.Total += convertedTotal;


            return true;
        }
        
        public static string CreateIBAN()
        {
            using (Service.ServiceClient service = new Service.ServiceClient())
            {
                string iban = GenerateIBAN();
                if (service.VerifyIBAN(iban))
                    return iban;
                else
                    CreateIBAN();
            }

            return null;
        }

        private static string GenerateIBAN()
        {
            Random random = new Random();
            var ibanGenerator = new StringBuilder();
            string iban= "";

            ibanGenerator.Append("RO");
            for (int i = 1; i <= 22; i++)
            {
                if (i >= 3 && i <= 6)
                {
                    int temp = random.Next(65, 91);
                    string letter = Char.ConvertFromUtf32(temp);
                    ibanGenerator.Append(letter);
                    continue;
                }

                ibanGenerator.Append(random.Next(1, 10).ToString());
            }

            iban += ibanGenerator.ToString();

            return iban;
        }
    }
}
