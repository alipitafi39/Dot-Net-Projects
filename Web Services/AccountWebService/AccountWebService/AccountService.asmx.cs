using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AccountWebService
{
    /// <summary>
    /// Summary description for AccountService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AccountService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        private List<Account> GetDummyAccounts()
        {
            List<Account> accounts =
                new List<Account>();

            accounts.Add(new Account
            {
                AccountId = 1001,
                AccountNumber = "ACC-1001",
                AccountName = "Ali Khan",
                AccountType = "Savings",
                Balance = 25000.50m,
                Status = "Active"
            });

            accounts.Add(new Account
            {
                AccountId = 1002,
                AccountNumber = "ACC-1002",
                AccountName = "Ahmed Raza",
                AccountType = "Current",
                Balance = 85000.00m,
                Status = "Active"
            });

            accounts.Add(new Account
            {
                AccountId = 1003,
                AccountNumber = "ACC-1003",
                AccountName = "John Smith",
                AccountType = "Savings",
                Balance = 12500.75m,
                Status = "Inactive"
            });

            accounts.Add(new Account
            {
                AccountId = 1004,
                AccountNumber = "ACC-1004",
                AccountName = "Sarah Khan",
                AccountType = "Business",
                Balance = 150000.25m,
                Status = "Active"
            });

            accounts.Add(new Account
            {
                AccountId = 1005,
                AccountNumber = "ACC-1005",
                AccountName = "David Wilson",
                AccountType = "Savings",
                Balance = 45000.00m,
                Status = "Active"
            });

            return accounts;
        }

        // =========================================
        // GET ALL ACCOUNTS
        // =========================================

        [WebMethod]
        public List<Account> GetAllAccounts()
        {
            return GetDummyAccounts();
        }


        // =========================================
        // GET ACCOUNT BY ACCOUNT NUMBER
        // =========================================

        [WebMethod]
        public Account GetAccount(string accountNumber)
        {
            List<Account> accounts =
                GetDummyAccounts();

            Account account =
                accounts.FirstOrDefault(x =>
                    x.AccountNumber.ToLower() ==
                    accountNumber.Trim().ToLower());

            return account;
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
}
