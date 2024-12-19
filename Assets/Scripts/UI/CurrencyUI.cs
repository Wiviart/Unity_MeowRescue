using MeowRescue.Utilities;
using TMPro;
using UnityEngine;

namespace MeowRescue.UI
{
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currencyText;

        private void OnEnable()
        {
            Observer.Instance.OnGoldChanged += UpdateCurrency;
        }

        private void UpdateCurrency(int currency)
        {
            currencyText.text = currency.ToString();
        }
    }
}