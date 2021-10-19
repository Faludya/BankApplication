using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
public class Service : IService
{
    #region Login
    public int IsClientLoginValid(string cnp, string password)
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                Client client = database.Clients.
                                Where(c => c.CNP == cnp).
                                FirstOrDefault();
                if (client != null)
                    return client.Id;
            }

            return -1;
        }
        catch (Exception ex)
        {
            return -1;
        }
    }

    public int IsOperatorLoginValid(string cnp, string password)
    {
        //TODO: finish implementing operator validation
        return -1;
    }
    #endregion

    #region Client
    public ObservableCollection<Account> GetClientAccounts(int clientId)
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                ObservableCollection<Account> accountsList = new ObservableCollection<Account>();

                foreach (Account account in database.Accounts)
                    if(account.ID_Client == clientId)
                        accountsList.Add(account);

                return accountsList;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool ChangeClientPin(int clientId,string oldPin, string newPin)
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                Client client = database.Clients.Single(c => c.Id == clientId && c.PIN == oldPin);
                
                if(client != null)
                {
                    client.PIN = newPin;
                    database.SaveChanges();

                    return true;
                }

                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool UpdateAccountTotal(string iban, decimal newTotal, Int16 factor)
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                Account account= database.Accounts.Single(c => c.IBAN == iban);

                if (account != null)
                {
                    if(account.Total + factor * newTotal >= 0)
                    {
                        account.Total = account.Total + factor * newTotal;
                        database.SaveChanges();

                        return true;
                    }
                }

                return false;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    #endregion
}
