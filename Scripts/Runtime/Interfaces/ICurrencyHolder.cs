using System;
using BankingSystem.Currency;

namespace BankingSystem.Interfaces
{
    /// <summary>
    /// Allows to get current amount and be notified when it changed.
    /// </summary>
    public interface ICurrencyHolder
    {
        event Action<CurrencyAmount> AmountChanged;
        public CurrencyAmount CurrentAmount { get; }
    }
}