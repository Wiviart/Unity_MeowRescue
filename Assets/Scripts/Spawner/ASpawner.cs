using UnityEngine;

namespace MeowRescue.Spawner
{
    public abstract class ASpawner
    {
        protected GameObject Spawn(GameObject prefab, Vector2 position)
        {
            var pos = new Vector3(position.x, 0, position.y);
            var rot = prefab.transform.rotation;
            var obj = Object.Instantiate(prefab, pos, rot);
            return obj;
        }

        protected GameObject Spawn(GameObject prefab, Vector2 position, Vector3 rotation)
        {
            var pos = new Vector3(position.x, 0, position.y);
            var rot = Quaternion.Euler(rotation);
            var obj = Object.Instantiate(prefab, pos, rot);
            return obj;
        }

        protected GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
        {
            var obj = Object.Instantiate(prefab, position, rotation);
            return obj;
        }
        
        protected GameObject Spawn(GameObject prefab, Vector3 position)
        {
            var rot = prefab.transform.rotation;
            var obj = Object.Instantiate(prefab, position, rot);
            return obj;
        }
    }
}