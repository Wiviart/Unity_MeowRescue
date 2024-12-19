using MeowRescue.Utilities;
using TMPro;
using UnityEngine;

namespace MeowRescue.UI
{
    public class CurrencyUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currencyText;

        private void Start()
        {
            Observer.Instance.OnGoldChanged += UpdateCurrency;
        }

        private void UpdateCurrency(int currency)
        {
            currencyText.text = currency.ToString();
        }
    }
}