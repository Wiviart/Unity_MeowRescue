using TMPro;
using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;

    public void UpdateCurrency(int currency)
    {
        currencyText.text = currency.ToString();
    }
}