using System;
using BankingSystem.Currency;
using BankingSystem.Interfaces;
using BankingSystem.ReportModels;
using UnityEngine;

namespace BankingSystem
{
    [Serializable]
    public class BankCard : ICurrencyHolder, IWithdrawable, IAccumulatable
    {
        public event Action<CurrencyAmount> AmountChanged;
        public event Action<WithdrawReport> CurrencyWithdrawOccured;
        public event Action<IncomeAccumulationReport> CurrencyAccumulationOccurred;

        [SerializeField] private CurrencyAmount currencyAmount;

        public CurrencyAmount CurrentAmount
        {
            get => currencyAmount;
            private set
            {
                currencyAmount = value;
                OnAmountChanged(currencyAmount);
            }
        }

        public CurrencyType CardCurrencyType => CurrentAmount.CurrencyType;

        WithdrawReport IWithdrawable.TryToWithdraw(CurrencyAmount amountToWithdraw)
        {
            WithdrawReport report = CanBeWithdraw(amountToWithdraw)
                ? new WithdrawReport(true, amountToWithdraw)
                : new WithdrawReport(false, CurrencyAmount.Zero(CardCurrencyType));
            if (report.WasOperationSuccessful)
            {
                CurrentAmount -= amountToWithdraw;
                OnCurrencyWithdrawOccured(report);
            }

            return report;
        }

        IncomeAccumulationReport IAccumulatable.TryToAccumulateIncome(CurrencyAmount amountToAccumulate)
        {
            IncomeAccumulationReport report = CanAccumulate(amountToAccumulate)
                ? new IncomeAccumulationReport(true, amountToAccumulate)
                : new IncomeAccumulationReport(false, CurrencyAmount.Zero(CardCurrencyType));
            if (report.WasOperationSuccessful)
            {
                CurrentAmount += amountToAccumulate;
                OnCurrencyAccumulationOccurred(report);
            }

            return report;
        }

        private bool CanBeWithdraw(CurrencyAmount amount)
        {
            return CurrentAmount >= amount;
        }

        /// <summary>
        /// Checks if it is possible to accumulate given amount. For now there is no limits to what can be accumulated.
        /// </summary>
        /// <param name="amount">Amount of currency that will be accumulated</param>
        /// <returns></returns>
        private bool CanAccumulate(CurrencyAmount amount)
        {
            return true;
        }

        protected virtual void OnCurrencyWithdrawOccured(in WithdrawReport report)
        {
            CurrencyWithdrawOccured?.Invoke(report);
        }

        protected virtual void OnCurrencyAccumulationOccurred(in IncomeAccumulationReport report)
        {
            CurrencyAccumulationOccurred?.Invoke(report);
        }

        protected virtual void OnAmountChanged(CurrencyAmount newAmount)
        {
            AmountChanged?.Invoke(newAmount);
        }
    }
}