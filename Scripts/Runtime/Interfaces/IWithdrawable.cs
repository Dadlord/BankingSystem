using System;
using BankingSystem.Currency;
using BankingSystem.ReportModels;

namespace BankingSystem.Interfaces
{
    internal interface IWithdrawable
    {
        event Action<WithdrawReport> CurrencyWithdrawOccured;
        WithdrawReport TryToWithdraw(CurrencyAmount currencyAmount);
    }
}