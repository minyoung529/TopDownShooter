using UnityEngine;

namespace TheGreatGGM
{
    public static class ExtensionMethod
    {
        public static float GGM(this Transform transform)
        {
            return transform.position.x + transform.position.y + transform.position.z;
        }
    }
}