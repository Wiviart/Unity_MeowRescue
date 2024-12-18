using System;
using MeowRescue.Utilities;
using TMPro;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] children;
    [SerializeField] private TextMeshProUGUI panelName;
    [SerializeField] private TextMeshProUGUI score;

    private void Start()
    {
        Observer.Instance.OnGameEnded += () =>
        {
            panelName.text = "RESTART?";
            Show();
        };

        Observer.Instance.OnGameWin += () =>
        {
            panelName.text = "NEXT LEVEL?";
            Show();
        };

        Observer.Instance.OnScoreChanged += ShowScore;

        Hide();
    }

    private void Show()
    {
        foreach (var child in children)
        {
            child.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (var child in children)
        {
            child.SetActive(false);
        }
    }

    private void ShowScore(float s)
    {
        score.text = "\nDistance: " + s.ToString("F") + "m.";
    }
}