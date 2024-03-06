
using Bank;

namespace Banking.UnitTests.Accounts;
public class MakingWithdrawls
{

    [Theory]
    [InlineData(100)]
    [InlineData(2.25)]
    public void MakingAWithdrawalDecreasesTheBalance(decimal amountToWithdraw)
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        account.Withdraw(amountToWithdraw);

        Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
    }

    [Fact]
    public void OverdraftNotAllowed()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();

        account.Withdraw(account.GetBalance() + .01M);

        Assert.Equal(openingBalance, account.GetBalance());
    }

    [Fact]
    public void AreAnyDecimalsAllowed()
    {
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        /*bool rightExceptionThrown = false;

        try
        {
            account.Withdraw(-5230);
        }
        catch (InvalidTransactionAmountException)
        {

            rightExceptionThrown = true;
        }
        finally
        {
            Assert.Equal(5000M, account.GetBalance());
            Assert.True(rightExceptionThrown);
        }*/

        Assert.Throws<InvalidTransactionAmountException>(() => account.Withdraw(-1.1M));

        Assert.Equal(openingBalance, account.GetBalance());
    }
}
