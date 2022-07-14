using System;
using System.Collections.Generic;
using BankingSystem.Currency;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#endif

namespace BankingSystem
{
    /// <summary>
    /// Holds all banking cars that are related to the same user account.
    /// </summary>
    [Serializable]
    public class Account
    {
#if ODIN_INSPECTOR
        [TableList]
#endif
        [SerializeField]
        private List<BankCard> bankCards;

        public List<BankCard> BankCards => bankCards;

        public BankCard GetCardForCurrencyType(CurrencyType currencyType)
        {
            return BankCards.Find(card => card.CardCurrencyType == currencyType);
        }
    }
}