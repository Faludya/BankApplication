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
    }
}
