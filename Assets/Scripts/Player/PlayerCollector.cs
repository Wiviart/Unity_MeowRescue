using System.Collections.Generic;
using UnityEngine;

namespace MeowRescue.Player
{
    public class PlayerCollector
    {
        private readonly Transform player;
        private Stack<Transform> meows = new Stack<Transform>();

        public PlayerCollector(Transform player)
        {
            this.player = player;
        }

        public void Collect(Transform meow)
        {
            meows.Push(meow);
            meow.SetParent(player);
            float newY = 2 + ((meows.Count - 1) * 1);
            float newZ = 1;
            meow.localPosition = new Vector3(0, newY, newZ);
            meow.localRotation = Quaternion.Euler(0, 90, 0);
        }

        public void Drop()
        {
            if (meows.Count == 0) return;
            var meow = meows.Pop();
            meow.SetParent(null);
        }
    }
}