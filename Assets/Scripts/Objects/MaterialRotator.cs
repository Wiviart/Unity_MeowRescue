using UnityEngine;

public class MaterialRotator : MonoBehaviour
{
    private float speed = 0.1f;

    private Material material;

    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }

    private void Update()
    {
        var newOffset = Time.time * speed;
        material.mainTextureOffset = new Vector2(0, newOffset);
    }
}