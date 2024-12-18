using MeowRescue.Utilities;
using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;

    private void Start()
    {
        Observer.Instance.OnGoldChanged += UpdateCurrency;
    }

    public void UpdateCurrency(int currency)
    {
        currencyText.text = currency.ToString();
    }
}