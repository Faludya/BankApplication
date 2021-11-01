using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
                                Where(c => c.CNP == cnp && c.PIN == password).
                                FirstOrDefault();
                if (client != null && client.Id != 1)
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
        try
        {
            using (BankEntities database = new BankEntities())
            {
                Client client = database.Clients.
                                Where(c => c.CNP == cnp && c.PIN == password).
                                FirstOrDefault();

                if (client.Id == 1)
                    return client.Id;
            }

            return -1;
        }
        catch (Exception ex)
        {
            return -1;
        }
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

    #region Operator 

    public ObservableCollection<Client> GetClients()
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                ObservableCollection<Client> clientsList = new ObservableCollection<Client>();

                foreach (Client client in database.Clients)
                    if(client.Id != 1)
                        clientsList.Add(client);

                return clientsList;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public ObservableCollection<Account> GetAccounts()
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                ObservableCollection<Account> accountsList = new ObservableCollection<Account>();

                foreach (Account account in database.Accounts)
                    accountsList.Add(account);

                return accountsList;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public ObservableCollection<AccountOffer> GetAccountOffers()
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                ObservableCollection<AccountOffer> accountOffersList = new ObservableCollection<AccountOffer>();

                foreach (AccountOffer accountOffer in database.AccountOffers)
                    accountOffersList.Add(accountOffer);

                return accountOffersList;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public ObservableCollection<Tranzaction> GetTranzactions()
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                ObservableCollection<Tranzaction> tranzactionsList = new ObservableCollection<Tranzaction>();

                foreach (Tranzaction tranzaction in database.Tranzactions)
                    tranzactionsList.Add(tranzaction);

                return tranzactionsList;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    #endregion

    #region Operators Update 
    public bool UpdateClient(Client newClient)
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                if (newClient.Id == 1)
                    return false;

                if (newClient.Id == 0)
                {
                    newClient.PIN = "0000";
                    database.Clients.Add(newClient);
                    database.SaveChanges();

                    return true;
                }


                database.Clients.AddOrUpdate(newClient);
                database.SaveChanges();

                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool UpdateAccount(Account account)
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                if (account.ID_Client == 1)
                    return false;

                database.Accounts.AddOrUpdate(account);
                database.SaveChanges();

                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool UpdateAccountOffer(AccountOffer accountOffer)
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                database.AccountOffers.AddOrUpdate(accountOffer);
                database.SaveChanges();

                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    #endregion

    #region Operator Remove
    public bool RemoveClient(Client client)
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                if (client.Id == 1)
                    return false;


                //database.Clients.Remove(client);
                database.Entry(client).State = EntityState.Deleted;
                database.SaveChanges();

                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool RemoveAccount(Account account)
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                if (account.ID_Client == 1)
                    return false;

                //database.Accounts.Remove(account);
                database.Entry(account).State = EntityState.Deleted;
                database.SaveChanges();

                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public bool RemoveAccountOffer(AccountOffer accountOffer)
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                //database.Accounts.Remove(account);
                database.Entry(accountOffer).State = EntityState.Deleted;
                database.SaveChanges();

                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    #endregion

    public bool VerifyIBAN(string iban)
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                Account account = database.Accounts.Where(i => i.IBAN == iban).FirstOrDefault();
                
                if (account == null)
                    return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    #region Api Service
    public ExchangeCurrency GetLastExchangeRate()
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                ExchangeCurrency currency = database.ExchangeCurrencies.
                                            OrderByDescending(d => d.Date).
                                            FirstOrDefault();
                return currency;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public bool UpdateExchangeRate(ExchangeCurrency newRate)
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                database.ExchangeCurrencies.AddOrUpdate(newRate);
                database.SaveChanges();
                return true;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public ObservableCollection<ExchangeCurrency> GetYearExchangeRate()
    {
        try
        {
            using (BankEntities database = new BankEntities())
            {
                ObservableCollection<ExchangeCurrency> yearList = new ObservableCollection<ExchangeCurrency>();

                foreach (ExchangeCurrency rate in database.ExchangeCurrencies)
                    if (rate.Date.Year == DateTime.Now.Year && rate.Date.Day == 1)
                        yearList.Add(rate);

                return yearList;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public ObservableCollection<ExchangeCurrency> GetMonthExchangeRate(int month)
    {
        if (month > DateTime.Now.Month)
            return null;

        try
        {
            using (BankEntities database = new BankEntities())
            {
                ObservableCollection<ExchangeCurrency> monthList = new ObservableCollection<ExchangeCurrency>();

                foreach (ExchangeCurrency rate in database.ExchangeCurrencies)
                {
                    if (DateTime.Now.Day <= 7 && month == DateTime.Now.Month)
                    {
                        if (rate.Date.Month == month - 1 && rate.Date.Day >= 21)
                            monthList.Add(rate);
                    }

                    if (rate.Date.Month == month)
                        monthList.Add(rate);
                }
                    

                return monthList;
            }
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    #endregion
}
