using System;
using BankingSystem.Currency;
using BankingSystem.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BankingSystem.Samples.Demo
{
    [Serializable]
    internal class TransactionsEmitter
    {
        [SerializeField] private CurrencyAmount amount;
        private IWithdrawProtocol _withdrawProtocol;
        private IIncomeProtocol _incomeProtocol;


        public void SetDependencies(IWithdrawProtocol withdrawProtocol, IIncomeProtocol incomeProtocol)
        {
            _withdrawProtocol = withdrawProtocol;
            _incomeProtocol = incomeProtocol;
        }

        [Button]
        public void PerformIncome()
        {
            _incomeProtocol.TryToAccumulateIncome(amount);
        }

        [Button]
        public void PerformSpend()
        {
            _withdrawProtocol.TryToWithdraw(amount);
        }
    }

    public class BankOperations : MonoBehaviour
    {
        [SerializeField] private ScriptableBankingSystem bankingSystem;
        [SerializeField] private TransactionsEmitter[] transactionsEmitters;

        private void Start()
        {
            for (int i = 0; i < transactionsEmitters.Length; i++)
            {
                transactionsEmitters[i].SetDependencies(bankingSystem.BankingSystem, bankingSystem.BankingSystem);
            }
        }
    }
}