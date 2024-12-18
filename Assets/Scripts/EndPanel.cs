using System;
using MeowRescue.Utilities;
using UnityEngine;

public class EndPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] children;

    private void Start()
    {
        Hide();

        Observer.Instance.OnGameEnded += Show;
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
}