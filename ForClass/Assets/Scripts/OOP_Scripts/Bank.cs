using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Bank : MonoBehaviour
{
    private List<BankAccount> accounts = new List<BankAccount>();
    public void deposit(float amount, BankAccount account)
    {
        // Deposit the amount
        account.deposit(amount);
        Debug.Log("Deposit successful. Amount: " + amount);

    }
    public void withdraw(float amount, BankAccount account, int password)
    {
        if (account.checkPassword(password))
        {
            if (account.GetBalance() >= amount)
            {
                // Withdraw the amount
                account.withdraw(amount, account, password);
                Debug.Log("Withdrawal successful. Amount: " + amount);
            }
            else
            {
                Debug.Log("Insufficient funds.");
            }
        }
        else
        {
            Debug.Log("Incorrect password.");
        }
    }

    public void transfer(float amount, BankAccount fromAccount, BankAccount toAccount, int password)
    {
        if (fromAccount.checkPassword(password))
        {
            if (fromAccount.GetBalance() >= amount)
            {
                // Transfer the amount
                toAccount.deposit(amount); // Deposit to the destination account
                fromAccount.withdraw(amount, fromAccount, password); // Withdraw from the source account
                Debug.Log("Transfer successful. Amount: " + amount);
            }
            else
            {
                Debug.Log("Insufficient funds.");
            }
        }
        else
        {
            Debug.Log("Incorrect password.");
        }
    }
    public void createAccount(string holder, float initialBalance, int password)
    {
        BankAccount newAccount = new BankAccount(holder, initialBalance, password);
        accounts.Add(newAccount);
        
        Debug.Log("Account created for " + holder);
    }
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        if (accounts.Count > 0)
        {
            deposit(100, accounts[0]);
        }
    }
    
}
public class BankAccount
{
    private string accountHolder;
    private float balance;
    private int password;

    public BankAccount(string holder, float initialBalance,int password)
    {
        accountHolder = holder;
        balance = initialBalance;
        this.password = password;
    }
    public void deposit(float amount)
    {
        balance += amount;
    }
    public void withdraw(float amount, BankAccount account,int password)
    {
        if (account.checkPassword(password))
        {
            balance -= amount;
        }
    }
    public float GetBalance()
    {
        return balance;
    }
    public bool checkPassword(int inputPassword)
    {
        return inputPassword == password;
    }
}
