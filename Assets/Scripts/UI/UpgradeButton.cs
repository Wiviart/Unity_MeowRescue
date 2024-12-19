using MeowRescue.Player;
using MeowRescue.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MeowRescue.UI
{
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

        private void OnEnable()
        {
            Observer.Instance.OnSpeedChanged += UpdateUI;
        }

        private void UpdateUI(float speed, int cost)
        {
            upgradeName.text = upgradeType.ToString();
            currentValue.text = speed.ToString("F1");
            upgradeCost.text = cost.ToString();
        }

        private void Upgrade()
        {
            Observer.Instance.PlayerUpgrade(upgradeType);
        }
    }
}