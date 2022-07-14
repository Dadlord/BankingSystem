using BankingSystem.Currency;

namespace BankingSystem.ReportModels
{
    public readonly struct IncomeAccumulationReport
    {
        public readonly bool WasOperationSuccessful;
        public readonly CurrencyAmount CurrencyAmountAccumulated;

        public IncomeAccumulationReport(bool wasOperationSuccessful, CurrencyAmount currencyAmountAccumulated)
        {
            WasOperationSuccessful = wasOperationSuccessful;
            CurrencyAmountAccumulated = currencyAmountAccumulated;
        }
    }
}