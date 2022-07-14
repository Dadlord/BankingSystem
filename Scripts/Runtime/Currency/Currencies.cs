using BOC.BTagged;
using UnityEngine;

namespace BankingSystem.Currency
{
    [CreateAssetMenu(fileName = nameof(Currencies), menuName = nameof(BankingSystem) + "/" + nameof(Currency) + "/" + nameof(Currencies), order = 0)]
    public class Currencies : BTaggedGroup<CurrencyType>
    {
    }
}