using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace BankingSystem.Currency
{
    [Serializable, InlineProperty]
    public struct CurrencyAmount : IComparable<CurrencyAmount>
    {
        [SerializeField] private double amount;
        public double Amount => amount;


        [SerializeField] public CurrencyType currencyType;

        public CurrencyType CurrencyType => currencyType;

        public CurrencyAmount(CurrencyType currencyType, double amount)
        {
            this.currencyType = currencyType;
            this.amount = amount;
        }

        public static CurrencyAmount operator +(CurrencyAmount left, CurrencyAmount right)
        {
            return new CurrencyAmount(left.CurrencyType, left.amount + right.amount);
        }
        
        public static CurrencyAmount operator -(CurrencyAmount left, CurrencyAmount right)
        {
            return new CurrencyAmount(left.CurrencyType, left.amount - right.amount);
        }

        public bool Equals(CurrencyAmount other)
        {
            return amount.Equals(other.amount);
        }

        public override bool Equals(object obj)
        {
            return obj is CurrencyAmount other && Equals(other);
        }

        public override int GetHashCode()
        {
            return amount.GetHashCode();
        }

        public static bool operator ==(CurrencyAmount left, CurrencyAmount right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CurrencyAmount left, CurrencyAmount right)
        {
            return !left.Equals(right);
        }

        public int CompareTo(CurrencyAmount other)
        {
            return amount.CompareTo(other.amount);
        }

        public static bool operator <(CurrencyAmount left, CurrencyAmount right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(CurrencyAmount left, CurrencyAmount right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(CurrencyAmount left, CurrencyAmount right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(CurrencyAmount left, CurrencyAmount right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static CurrencyAmount Zero(CurrencyType cardCurrencyType)
        {
            return new CurrencyAmount(cardCurrencyType, 0);
        }
    }
}