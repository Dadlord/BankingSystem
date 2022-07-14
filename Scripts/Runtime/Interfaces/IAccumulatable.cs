using System;
using BankingSystem.Currency;
using BankingSystem.ReportModels;

namespace BankingSystem.Interfaces
{
    internal interface IAccumulatable
    {
        event Action<IncomeAccumulationReport> CurrencyAccumulationOccurred;

        IncomeAccumulationReport TryToAccumulateIncome(CurrencyAmount currencyAmount);
    }
}