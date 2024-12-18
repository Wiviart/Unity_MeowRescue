using MeowRescue.Data;
using MeowRescue.Utilities;
using UnityEngine;

namespace MeowRescue.Player
{
    public class PlayerMovement
    {
        private readonly CharacterController controller;
        private float speed = ConstTag.startSpeed;

        public PlayerMovement(MonoBehaviour mono)
        {
            controller = mono.GetComponent<CharacterController>();
            Loader.Load(StatsType.Speed.ToString(), out float s);
            speed = Mathf.Max(s, speed);
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
            if (direction == Vector3.zero) return;
            var rotation = Quaternion.LookRotation(direction, Vector3.up);
            controller.transform.rotation = Quaternion.Slerp(controller.transform.rotation, rotation, 0.15f);
        }

        public void UpdateSpeed(StatsType type)
        {
            if (type != StatsType.Speed) return;
            speed += 0.1f;
            Saver.Save(StatsType.Speed.ToString(), speed);
        }
    }
}