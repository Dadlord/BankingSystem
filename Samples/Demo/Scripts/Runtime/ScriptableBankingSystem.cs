using BOC.BTagged;
using UnityEngine;

namespace BankingSystem.Samples.Demo
{
    [CreateAssetMenu(fileName = nameof(ScriptableBankingSystem), menuName = nameof(BankingSystem) + "/" + nameof(ScriptableBankingSystem),
        order = 0)]
    public class ScriptableBankingSystem : BTaggedSO
    {
        [SerializeField] private BankingSystem bankingSystem;
        public BankingSystem BankingSystem => bankingSystem;
    }
}