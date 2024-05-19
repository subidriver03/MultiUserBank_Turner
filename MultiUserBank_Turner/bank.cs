using System;
using System.Collections.Generic;

public class Bank
{
    private const decimal InitialBankBalance = 10000m;
    private decimal _currentBankBalance;
    private Dictionary<string, (string Password, decimal Balance)> _accounts;

    public Bank()
    {
        _currentBankBalance = InitialBankBalance;
        _accounts = new Dictionary<string, (string Password, decimal Balance)>
        {
            { "jlennon", ("johnny", 1250m) },
            { "pmccartney", ("pauly", 2500m) },
            { "gharrison", ("georgy", 3000m) },
            { "rstarr", ("ringoy", 1001m) }
        };
    }

    public decimal BankBalance => _currentBankBalance;

    public bool Login(string username, string password)
    {
        if (_accounts.ContainsKey(username) && _accounts[username].Password == password)
        {
            return true;
        }
        return false;
    }

    public decimal GetBalance(string username)
    {
        if (_accounts.ContainsKey(username))
        {
            return _accounts[username].Balance;
        }
        return 0;
    }

    public decimal Deposit(string username, decimal amount)
    {
        if (_accounts.ContainsKey(username))
        {
            _accounts[username] = (_accounts[username].Password, _accounts[username].Balance + amount);
            _currentBankBalance += amount;
            return _accounts[username].Balance;
        }
        return 0;
    }

    public decimal Withdraw(string username, decimal amount)
    {
        if (_accounts.ContainsKey(username))
        {
            decimal availableAmount = Math.Min(amount, _accounts[username].Balance);
            if (availableAmount > 500) availableAmount = 500;
            _accounts[username] = (_accounts[username].Password, _accounts[username].Balance - availableAmount);
            _currentBankBalance -= availableAmount;
            return _accounts[username].Balance;
        }
        return 0;
    }
}
