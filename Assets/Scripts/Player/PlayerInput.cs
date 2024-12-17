using UnityEngine;
using UnityEngine.InputSystem;

namespace MeowRescue.Player
{
    public class PlayerInput
    {
        private InputSystem_Actions input;
        private Joystick joystick; // Reference to the Joystick

        public PlayerInput()
        {
            input = new InputSystem_Actions();
            input.Enable();

            joystick = GameObject.FindObjectOfType<Joystick>();
        }

        public Vector2 GetMovement()
        {
            Vector2 inputSystemMovement = input.Player.Move.ReadValue<Vector2>();
            Vector2 joystickMovement = joystick != null ? joystick.Direction : Vector2.zero;

            // If the joystick is active (non-zero), prioritize its input
            return joystickMovement.magnitude > 0 ? joystickMovement : inputSystemMovement;
        }
    }
}