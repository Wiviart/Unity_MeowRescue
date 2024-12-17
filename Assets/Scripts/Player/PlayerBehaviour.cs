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
        [SerializeField] private GameObject playerVisual;

        private void Awake()
        {
            visual = new PlayerVisual(playerVisual);
            visual.SetUpVisuals(transform);
            
            input = new PlayerInput();
            mover = new PlayerMovement(this);
            anim = new AnimatorHandler(this);
        }

        private void Update()
        {
            var movement = input.GetMovement();
            mover.Move(movement);

            var magnitude = Mathf.Clamp01(movement.magnitude);
            anim.SetParameter("Run", magnitude > 0);
            anim.SetParameter("Movement Multiplier", magnitude);
        }
    }
}