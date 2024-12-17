using UnityEngine;

public class TsunamiBehaviour : MonoBehaviour
{
    private readonly float[] speeds = { 10f, 40f };
    private const float checkPoint = 400f;

    private void Update()
    {
        var speed = 
            transform.position.z < checkPoint ? 
            speeds[0] : speeds[1];
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}