using MeowRescue.Score;
using MeowRescue.Utilities;
using UnityEngine;

namespace MeowRescue.Player
{
    public class PlayerBehaviour : MonoBehaviour
    {
        private PlayerInput input;
        private PlayerMovement mover;
        private PlayerVisual visual;
        private AnimatorHandler anim;
        private PlayerCollector collector;
        private PlayerGold goldCounter;
        private SpeedHandler speedHandler;
        [SerializeField] private GameObject playerVisual;
        private Vector3 startPosition;

        private void Start()
        {
            Observer.Instance.OnGameEnded += CalculateReward;
            Observer.Instance.OnGameWin += CalculateReward;
            Observer.Instance.OnPlayerUpgradeChanged += UpgradeStats;

            visual = new PlayerVisual(playerVisual);
            visual.SetUpVisuals(transform);

            input = new PlayerInput();
            goldCounter = new PlayerGold();
            speedHandler = new SpeedHandler(goldCounter);
            anim = new AnimatorHandler(this);
            mover = new PlayerMovement(this, speedHandler);
            collector = new PlayerCollector(transform);

            startPosition = transform.position;
        }

        private void OnDisable()
        {
            input.OnDisable();
        }

        private void Update()
        {
            var isPlaying = LevelManager.GameState == GameState.Playing;
            var movement = isPlaying ? input.GetMovement() : Vector2.zero;
            var magnitude = isPlaying ? Mathf.Clamp01(movement.magnitude) : 0;

            mover.Move(movement);
            anim.SetParameter(ConstTag.RUN, magnitude > 0);
            anim.SetParameter(ConstTag.MOVEMENT, magnitude);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag(ConstTag.MEOW))
            {
                collector.Collect(other.transform);
                anim.SetLayerWeight(ConstTag.CATCH_LAYER, 1);
            }

            if (other.gameObject.CompareTag(ConstTag.TSUNAMI))
            {
                Observer.Instance.GameEnded();
            }

            if (other.gameObject.CompareTag(ConstTag.EXIT))
            {
                Observer.Instance.GameWin();
            }
        }

        private void CalculateReward()
        {
            var distance = Vector3.Distance(startPosition, transform.position);
            var isAvailable = startPosition.z < transform.position.z;
            var s = isAvailable ? Mathf.FloorToInt(distance) : 0;
            Debug.Log($"Score: {s} for distance: {distance} meters");
            goldCounter.AddGold(s);
            Observer.Instance.ScoreChanged(distance);
        }


        private void UpgradeStats(StatsType upgradeType)
        {
            switch (upgradeType)
            {
                case StatsType.Speed:
                    speedHandler.UpdateSpeed();
                    break;
                case StatsType.Stamina:
                    break;
                case StatsType.Income:
                    break;
                default:
                    break;
            }
        }
    }
}