using UnityEngine;

namespace MeowRescue.Player
{
    public class PlayerMovement
    {
        private readonly CharacterController controller;
        private const float startSpeed = 100;
        private float speed = startSpeed;

        public PlayerMovement(MonoBehaviour mono)
        {
            controller = mono.GetComponent<CharacterController>();
        }

        public void Move(Vector2 movement)
        {
            var direction = new Vector3(movement.x, 0, movement.y);
            controller.Move(direction * speed * Time.deltaTime);

            if (movement.magnitude <= 0) return;
            RotatePlayer(direction);
        }

        private void RotatePlayer(Vector3 direction)
        {
            if(direction==Vector3.zero) return;
            var rotation = Quaternion.LookRotation(direction, Vector3.up);
            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, rotation, 0.15f);
        }
    }
}