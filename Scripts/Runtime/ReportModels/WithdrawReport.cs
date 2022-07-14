using BankingSystem.Currency;

namespace BankingSystem.ReportModels
{
    public readonly struct WithdrawReport
    {
        public readonly bool WasOperationSuccessful;
        public readonly CurrencyAmount CurrencyAmountWithdrawn;

        public WithdrawReport(bool wasOperationSuccessful, CurrencyAmount currencyAmountWithdrawn)
        {
            WasOperationSuccessful = wasOperationSuccessful;
            CurrencyAmountWithdrawn = currencyAmountWithdrawn;
        }
    }
}