using MeowRescue.Data;
using UnityEngine;

namespace MeowRescue.Objects
{
    public class ObstacleBehaviour : MonoBehaviour
    {
        [SerializeField] private float obstacleDetectionDistance = 1f;
        [SerializeField] private LayerMask obstacleLayer;
        private int speed;
        private int direction;

        private void Start()
        {
            Loader.Load(ConstTag.LEVEL, out speed);
            direction = Random.Range(0, 2) == 0 ? -1 : 1;
        }

        private void Update()
        {
            if (IsObstacleAhead(Vector3.right * direction))
            {
                direction *= -1;
            }

            transform.position += Vector3.right * speed * Time.deltaTime * direction;
        }

        private bool IsObstacleAhead(Vector3 direction)
        {
            Ray ray = new Ray(transform.position + Vector3.up, direction);
            return Physics.Raycast(ray, obstacleDetectionDistance, obstacleLayer);
        }
    }
}