using UnityEngine;

namespace CGLocalization
{
    [SelectKeyType(KeyType.Texture)]
    public sealed class LocalizedMaterialTexture : LocalizedBehaviour
    {
        public Material material;
        public string textureProperty = "_MainTex";

        protected override void AssignObject(Object obj)
        {
            if (material)
            {
                Texture texture = obj as Texture;
                material.SetTexture(textureProperty, texture);
            }
#if UNITY_EDITOR
            else
            {
                Debug.LogWarning("The variable Material of LocalizedMaterialTexture has not been assigned.", gameObject);
            }
#endif
        }
    }
}