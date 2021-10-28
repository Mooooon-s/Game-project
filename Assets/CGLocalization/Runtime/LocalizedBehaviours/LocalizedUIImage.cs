using UnityEngine;
using UnityEngine.UI;

namespace CGLocalization
{
    [SelectKeyType(KeyType.Sprite)]
    [RequireComponent(typeof(Image))]
    public sealed class LocalizedUIImage : LocalizedBehaviour
    {
        private Image m_image;

        protected override void AssignObject(Object obj)
        {
            if (!m_image)
                m_image = GetComponent<Image>();

            m_image.sprite = obj as Sprite;
        }
    }
}