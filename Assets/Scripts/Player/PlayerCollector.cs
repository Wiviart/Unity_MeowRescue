using System.Collections.Generic;
using UnityEngine;

namespace MeowRescue.Player
{
    public class PlayerCollector
    {
        private readonly Transform player;
        private Queue<Transform> meows = new Queue<Transform>();

        public PlayerCollector(Transform player)
        {
            this.player = player;
        }

        public void Collect(Transform meow)
        {
            meows.Enqueue(meow);
            meow.SetParent(player);
            meow.localPosition = Vector3.zero;
        }

        public void Drop()
        {
            if (meows.Count == 0) return;
            var meow = meows.Dequeue();
            meow.SetParent(null);
        }
    }
}