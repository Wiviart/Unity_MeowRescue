using System;
using MeowRescue.Data;
using MeowRescue.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    [SerializeField] private StatsType upgradeType;
    [SerializeField] private TextMeshProUGUI upgradeName;
    [SerializeField] private TextMeshProUGUI currentValue;
    [SerializeField] private TextMeshProUGUI upgradeCost;
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Upgrade);
    }

    private void Start()
    {
        Observer.Instance.OnPlayerUpgradeChanged += UpdateUI;

        Invoke(nameof(UpdateUI), 0.1f);
    }

    private void UpdateUI()
    {
        UpdateUI(upgradeType);
    }

    private void UpdateUI(StatsType type)
    {
        if (type != upgradeType) return;

        upgradeName.text = upgradeType.ToString();

        Loader.Load(upgradeName.text, out float current);
        currentValue.text = current.ToString();
        Loader.Load(upgradeName.text + "Cost", out int cost);
        upgradeCost.text = cost.ToString();
    }

    private void Upgrade()
    {
        Observer.Instance.PlayerUpgradeChanged(upgradeType);
    }
}