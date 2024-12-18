using UnityEngine;
using UnityEngine.UI;

namespace MeowRescue.Utilities
{
    public class UI_Button : MonoBehaviour
    {
        private Button button;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(OnClick);
        }

        protected virtual void OnClick()
        {
            Debug.Log("Button Clicked");
        }
    }
}