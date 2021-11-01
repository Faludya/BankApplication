using Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService" in both code and config file together.
[ServiceContract]
public interface IService
{

    #region Login
    [OperationContract]
    int IsClientLoginValid(string cnp, string password);

    [OperationContract]
    int IsOperatorLoginValid(string cnp, string password);
    #endregion

    #region Client
    [OperationContract]
    ObservableCollection<Account> GetClientAccounts(int clientId);

    [OperationContract]
    bool ChangeClientPin(int clientId,string oldPin, string newPin);

    [OperationContract]
    bool UpdateAccountTotal(string iban, decimal newTotal, Int16 factor);
    #endregion

    #region Operator - Getters
    [OperationContract]
    ObservableCollection<Client> GetClients();

    [OperationContract]
    ObservableCollection<Account> GetAccounts();

    [OperationContract]
    ObservableCollection<AccountOffer> GetAccountOffers();
    [OperationContract]
    ObservableCollection<Tranzaction> GetTranzactions();
    #endregion

    #region Operator - Saves 
    [OperationContract]
    bool UpdateClient(Client client);

    [OperationContract]
    bool UpdateAccount(Account account);

    [OperationContract]
    bool UpdateAccountOffer(AccountOffer accountOffer);
    #endregion

    #region Operator - Removes 
    [OperationContract]
    bool RemoveClient(Client client);

    [OperationContract]
    bool RemoveAccount(Account account);

    [OperationContract]
    bool RemoveAccountOffer(AccountOffer accountOffer);
    #endregion

    #region Check
    [OperationContract]
    bool VerifyIBAN(string iban);
    #endregion

    #region Api Service
    [OperationContract]
    ExchangeCurrency GetLastExchangeRate();
    [OperationContract]
    bool UpdateExchangeRate(ExchangeCurrency newRate);
    [OperationContract]
    ObservableCollection<ExchangeCurrency> GetYearExchangeRate();
    [OperationContract]
    ObservableCollection<ExchangeCurrency> GetMonthExchangeRate(int month);
    #endregion
}

