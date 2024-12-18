using System;
using System.Collections;
using UnityEngine;

namespace MeowRescue.Utilities
{
    public class AnimatorHandler
    {
        private Animator anim;
        private MonoBehaviour mono;

        public AnimatorHandler(MonoBehaviour mono)
        {
            this.mono = mono;
            anim = mono.GetComponentInChildren<Animator>();
        }

        public void SetParameter(string name, bool value)
        {
            anim.SetBool(name, value);
        }

        public void SetParameter(string name, float value)
        {
            anim.SetFloat(name, value);
        }

        public void SetParameter(string name)
        {
            anim.SetTrigger(name);
        }

        public void SetParameter(string name, int value)
        {
            anim.SetInteger(name, value);
        }

        public void PlayAnimation(string name, float time)
        {
            anim.CrossFade(name, time);
        }

        public void SetLayerWeight(int layerIndex, float weight)
        {
            mono.StopCoroutine(SetLayerWeightCoroutine(layerIndex, weight));
            mono.StartCoroutine(SetLayerWeightCoroutine(layerIndex, weight));
        }

        private IEnumerator SetLayerWeightCoroutine(int layerIndex, float weight)
        {
            float currentWeight = anim.GetLayerWeight(layerIndex);
            int direction = weight > currentWeight ? 1 : -1;
            float timer = weight > currentWeight ? 0 : 1;

            while (timer >= 0 && timer <= 1)
            {
                timer += Time.deltaTime * direction;
                anim.SetLayerWeight(layerIndex, Mathf.Lerp(currentWeight, weight, timer));
                yield return null;
            }

            anim.SetLayerWeight(layerIndex, weight);
        }
    }
}