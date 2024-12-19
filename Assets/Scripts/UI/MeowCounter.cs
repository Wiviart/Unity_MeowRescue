using MeowRescue.Utilities;
using TMPro;
using UnityEngine;

namespace MeowRescue.UI
{
    public class MeowCounter : MonoBehaviour
    {
        private TextMeshProUGUI text;

        void Awake()
        {
            text = GetComponent<TextMeshProUGUI>();
        }
        
        private void OnEnable()
        {
            Observer.Instance.OnMeowChanged += ShowMeow;
        }

        private void ShowMeow(int meow, int maxMeow)
        {
            text.text = meow + "/" + maxMeow;
        }
    }
}