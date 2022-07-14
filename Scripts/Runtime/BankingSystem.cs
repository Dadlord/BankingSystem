using System;
using BankingSystem.Currency;
using BankingSystem.Interfaces;
using BankingSystem.ReportModels;
using UnityEngine;
using UnityEngine.Assertions;

namespace BankingSystem
{
    [Serializable]
    public class BankingSystem : IIncomeProtocol, IWithdrawProtocol, ICurrencyHolderProvider
    {
        #region Classes declaration

        /// <summary>
        /// Serves to perform and track currency accumulation for accounts. 
        /// </summary>
        internal class IncomeComponent
        {
            public IncomeAccumulationReport PerformIncomeAccumulationForAccount(Account account, CurrencyAmount currencyAmount)
            {
                CurrencyType currencyType = currencyAmount.CurrencyType;
                IAccumulatable accumulatable = account.GetCardForCurrencyType(currencyType);
                Assert.IsNotNull(accumulatable, $"There is no card of type {currencyType} in given account");
                return accumulatable.TryToAccumulateIncome(currencyAmount);
            }
        }

        /// <summary>
        /// Serves to perform and track currency spend for accounts. 
        /// </summary>
        internal class SpendingComponent
        {
            public WithdrawReport PerformSpentForAccount(Account account, CurrencyAmount currencyAmount)
            {
                CurrencyType currencyType = currencyAmount.CurrencyType;
                IWithdrawable withdrawable = account.GetCardForCurrencyType(currencyType);
                Assert.IsNotNull(withdrawable, $"There is no card of type {currencyType} in given account");
                return withdrawable.TryToWithdraw(currencyAmount);
            }
        }

        #endregion

        private IncomeComponent _incomeComponent = new();
        private SpendingComponent _spendingComponent = new();

        #region Intefaces Implementation

        public event Action<IncomeAccumulationReport> CurrencyIncomeOccurred;

        public IncomeAccumulationReport TryToAccumulateIncome(CurrencyAmount currencyAmount)
        {
            IncomeAccumulationReport report = _incomeComponent.PerformIncomeAccumulationForAccount(account, currencyAmount);
            OnCurrencyIncomeOccurred(report);
            return report;
        }

        public event Action<WithdrawReport> CurrencyWithdrawOccured;

        public WithdrawReport TryToWithdraw(CurrencyAmount currencyAmount)
        {
            WithdrawReport report = _spendingComponent.PerformSpentForAccount(account, currencyAmount);
            OnCurrencyWithdrawOccured(report);
            return report;
        }

        #endregion

        [SerializeField] private Account account;

        public ICurrencyHolder GetCurrencyHolderOfType(CurrencyType currencyType)
        {
            return account.GetCardForCurrencyType(currencyType);
        }

        private void OnCurrencyWithdrawOccured(in WithdrawReport report)
        {
            CurrencyWithdrawOccured?.Invoke(report);
        }

        private void OnCurrencyIncomeOccurred(in IncomeAccumulationReport report)
        {
            CurrencyIncomeOccurred?.Invoke(report);
        }
    }
}