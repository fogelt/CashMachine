namespace CashMachine.Models
{
    class Customer
    {
        public Person Person { get; }
        public BankAccount Account { get; }
        public const string PIN = "1234";

        public Customer(Person person, BankAccount account, string pin)
        {
            Person = person;
            Account = account;
            pin = PIN;
        }

        public bool Authenticate(string pin)
        {
            return pin == PIN;
        }
    }
}
