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
    #endregion
}

