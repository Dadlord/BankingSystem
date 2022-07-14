using BankingSystem.Currency;
using BankingSystem.Interfaces;
using TMPro;
using UnityEngine;

namespace BankingSystem.Samples.Demo
{
    public class CurrencyOfTypeView : MonoBehaviour
    {
        [SerializeField] private CurrencyType currencyTypeToReflect;
        [SerializeField] private ScriptableBankingSystem bankSystemToOperateWith;

        [SerializeField] private TMP_Text labelField;
        [SerializeField] private TMP_Text valueField;

        private ICurrencyHolderProvider CurrencyHolderProvider => bankSystemToOperateWith.BankingSystem;
        private ICurrencyHolder CorrespondingCurrencyHolder => CurrencyHolderProvider.GetCurrencyHolderOfType(currencyTypeToReflect);

        private void Start()
        {
            FetchDataToView();
        }

        private void OnValidate()
        {
            FetchDataToView();
        }

        private void OnEnable()
        {
            CurrencyHolderProvider.GetCurrencyHolderOfType(currencyTypeToReflect).AmountChanged += OnAmountChanged;
        }

        private void OnDisable()
        {
            CurrencyHolderProvider.GetCurrencyHolderOfType(currencyTypeToReflect).AmountChanged -= OnAmountChanged;
        }

        private void FetchDataToView()
        {
            labelField.text = currencyTypeToReflect.ShortName;
            valueField.text = CorrespondingCurrencyHolder.CurrentAmount.Amount.ToString();
        }

        private void OnAmountChanged(CurrencyAmount newAmount)
        {
            valueField.text = newAmount.Amount.ToString();
        }
    }
}