using MeowRescue.Utilities;
using TMPro;
using UnityEngine;

namespace MeowRescue.UI
{
    public class MeowCounter : MonoBehaviour
    {
        private TextMeshProUGUI text;

        private void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
            Observer.Instance.OnMeowChanged += ShowMeow;
        }

        private void ShowMeow(int meow, int maxMeow)
        {
            text.text = meow + "/" + maxMeow;
        }
    }
}