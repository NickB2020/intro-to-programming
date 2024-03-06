



namespace Bank;

public class BankAccount
{
    private decimal _currentBalance = 5000M;
    public void Deposit(decimal amountToDeposit)
    {

        GuardTransactionAmount(amountToDeposit);
        _currentBalance += amountToDeposit;
    }

    private void GuardTransactionAmount(decimal amountToDeposit)
    {
        // Never type Private, alwasy refactor to it.
        if (amountToDeposit <= 0)
        {
            throw new InvalidTransactionAmountException();
        }
    }

    public decimal GetBalance()
    {
        return _currentBalance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw <= 0)
        {
            throw new InvalidTransactionAmountException();
        }
        _currentBalance -= amountToWithdraw;
    }
}
