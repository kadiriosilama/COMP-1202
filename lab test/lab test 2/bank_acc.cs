
using System;

class BankAccount
{
    private string account_Number;
    private string account_Holder_Name;
    private double current_Balance;

    public BankAccount(string account_Number, string account_Holder_Name, double current_Balance)
    {
        this.account_Number = account_Number;
        this.account_Holder_Name = account_Holder_Name;
        this.current_Balance = current_Balance;
    }

    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            current_Balance += amount;
            Console.WriteLine($"Deposited {amount} into account {account_Number}.");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount.");
        }
    }

    public void Withdraw(double amount)
    {
        if (amount > 0)
        {
            if (current_Balance >= amount)
            {
                current_Balance -= amount;
                Console.WriteLine($"Withdrew {amount} from account {account_Number}.");
            }
            else
            {
                Console.WriteLine("Insufficient funds.");
            }
        }
        else
        {
            Console.WriteLine("Invalid withdrawal amount.");
        }
    }

    public double GetBalance()
    {
        return current_Balance;
    }

    public override string ToString()
    {
        return $"Account Number: {account_Number}\nAccount Holder's Name: {account_Holder_Name}\nCurrent Balance: {current_Balance}";
    }
}

class TestBankAccount
{
    public static void Main(string[] args)
    {
        // Creating instances of BankAccount
        BankAccount account1 = new BankAccount("278383995", "Adekunle Mankinde", 0.2);

int account_number = "278383995";
                account_holder_name = "Adekunle Mankinde";
                current_balance = 0.2;
        // Displaying object in the console
        Console.WriteLine("Bank Account Details:");
        Console.WriteLine(account1.ToString());

        // Performing operations
        account1.Deposit(500);
        Console.WriteLine("Current Balance after deposit: " + account1.GetBalance());

        account1.Withdraw(200);
        Console.WriteLine("Current Balance after withdrawal: " + account1.GetBalance());
    }
}


    