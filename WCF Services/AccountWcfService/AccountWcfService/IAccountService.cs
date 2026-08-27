using System.Collections.Generic;
using System.ServiceModel;

namespace AccountWcfService
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        List<Account> GetAccounts();

        [OperationContract]
        Account GetAccount(string accountNumber);
    }

    public class Account
    {

        public int AccountId { get; set; }

        public string AccountNumber { get; set; }

        public string AccountName { get; set; }

        public string AccountType { get; set; }

        public decimal Balance { get; set; }

        public string Status { get; set; }
    }
}