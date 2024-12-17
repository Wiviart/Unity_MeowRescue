using UnityEngine;

public class PlayerVisual
{
    private GameObject prefab;

    public PlayerVisual(GameObject prefab)
    {
        this.prefab = prefab;
    }

    public void SetUpVisuals(Transform parent)
    {
        var visual = Object.Instantiate(prefab, parent);
    }
}