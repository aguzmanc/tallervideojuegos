using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MetalSlug 
{
    public static class ExtensionMethods
    {
        //Returns the X position of the transform but in a Vector3.
        public static Vector3 positionX(this Transform trans)
        {
            Vector3 result;

            result = new Vector3 (trans.position.x, 0f, 0f);
            return result;
        }
    } 
}
