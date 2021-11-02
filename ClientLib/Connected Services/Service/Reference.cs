﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientLib.Service {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Service.IService")]
    public interface IService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/IsClientLoginValid", ReplyAction="http://tempuri.org/IService/IsClientLoginValidResponse")]
        int IsClientLoginValid(string cnp, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/IsClientLoginValid", ReplyAction="http://tempuri.org/IService/IsClientLoginValidResponse")]
        System.Threading.Tasks.Task<int> IsClientLoginValidAsync(string cnp, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/IsOperatorLoginValid", ReplyAction="http://tempuri.org/IService/IsOperatorLoginValidResponse")]
        int IsOperatorLoginValid(string cnp, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/IsOperatorLoginValid", ReplyAction="http://tempuri.org/IService/IsOperatorLoginValidResponse")]
        System.Threading.Tasks.Task<int> IsOperatorLoginValidAsync(string cnp, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetClientAccounts", ReplyAction="http://tempuri.org/IService/GetClientAccountsResponse")]
        System.Collections.ObjectModel.ObservableCollection<Database.Account> GetClientAccounts(int clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetClientAccounts", ReplyAction="http://tempuri.org/IService/GetClientAccountsResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.Account>> GetClientAccountsAsync(int clientId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ChangeClientPin", ReplyAction="http://tempuri.org/IService/ChangeClientPinResponse")]
        bool ChangeClientPin(int clientId, string oldPin, string newPin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/ChangeClientPin", ReplyAction="http://tempuri.org/IService/ChangeClientPinResponse")]
        System.Threading.Tasks.Task<bool> ChangeClientPinAsync(int clientId, string oldPin, string newPin);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateAccountTotal", ReplyAction="http://tempuri.org/IService/UpdateAccountTotalResponse")]
        bool UpdateAccountTotal(string iban, decimal newTotal, decimal commission, short factor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateAccountTotal", ReplyAction="http://tempuri.org/IService/UpdateAccountTotalResponse")]
        System.Threading.Tasks.Task<bool> UpdateAccountTotalAsync(string iban, decimal newTotal, decimal commission, short factor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAccountOffer", ReplyAction="http://tempuri.org/IService/GetAccountOfferResponse")]
        Database.AccountOffer GetAccountOffer(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAccountOffer", ReplyAction="http://tempuri.org/IService/GetAccountOfferResponse")]
        System.Threading.Tasks.Task<Database.AccountOffer> GetAccountOfferAsync(int id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetClients", ReplyAction="http://tempuri.org/IService/GetClientsResponse")]
        System.Collections.ObjectModel.ObservableCollection<Database.Client> GetClients();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetClients", ReplyAction="http://tempuri.org/IService/GetClientsResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.Client>> GetClientsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAccounts", ReplyAction="http://tempuri.org/IService/GetAccountsResponse")]
        System.Collections.ObjectModel.ObservableCollection<Database.Account> GetAccounts();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAccounts", ReplyAction="http://tempuri.org/IService/GetAccountsResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.Account>> GetAccountsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAccountOffers", ReplyAction="http://tempuri.org/IService/GetAccountOffersResponse")]
        System.Collections.ObjectModel.ObservableCollection<Database.AccountOffer> GetAccountOffers();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetAccountOffers", ReplyAction="http://tempuri.org/IService/GetAccountOffersResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.AccountOffer>> GetAccountOffersAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetTranzactions", ReplyAction="http://tempuri.org/IService/GetTranzactionsResponse")]
        System.Collections.ObjectModel.ObservableCollection<Database.Tranzaction> GetTranzactions();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetTranzactions", ReplyAction="http://tempuri.org/IService/GetTranzactionsResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.Tranzaction>> GetTranzactionsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateClient", ReplyAction="http://tempuri.org/IService/UpdateClientResponse")]
        bool UpdateClient(Database.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateClient", ReplyAction="http://tempuri.org/IService/UpdateClientResponse")]
        System.Threading.Tasks.Task<bool> UpdateClientAsync(Database.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateAccount", ReplyAction="http://tempuri.org/IService/UpdateAccountResponse")]
        bool UpdateAccount(Database.Account account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateAccount", ReplyAction="http://tempuri.org/IService/UpdateAccountResponse")]
        System.Threading.Tasks.Task<bool> UpdateAccountAsync(Database.Account account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateAccountOffer", ReplyAction="http://tempuri.org/IService/UpdateAccountOfferResponse")]
        bool UpdateAccountOffer(Database.AccountOffer accountOffer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateAccountOffer", ReplyAction="http://tempuri.org/IService/UpdateAccountOfferResponse")]
        System.Threading.Tasks.Task<bool> UpdateAccountOfferAsync(Database.AccountOffer accountOffer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RemoveClient", ReplyAction="http://tempuri.org/IService/RemoveClientResponse")]
        bool RemoveClient(Database.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RemoveClient", ReplyAction="http://tempuri.org/IService/RemoveClientResponse")]
        System.Threading.Tasks.Task<bool> RemoveClientAsync(Database.Client client);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RemoveAccount", ReplyAction="http://tempuri.org/IService/RemoveAccountResponse")]
        bool RemoveAccount(Database.Account account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RemoveAccount", ReplyAction="http://tempuri.org/IService/RemoveAccountResponse")]
        System.Threading.Tasks.Task<bool> RemoveAccountAsync(Database.Account account);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RemoveAccountOffer", ReplyAction="http://tempuri.org/IService/RemoveAccountOfferResponse")]
        bool RemoveAccountOffer(Database.AccountOffer accountOffer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/RemoveAccountOffer", ReplyAction="http://tempuri.org/IService/RemoveAccountOfferResponse")]
        System.Threading.Tasks.Task<bool> RemoveAccountOfferAsync(Database.AccountOffer accountOffer);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/VerifyIBAN", ReplyAction="http://tempuri.org/IService/VerifyIBANResponse")]
        bool VerifyIBAN(string iban);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/VerifyIBAN", ReplyAction="http://tempuri.org/IService/VerifyIBANResponse")]
        System.Threading.Tasks.Task<bool> VerifyIBANAsync(string iban);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetLastExchangeRate", ReplyAction="http://tempuri.org/IService/GetLastExchangeRateResponse")]
        Database.ExchangeCurrency GetLastExchangeRate();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetLastExchangeRate", ReplyAction="http://tempuri.org/IService/GetLastExchangeRateResponse")]
        System.Threading.Tasks.Task<Database.ExchangeCurrency> GetLastExchangeRateAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateExchangeRate", ReplyAction="http://tempuri.org/IService/UpdateExchangeRateResponse")]
        bool UpdateExchangeRate(Database.ExchangeCurrency newRate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/UpdateExchangeRate", ReplyAction="http://tempuri.org/IService/UpdateExchangeRateResponse")]
        System.Threading.Tasks.Task<bool> UpdateExchangeRateAsync(Database.ExchangeCurrency newRate);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetYearExchangeRate", ReplyAction="http://tempuri.org/IService/GetYearExchangeRateResponse")]
        System.Collections.ObjectModel.ObservableCollection<Database.ExchangeCurrency> GetYearExchangeRate();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetYearExchangeRate", ReplyAction="http://tempuri.org/IService/GetYearExchangeRateResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.ExchangeCurrency>> GetYearExchangeRateAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetMonthExchangeRate", ReplyAction="http://tempuri.org/IService/GetMonthExchangeRateResponse")]
        System.Collections.ObjectModel.ObservableCollection<Database.ExchangeCurrency> GetMonthExchangeRate(int month);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService/GetMonthExchangeRate", ReplyAction="http://tempuri.org/IService/GetMonthExchangeRateResponse")]
        System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.ExchangeCurrency>> GetMonthExchangeRateAsync(int month);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : ClientLib.Service.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<ClientLib.Service.IService>, ClientLib.Service.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int IsClientLoginValid(string cnp, string password) {
            return base.Channel.IsClientLoginValid(cnp, password);
        }
        
        public System.Threading.Tasks.Task<int> IsClientLoginValidAsync(string cnp, string password) {
            return base.Channel.IsClientLoginValidAsync(cnp, password);
        }
        
        public int IsOperatorLoginValid(string cnp, string password) {
            return base.Channel.IsOperatorLoginValid(cnp, password);
        }
        
        public System.Threading.Tasks.Task<int> IsOperatorLoginValidAsync(string cnp, string password) {
            return base.Channel.IsOperatorLoginValidAsync(cnp, password);
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Database.Account> GetClientAccounts(int clientId) {
            return base.Channel.GetClientAccounts(clientId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.Account>> GetClientAccountsAsync(int clientId) {
            return base.Channel.GetClientAccountsAsync(clientId);
        }
        
        public bool ChangeClientPin(int clientId, string oldPin, string newPin) {
            return base.Channel.ChangeClientPin(clientId, oldPin, newPin);
        }
        
        public System.Threading.Tasks.Task<bool> ChangeClientPinAsync(int clientId, string oldPin, string newPin) {
            return base.Channel.ChangeClientPinAsync(clientId, oldPin, newPin);
        }
        
        public bool UpdateAccountTotal(string iban, decimal newTotal, decimal commission, short factor) {
            return base.Channel.UpdateAccountTotal(iban, newTotal, commission, factor);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateAccountTotalAsync(string iban, decimal newTotal, decimal commission, short factor) {
            return base.Channel.UpdateAccountTotalAsync(iban, newTotal, commission, factor);
        }
        
        public Database.AccountOffer GetAccountOffer(int id) {
            return base.Channel.GetAccountOffer(id);
        }
        
        public System.Threading.Tasks.Task<Database.AccountOffer> GetAccountOfferAsync(int id) {
            return base.Channel.GetAccountOfferAsync(id);
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Database.Client> GetClients() {
            return base.Channel.GetClients();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.Client>> GetClientsAsync() {
            return base.Channel.GetClientsAsync();
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Database.Account> GetAccounts() {
            return base.Channel.GetAccounts();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.Account>> GetAccountsAsync() {
            return base.Channel.GetAccountsAsync();
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Database.AccountOffer> GetAccountOffers() {
            return base.Channel.GetAccountOffers();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.AccountOffer>> GetAccountOffersAsync() {
            return base.Channel.GetAccountOffersAsync();
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Database.Tranzaction> GetTranzactions() {
            return base.Channel.GetTranzactions();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.Tranzaction>> GetTranzactionsAsync() {
            return base.Channel.GetTranzactionsAsync();
        }
        
        public bool UpdateClient(Database.Client client) {
            return base.Channel.UpdateClient(client);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateClientAsync(Database.Client client) {
            return base.Channel.UpdateClientAsync(client);
        }
        
        public bool UpdateAccount(Database.Account account) {
            return base.Channel.UpdateAccount(account);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateAccountAsync(Database.Account account) {
            return base.Channel.UpdateAccountAsync(account);
        }
        
        public bool UpdateAccountOffer(Database.AccountOffer accountOffer) {
            return base.Channel.UpdateAccountOffer(accountOffer);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateAccountOfferAsync(Database.AccountOffer accountOffer) {
            return base.Channel.UpdateAccountOfferAsync(accountOffer);
        }
        
        public bool RemoveClient(Database.Client client) {
            return base.Channel.RemoveClient(client);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveClientAsync(Database.Client client) {
            return base.Channel.RemoveClientAsync(client);
        }
        
        public bool RemoveAccount(Database.Account account) {
            return base.Channel.RemoveAccount(account);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveAccountAsync(Database.Account account) {
            return base.Channel.RemoveAccountAsync(account);
        }
        
        public bool RemoveAccountOffer(Database.AccountOffer accountOffer) {
            return base.Channel.RemoveAccountOffer(accountOffer);
        }
        
        public System.Threading.Tasks.Task<bool> RemoveAccountOfferAsync(Database.AccountOffer accountOffer) {
            return base.Channel.RemoveAccountOfferAsync(accountOffer);
        }
        
        public bool VerifyIBAN(string iban) {
            return base.Channel.VerifyIBAN(iban);
        }
        
        public System.Threading.Tasks.Task<bool> VerifyIBANAsync(string iban) {
            return base.Channel.VerifyIBANAsync(iban);
        }
        
        public Database.ExchangeCurrency GetLastExchangeRate() {
            return base.Channel.GetLastExchangeRate();
        }
        
        public System.Threading.Tasks.Task<Database.ExchangeCurrency> GetLastExchangeRateAsync() {
            return base.Channel.GetLastExchangeRateAsync();
        }
        
        public bool UpdateExchangeRate(Database.ExchangeCurrency newRate) {
            return base.Channel.UpdateExchangeRate(newRate);
        }
        
        public System.Threading.Tasks.Task<bool> UpdateExchangeRateAsync(Database.ExchangeCurrency newRate) {
            return base.Channel.UpdateExchangeRateAsync(newRate);
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Database.ExchangeCurrency> GetYearExchangeRate() {
            return base.Channel.GetYearExchangeRate();
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.ExchangeCurrency>> GetYearExchangeRateAsync() {
            return base.Channel.GetYearExchangeRateAsync();
        }
        
        public System.Collections.ObjectModel.ObservableCollection<Database.ExchangeCurrency> GetMonthExchangeRate(int month) {
            return base.Channel.GetMonthExchangeRate(month);
        }
        
        public System.Threading.Tasks.Task<System.Collections.ObjectModel.ObservableCollection<Database.ExchangeCurrency>> GetMonthExchangeRateAsync(int month) {
            return base.Channel.GetMonthExchangeRateAsync(month);
        }
    }
}
