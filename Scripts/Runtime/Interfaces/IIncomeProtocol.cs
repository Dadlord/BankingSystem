using System;
using BankingSystem.Currency;
using BankingSystem.ReportModels;

namespace BankingSystem.Interfaces
{
    public interface IIncomeProtocol
    {
        event Action<IncomeAccumulationReport>  CurrencyIncomeOccurred;
        IncomeAccumulationReport TryToAccumulateIncome(CurrencyAmount currencyAmount);
    }
}