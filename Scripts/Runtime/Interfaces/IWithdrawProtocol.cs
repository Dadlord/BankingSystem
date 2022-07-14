using System;
using BankingSystem.Currency;
using BankingSystem.ReportModels;

namespace BankingSystem.Interfaces
{
    public interface IWithdrawProtocol
    {
        event Action<WithdrawReport> CurrencyWithdrawOccured;
        WithdrawReport TryToWithdraw(CurrencyAmount currencyAmount);
    }
}