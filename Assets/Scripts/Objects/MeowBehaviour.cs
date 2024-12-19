using MeowRescue.Data;
using MeowRescue.Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace MeowRescue.Meow
{
    public class MeowBehaviour : MonoBehaviour, ICollectable
    {
        private int speed;
        private Transform player;
        public float obstacleDetectionDistance = 1f;
        public LayerMask obstacleLayer;
        private Vector3 currentDirection;
        private bool isCollected;

        private void Start()
        {
            Loader.Load(ConstTag.LEVEL, out speed);
            speed *= 5;
            player = FindObjectsByType<PlayerBehaviour>(FindObjectsSortMode.None)[0].transform;

            currentDirection = Vector3.forward;
        }

        private void Update()
        {
            if (isCollected) return;
            var dis = Vector3.Distance(player.position, transform.position);
            if (dis > 10) return;

            var awayFromPlayer = (transform.position - player.position).normalized;
            float randomAngle = Random.Range(-90, 90);
            var rotation = Quaternion.Euler(0, randomAngle, 0);
            var randomDirection = rotation * awayFromPlayer;

            if (IsObstacleAhead(randomDirection))
            {
                randomDirection = GetClearDirection(awayFromPlayer);
            }

            currentDirection = randomDirection;
            var target = Quaternion.LookRotation(currentDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5);
            transform.position += currentDirection * speed * Time.deltaTime;
        }

        private bool IsObstacleAhead(Vector3 direction)
        {
            Ray ray = new Ray(transform.position + Vector3.up, direction);
            return Physics.Raycast(ray, obstacleDetectionDistance, obstacleLayer);
        }

        private Vector3 GetClearDirection(Vector3 awayFromPlayer)
        {
            while (true)
            {
                var angle = Random.Range(-90, 90);
                var rotation = Quaternion.Euler(0, angle, 0);
                var testDirection = rotation * awayFromPlayer;
                if (!IsObstacleAhead(testDirection))
                {
                    return testDirection;
                }
            }
        }

        public void Collect()
        {
            isCollected = true;
            gameObject.tag = "Untagged";
        }
    }
}