using System;
using MeowRescue.Utilities;
using Score;
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
        private PlayerGold reward;
        [SerializeField] private GameObject playerVisual;
        private Vector3 startPosition;

        private void Awake()
        {
            visual = new PlayerVisual(playerVisual);
            visual.SetUpVisuals(transform);

            input = new PlayerInput();
            mover = new PlayerMovement(this);
            anim = new AnimatorHandler(this);
            collector = new PlayerCollector(transform);
            reward = new PlayerGold();

            startPosition = transform.position;
        }

        private void Update()
        {
            var isPlaying = LevelManager.Instance.gameState == GameState.Playing;
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
            }

            if (other.gameObject.CompareTag(ConstTag.TSUNAMI))
            {
                LevelManager.Instance.gameState = GameState.GameOver;
                CalculateReward();
            }

            if (other.gameObject.CompareTag(ConstTag.EXIT))
            {
                LevelManager.Instance.gameState = GameState.GameWin;
            }
        }

        private void CalculateReward()
        {
            var distance = Vector3.Distance(startPosition, transform.position);
            var s = Mathf.FloorToInt(distance);
            Debug.Log($"Score: {s} for distance: {distance} meters");
            reward.AddGold(s);
        }
    }
}