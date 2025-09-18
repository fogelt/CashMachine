namespace CashMachine.Models
{
    class BankAccount
    {
        private decimal balance;

        public decimal Balance => balance;

        public BankAccount(decimal initialBalance = 0)
        {
            balance = initialBalance;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit must be positive.");
            balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Withdraw must be positive.");
            if (amount > balance)
                return false;
            balance -= amount;
            return true;
        }
    }
}
