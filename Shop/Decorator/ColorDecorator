using System;
using System.Collections.Generic;
using UnityEngine;

namespace CustomShops
{
    class ColorDecorator
    {
        public ColorDecorator(){}

        public void Decorate(GameObject go, Dictionary<string, object> options, AssetBundle assetBundle)
        {
            foreach (Material material in AssetManager.Instance.objectMaterials)
            {
                if (material.name == "CustomColorsDiffuse")
                {
                    SetMaterial(go, material);

                    break;
                }
            }
        }

        private void SetMaterial(GameObject go, Material material)
        {
            // Go through all child objects and recolor		
            Renderer[] renderCollection;
            renderCollection = go.GetComponentsInChildren<Renderer>();

            foreach (Renderer render in renderCollection)
            {
                render.sharedMaterial = material;
            }
        }
    }
}
