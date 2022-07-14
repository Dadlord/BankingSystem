using BankingSystem.Currency;

namespace BankingSystem.Interfaces
{
    public interface ICurrencyHolderProvider
    {
        ICurrencyHolder GetCurrencyHolderOfType(CurrencyType currencyType);
    }
}