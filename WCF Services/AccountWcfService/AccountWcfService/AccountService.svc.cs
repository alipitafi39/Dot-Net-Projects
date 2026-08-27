using System.Collections.Generic;
using System.Linq;

namespace AccountWcfService
{
    public class AccountService : IAccountService
    {
        public List<Account> GetAccounts()
        {
            return new List<Account>
            {
                new Account
                {
                    AccountId = 1,
                    AccountNumber = "100001",
                    AccountName = "Ali Khan",
                    AccountType = "Saving",
                    Balance = 25000.50m,
                    Status = "Active"
                },

                new Account
                {
                    AccountId = 2,
                    AccountNumber = "100002",
                    AccountName = "Ahmed Raza",
                    AccountType = "Current",
                    Balance = 75000.00m,
                    Status = "Active"
                },

                new Account
                {
                    AccountId = 3,
                    AccountNumber = "100003",
                    AccountName = "Sara Ahmed",
                    AccountType = "Saving",
                    Balance = 12500.75m,
                    Status = "Active"
                },

                new Account
                {
                    AccountId = 4,
                    AccountNumber = "100004",
                    AccountName = "Usman Ali",
                    AccountType = "Current",
                    Balance = 150000.00m,
                    Status = "Inactive"
                },

                new Account
                {
                    AccountId = 5,
                    AccountNumber = "100005",
                    AccountName = "Fatima Noor",
                    AccountType = "Saving",
                    Balance = 45000.25m,
                    Status = "Active"
                }
            };
        }

        public Account GetAccount(string accountNumber)
        {
            return GetAccounts()
                .FirstOrDefault(a => a.AccountNumber == accountNumber);
        }
    }
}
