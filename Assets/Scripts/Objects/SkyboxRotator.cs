using UnityEngine;

namespace MeowRescue.Objects
{
    public class SkyboxRotator : MonoBehaviour
    {
        public float speed = 1;
        
        private void Update()
        {
            RenderSettings.skybox.SetFloat("_Rotation", Time.time * speed);
        }
    }
}