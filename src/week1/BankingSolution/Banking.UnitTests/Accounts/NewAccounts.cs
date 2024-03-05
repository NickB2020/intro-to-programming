

using Bank;

namespace Banking.UnitTests.Accounts;
public class NewAccounts
{
    [Fact]
    public void NewAccountsHaveCorrectOpeningBalance()
    {
        // WTCYWYH - "Write the code you WISH YOU HAD"
        // Given - I have a brand new account
        var account = new BankAccount();

        // WHEN I get the balance
        decimal openingBalance = account.GetBalance();

        Assert.Equal(5000M, openingBalance);
    }
}
