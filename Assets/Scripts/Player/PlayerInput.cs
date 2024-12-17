using UnityEngine;
using UnityEngine.InputSystem;

namespace MeowRescue.Player
{
    public class PlayerInput
    {
        private InputSystem_Actions input;

        public PlayerInput()
        {
            input = new InputSystem_Actions();
            input.Enable();
        }

        public Vector2 GetMovement()
        {
            return input.Player.Move.ReadValue<Vector2>();
        }
    }
}