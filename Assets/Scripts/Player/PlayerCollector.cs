using System.Collections.Generic;
using UnityEngine;

namespace MeowRescue.Player
{
    public class PlayerCollector
    {
        private readonly Transform player;
        private Stack<Transform> meows = new();

        public PlayerCollector(Transform player)
        {
            this.player = player;
        }

        public void Collect(Transform meow)
        {
            meows.Push(meow);
            meow.SetParent(player);
            float newY = 1 + meows.Count;
            meow.localPosition = new Vector3(0, newY, 1);
            meow.localRotation = Quaternion.Euler(0, 90, 0);
        }

        public void Drop()
        {
            if (meows.Count == 0) return;
            var meow = meows.Pop();
            meow.SetParent(null);
        }

        public bool HasAllMeows(int count)
        {
            return meows.Count == count;
        }
    }
}